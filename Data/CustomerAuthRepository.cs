using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Smart_Cookers.Models;
using System.Threading.Tasks;

namespace Smart_Cookers.Data
{
    public class CustomerAuthRepository : ICustomerAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public CustomerAuthRepository(DataContext context, IMapper mapper, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }
        public Task<ServiceResponse<string>> Login(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResponse<string>> CustomerRegister(Customer newCustomer, string password, Address address)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();

            if (await UserExists(newCustomer.Email))
            {
                response.Success = false;
                response.Message = "Customer already exists.";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            newCustomer.PasswordHash = passwordHash;
            newCustomer.PasswordSalt = passwordSalt;

            Customer customer = _mapper.Map<Customer>(newCustomer);

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            _context.Addresses.Add(new Address
            {
                Customer = customer,
                DoorNumber = address.DoorNumber,
                Street = address.Street,
                City = address.City,
            });
            await _context.SaveChangesAsync();

            response.Data = customer.Id.ToString();
            return response;
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Customers.AnyAsync(x => x.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


    }
}
