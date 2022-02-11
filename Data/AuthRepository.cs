using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Smart_Cookers.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Smart_Cookers.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public AuthRepository(DataContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;

        }
        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var response = new ServiceResponse<string>();
            var staffMember = await _context.StaffMembers.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
            if (staffMember == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(password, staffMember.PasswordHash, staffMember.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password.";
            }
            else
            {
                response.Data = CreateToken(staffMember);
            }

            return response;
        }

        public async Task<ServiceResponse<string>> Register(StaffMember staffMember, string password)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            if (await UserExists(staffMember.Email))
            {
                response.Success = false;
                response.Message = "User already exists.";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            staffMember.PasswordHash = passwordHash;
            staffMember.PasswordSalt = passwordSalt;

            _context.StaffMembers.Add(staffMember);
            await _context.SaveChangesAsync();
            response.Data = staffMember.Id.ToString();
            return response;
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.StaffMembers.AnyAsync(x => x.Email.ToLower().Equals(email.ToLower())))
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

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private string CreateToken(StaffMember staffMember)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, staffMember.Id.ToString()),
                new Claim(ClaimTypes.Name, staffMember.Email),
                new Claim(ClaimTypes.Role, staffMember.Role.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokendDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokendDescriptor);

            return tokenHandler.WriteToken(token);
        }


    }
}
