using MediatR;
using SoftwareLab.Core.Exceptions;
using SoftwareLab.Core.Repositories;
using SoftwareLab.Core.Services;

namespace SoftwareLab.Core.Features.User.Command.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        //                                                   kullancıdan alınacak kullancıya döndürülecek
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int> 
        {
            private readonly IUserRepository _userRepository;
            private readonly IEmailService _emailService;

            public CreateUserCommandHandler(IUserRepository userRepository, IEmailService emailService)
            {
                _userRepository = userRepository;
                _emailService = emailService;
            }


            public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                Entities.User ExistingUser = await _userRepository.GetByEmail(request.Email);

                if (ExistingUser != null)
                {

                    throw new UserAlreadyCreated($"User with email {request.Email} already created");

                }
                var user = await _userRepository.AddAsync(new Entities.User
                {

                    BirthDate = request.BirthDate,
                    FullName = request.FullName,
                    Email = request.Email,
                    CreatedDate = DateTime.Now,
                    IsEnabled = true,
                });

                await _emailService.SendMail(user.Email, "welcome to our website");

                return user.Id;
            }
        }


    }
}
