using Assignment_3.DTOs;
using Assignment_3.Models;

namespace Assignment_3.Services
{
    public interface IUserService
    {
        public Task<User> CreateUser(CreateUserRequest newUser);

        public async Task<String> Login(UserLoginRequestDto user);
        public Task<List<User>> GetAll();

        public string GenerateToken(User user);

    }
}
