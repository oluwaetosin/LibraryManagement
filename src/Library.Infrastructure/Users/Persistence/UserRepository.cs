using Library.Application.Common.Interfaces;
using Library.Domain.Users;
using Library.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Books.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _dbContext;
        public UserRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateUser(User user)
        {
            await  _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();
        }

      

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users.Where(x=>x.Email == email).FirstOrDefaultAsync();
        }

    }
}
