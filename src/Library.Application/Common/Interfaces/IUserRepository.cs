using DomainUser = Library.Domain.Users;

namespace Library.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(DomainUser.User user);
        Task<DomainUser.User> GetUserByEmail(string email);
    }
}
