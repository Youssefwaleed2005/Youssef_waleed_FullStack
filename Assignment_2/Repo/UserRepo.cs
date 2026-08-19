using Assignment_3.Models;
using Assignment_3.Data;
using Microsoft.EntityFrameworkCore;

namespace Assignment_3.Repo
{
    public class UserRepo:IUserRepo
    {
        private readonly AppDbContext _dbcontext;

        public UserRepo(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<User> CreateUser(User user)
        {
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbcontext.Users.ToListAsync();
        }
    }
}
