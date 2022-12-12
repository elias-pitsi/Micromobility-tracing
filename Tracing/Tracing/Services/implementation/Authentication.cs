using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using Tracing.DataAccess.DataContext;
using Tracing.DataAccess.Dtos;
using Tracing.DataAccess.Models;
using Tracing.Services.interfaces;

namespace Tracing.Services.implementation;

public class Authentication : IAuthentication
{
    private readonly TracingContext _context;
    private readonly IConfiguration _configuration;

    public Authentication(TracingContext context, IConfiguration configuration)
    {
        _context = context;
        _context.Database.EnsureCreated();
        _configuration = configuration;
    }

    public async Task<string> Registration(OwnerRegistrationDto request)
    {
        var emailExist = await _context.Owners.Where(x => x.email == request.email).FirstOrDefaultAsync();

        if (emailExist != null)
        {
            throw new Exception("User already exists");
        }
        
        CreatePasswordHash(request.password, out byte[] PasswordHash, out byte[] PasswordSalt);

        var owner = new Owner
        {
            Name = request.Name,
            Surname = request.Surname,
            email = request.email,
            PasswordHash = PasswordHash,
            PasswordSalt = PasswordSalt,
            VerificationToken = CreateRandomToken()
        }; 
            
         await _context.Owners.AddAsync(owner);
         await _context.SaveChangesAsync();
         return "Owner successfully registered";
    }

    public async Task<string> Login(OwnerLoginDto request)
    {
        var email = await _context.Owners.Where(x => x.email == request.email).FirstOrDefaultAsync();
        var passwordHash = await _context.Owners.Select(x => x.PasswordHash).FirstOrDefaultAsync();
        var passwordSalt = await _context.Owners.Select(x => x.PasswordSalt).FirstOrDefaultAsync();
        var owner = await _context.Owners.FirstOrDefaultAsync(u => u.email == request.email);
        
        if (email == null)
        {
            return "Wrong Credentials! Please check your username or password";
        }

        if ((passwordHash is not null) && (passwordSalt is not null))
        {
            if (!VerifyPasswordHash(request.password, passwordHash, passwordSalt))
            {
                return "Wrong Credentials! Please check your username or password";
            }
        }

        var token = CreateToken(owner);

        return token;
    }

    public async Task<string> ForgotPassword(string email)
    {
        var owner = _context.Owners.FirstOrDefault(u => u.email == email);

        if (owner == null)
        {
            return "User does not exist";
        }

        owner.PasswordResetToken = CreateRandomToken();
        owner.ResetTokenExpires = DateTime.Now.AddHours(1);
        await _context.SaveChangesAsync();

        return "You may reset your password";
    }

    // reset password method
    public async Task<string> ResetPassword(ResetPasswordRequest request)
    {
        var user = await _context.Owners.FirstOrDefaultAsync(u => u.PasswordResetToken == request.Token);
        

        if (user == null || user.ResetTokenExpires < DateTime.Now)
        {
            return "Invalid Token";
        }
        
        CreatePasswordHash(request.Password, out byte[] PasswordHash, out byte[] PasswordSalt);

        user.PasswordHash = PasswordHash;
        user.PasswordSalt = PasswordSalt;
        user.PasswordResetToken = null;
        user.ResetTokenExpires = null;

        await _context.SaveChangesAsync();

        return "Password successfully reset!";
        
    }


    public async Task<string> Verify(string token)
    {
        var owner = await _context.Owners.FirstOrDefaultAsync(u => u.VerificationToken == token);

        if (owner == null)
        {
            return "Invalid token!";
        }

        owner.VerifiedAt = DateTime.Now;
        await _context.SaveChangesAsync();

        return "User verified!"; 
    }


    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }

    private string CreateToken(Owner owner)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, owner.Name),
            new Claim(JwtRegisteredClaimNames.Sub, owner.OwnerId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, owner.email),
            new Claim(JwtRegisteredClaimNames.Name, owner.Name),
            new Claim(JwtRegisteredClaimNames.FamilyName, owner.Surname),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()),
            new Claim(ClaimTypes.Role, "Admin"),
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Token").Value));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token); 

        return jwt;
    }

    private void CreatePasswordHash(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            PasswordSalt = hmac.Key;
            PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private static string CreateRandomToken()
    {
        return Convert.ToHexString(RandomNumberGenerator.GetBytes(64)); 
    }
}