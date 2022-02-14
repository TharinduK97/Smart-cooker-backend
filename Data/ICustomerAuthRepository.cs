using Smart_Cookers.Models;
using System.Threading.Tasks;

namespace Smart_Cookers.Data
{
    public interface ICustomerAuthRepository
    {
        Task<ServiceResponse<string>> CustomerRegister(Customer customer, string password, Address address);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<bool> UserExists(string email);
    }
}
