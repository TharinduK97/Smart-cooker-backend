using Smart_Cookers.Dtos.CustomerDtos;
using Smart_Cookers.Dtos.StaffMemberDtos;
using Smart_Cookers.Models;
using System.Threading.Tasks;

namespace Smart_Cookers.Services.StaffService
{
    public interface IStaffService
    {
        Task<ServiceResponse<GetStaffMemberDto>> GetStaffById();
    }
}
