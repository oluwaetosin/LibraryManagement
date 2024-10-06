using ErrorOr;
using MediatR;
using DomainUser = Library.Domain.Users;

namespace Library.Application.User.Query
{
    public record GetUserByEmailCommand(string email): IRequest<ErrorOr<DomainUser.User>>;

}
