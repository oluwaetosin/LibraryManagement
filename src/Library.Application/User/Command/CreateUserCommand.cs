using ErrorOr;
using MediatR;
using DomainUser = Library.Domain.Users;
namespace Library.Application.User.Command
{
    public record CreateUserCommand(
        string email
        ): IRequest<ErrorOr<DomainUser.User>>;

   
}
