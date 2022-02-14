using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Smart_Cookers.Data;
using Smart_Cookers.Dtos.OutletDtos;
using Smart_Cookers.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Cookers.Services.OutletService
{
    public class OutletService : IOutletService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public OutletService(IMapper mapper, DataContext context)
        {

            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetOutletDto>>> AddOutlet(AddOutletDto newOutlet)
        {
            var serviceResponse = new ServiceResponse<List<GetOutletDto>>();
            Outlet outlet = _mapper.Map<Outlet>(newOutlet);

            _context.Outlets.Add(outlet);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Outlets
                .Select(c => _mapper.Map<GetOutletDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetOutletDto>>> GetAllOutles()
        {
            var serviceResponse = new ServiceResponse<List<GetOutletDto>>();
            var DbOutlets = await _context.Outlets
                .Include(p => p.Products)
                .ToListAsync();
            serviceResponse.Data = DbOutlets.Select(c => _mapper.Map<GetOutletDto>(c)).ToList();
            return serviceResponse;
        }
    }
}
