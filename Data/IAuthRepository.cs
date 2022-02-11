using Smart_Cookers.Models;
using System.Threading.Tasks;

namespace Smart_Cookers.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<string>> Register(StaffMember staffMember, string password);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<bool> UserExists(string email);
    }
}
