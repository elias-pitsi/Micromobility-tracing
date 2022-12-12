using Newtonsoft.Json;

namespace Tracing.DataAccess.Models
{
    public class Owner
    {
        [JsonProperty(PropertyName = "ownerid")]
        public string OwnerId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<ComponentDetails> Components { get; set; } = new();
        public List<Bike> Bikes { get; set; } = new List<Bike>();
        public string? VerificationToken { get; set; } = String.Empty;
        public string? PasswordResetToken { get; set; } = String.Empty;
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? VerifiedAt { get;  set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated = DateTime.Now; 
        public DateTime TokenExpires { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
