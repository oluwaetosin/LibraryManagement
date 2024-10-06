using ErrorOr;
using Library.Application.Common.Interfaces;
using MediatR;
using DomainUser = Library.Domain.Users;

namespace Library.Application.User.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<DomainUser.User>>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<DomainUser.User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new DomainUser.User
            {
               Email = request.email

            };

              await _userRepository.CreateUser(
                user
            );

            if (user == null)
            {
                return Error.Unexpected();
            }
            return user;
        }
    }
}
