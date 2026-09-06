using Assignment_3.DTOs;
using Assignment_3.Enums;
using Assignment_3.Models;
using Assignment_3.Repo;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Assignment_3.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IConfiguration _config;

        public UserService(IUserRepo userRepo,IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        public async Task<User> CreateUser(CreateUserRequest newUser)
        {
            var user = new User
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password),
                Role = newUser.Role,
            };
            return await _userRepo.CreateUser(user);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepo.GetAll();
        }

        public async Task<String> Login(UserLoginRequestDto user)
        {
            var userFound = await _userRepo.Login(user);

            if (userFound == null) return null;


            // Generate token 


            var token = GenerateToken(userFound);

            return token;
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("Department","Test")
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Secret"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    int.Parse(_config["Jwt:ExpiryMinutes"]!)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
