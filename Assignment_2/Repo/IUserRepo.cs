using Assignment_3.Models;

namespace Assignment_3.Repo
{
    public interface IUserRepo
    {
        public Task<User> CreateUser(User user);
        public Task<List<User>> GetAll();

    }
}
