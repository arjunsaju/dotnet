using EcomProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcomProductAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        //private readonly OrderDbContext context;

        public UserRepository(ProductDbContext context)
        {
            Context = context;
        }
        public ProductDbContext Context { get; }
        public async Task<bool> isValidateUser(string username, string password)
        {
            return await Context.userInfo.AnyAsync(u => u.username == username && u.password == password);
        }
    }
}