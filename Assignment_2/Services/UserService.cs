using Assignment_3.Models;
using Assignment_3.Repo;
namespace Assignment_3.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> CreateUser(User user)
        {
            return await _userRepo.CreateUser(user);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepo.GetAll();
        }
    }
}
