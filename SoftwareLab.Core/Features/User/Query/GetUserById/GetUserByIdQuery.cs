using MediatR;
using SoftwareLab.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareLab.Core.Features.User.Query.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdViewModel>
    {
        //burada yazılan proplar kullanıcıdan alınacak olanlar
        //GetUserByIdViewModel ise DTO gibi kullancıya dönülecek olan proplar
        // YANİ TResponse
        public int UserId { get; set; }


        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdViewModel>
        {
            private readonly IUserRepository _userRepository;

            public GetUserByIdQueryHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            //                     request             response
            // IRequestHandler<GetUserByIdQuery, GetUserByIdViewModel>
            public async Task<GetUserByIdViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                //?? returns the value of its left-hand operand if it isn't null;
                //otherwise, it evaluates the right-hand operand and returns its result.
                //The ?? operator doesn't evaluate its right-hand operand
                //if the left-hand operand evaluates to non-null

                var user = await _userRepository.GetByIdAsync(request.UserId) ?? throw new Exception();
                return new GetUserByIdViewModel { 
                    Email=user.Email,
                    FullName=user.FullName
                };
            }
        }


    }

}
