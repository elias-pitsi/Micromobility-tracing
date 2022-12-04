using AutoMapper;
using Microsoft.Azure.Documents;
using Microsoft.EntityFrameworkCore;
using Tracing.DataAccess.DataContext;
using Tracing.DataAccess.Dtos;
using Tracing.DataAccess.Models;
using Tracing.Services.interfaces;

namespace Tracing.Services.implementation
{
    public class BikeService : IBikeService
    {
        private readonly TracingContext _context;
        private readonly IMapper _imapper;

        public BikeService(TracingContext context, IMapper mapper)
        {
            _context = context;
            _context.Database.EnsureCreated();
            _imapper = mapper;
        }

        public async Task<IEnumerable<Bike>> GetBikes()
        {
            var bikes = await _context.Bikes.ToListAsync();
            var test = bikes[0];
            Console.WriteLine(test);

            return bikes;
        }

        public async Task<string> AddBikes(BikeDto bike)
        {
            var Bikeowner = await _context.Owners.Where(u => u.OwnerId == bike.OwnerId).FirstOrDefaultAsync();
            var newBike = await _context.Bikes.Where(u => u.BikeId == bike.BikeId).FirstOrDefaultAsync();
            var BikeAdd = _imapper.Map<BikeDto>(newBike);

            if ((Bikeowner != null))
            {
                if (BikeAdd == null)
                {
                    var bikeNew = new Bike
                    {
                        BikeId = bike.BikeId,
                        OwnerId = bike.OwnerId,
                        Components = bike.Components,
                    };

                    await _context.Bikes.AddAsync(bikeNew);
                    await _context.SaveChangesAsync();
                }

                return "Biked Added";

            }

            return "Something when wrong";
        }
    }
}
