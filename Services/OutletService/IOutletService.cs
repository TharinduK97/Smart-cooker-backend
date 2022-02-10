using Smart_Cookers.Dtos.OutletDtos;
using Smart_Cookers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smart_Cookers.Services.OutletService
{
    public interface IOutletService
    {
        Task<ServiceResponse<List<GetOutletDto>>> GetAllOutles();
        Task<ServiceResponse<List<GetOutletDto>>> AddOutlet(AddOutletDto newOutlet);
    }
}

