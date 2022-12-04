using System.ComponentModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tracing.DataAccess.DataContext;
using Tracing.DataAccess.Dtos;
using Tracing.DataAccess.Models;
using Tracing.Services.interfaces;

namespace Tracing.Services.implementation
{
    public class ComponentsService : IComponentsService
    {
        private readonly TracingContext _context;
        private readonly IMapper _mapper;

        public ComponentsService(TracingContext context, IMapper mapper)
        {
            _context = context;
            _context.Database.EnsureCreated();
            _mapper = mapper;
        }

        public async Task<IEnumerable<ComponentDetails>> GetComponents()
        {
            var components = await _context.Components.ToListAsync();

            return components;
        }

        public  async Task<ComponentsHistory> GetComponentHistory(Guid id)
        {
            var component = await _context.ComponentsHistories.Where(x => x.CompId == id).FirstOrDefaultAsync();

            return component;

        }
        

        public async Task<string> AddComponents(AddComponentsDto components)
        { 
            var owner = await _context.Owners.Where(u => u.OwnerId == components.ownerId).FirstOrDefaultAsync();
            var ownerDto = _mapper.Map<OwnerDto>(owner);

            if (owner is not null) 
            {
                var componentsDetails = new ComponentDetails
                {
                    CompId = components.CompId,
                    ComponentName = components.ComponentName,
                    CreatedDate = components.CreatedDate,
                    owner = ownerDto

                };

                await _context.Components.AddAsync(componentsDetails);
                await _context.SaveChangesAsync();

                return "component added";
            }

            return "Failed! Component not added";
        }

        public async Task<string> UpdateComponents(Guid id, AddComponentsDto components)
        {
            var comp = await  _context.Components.Where(u => u.CompId == id).FirstOrDefaultAsync();
            var compH =  await _context.ComponentsHistories.Where(u => u.CompId == id).FirstOrDefaultAsync();
            var listOfOwners = new List<OwnerDto> {};


            if (comp is not null && compH == null)
            {
                listOfOwners.Add(comp.owner);
                comp.OwnerId = components.ownerId;
                comp.CreatedDate = components.CreatedDate;
                comp.owner = components.owner;

                var history = new ComponentsHistory
                {
                    CompId= comp.CompId,
                    ComponentName= components.ComponentName,
                    Owner = listOfOwners,
                    OwnerId = comp.OwnerId, 
                };


                // Updating the owner 

                await _context.ComponentsHistories.AddAsync(history);
                await _context.SaveChangesAsync();

                var compH1 = await _context.ComponentsHistories.Where(u => u.CompId == id).FirstOrDefaultAsync();
                if (compH1 != null)
                {
                    compH1.Owner.Add(components.owner);
                }
                await _context.SaveChangesAsync();

                return "Info updated!";
            }
            if (comp is not null && compH != null)
            {
                comp.OwnerId = components.ownerId;
                comp.CreatedDate = components.CreatedDate;
                comp.owner = components.owner;

                compH.Owner.Add(components.owner);
                compH.CreatedDate = components.CreatedDate;
                compH.OwnerId = components.ownerId;
                await _context.SaveChangesAsync();

                return "Info updated!";
            }

                // await _context.ComponentsHistories.AddAsync(ownerDto);

                return "Something when wrong";
        }

        public async Task<string> DeleteComponent(Guid compId)
        {
            throw new NotImplementedException();
        }
    }
}
