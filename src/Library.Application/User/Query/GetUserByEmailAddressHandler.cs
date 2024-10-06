using ErrorOr;
using Library.Application.Common.Interfaces;
using MediatR;
using DomainUser = Library.Domain.Users;

namespace Library.Application.User.Query
{
    public class GetUserByEmailAddressHandler : IRequestHandler<GetUserByEmailCommand, ErrorOr<DomainUser.User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailAddressHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<DomainUser.User>> Handle(GetUserByEmailCommand request, CancellationToken cancellationToken)
        {
            
            var user = await _userRepository.GetUserByEmail(
              request.email
          );

            if (user == null)
            {
                return Error.Unexpected();
            }
            return user;
        }
    }
}

 
