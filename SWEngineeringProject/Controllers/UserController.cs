using Microsoft.AspNetCore.Mvc;
using SoftwareLab.Core.Features.User.Command.CreateUser;
using SoftwareLab.Core.Features.User.Query.GetUserById;
using SoftwareLab.WebAPI.Controllers;

namespace SoftwareLab.WEBAPI.Controllers
{

    public class UserController : BaseApiController
    {
       

        [HttpPost(Name ="CrateUser")]
        public async Task<int> Post([FromBody] CreateUserCommand request)
        {

            return await Mediator.Send(request);
            //mediator gidip CreateUserCommand ile ilgili olan handlerı yakalayacak
        }
        [HttpGet(Name ="GetUserById/{id}")]
        public async Task<GetUserByIdViewModel> Get(int id)
        {

            return await Mediator.Send(new GetUserByIdQuery { UserId=id});
            //mediator gidip GetUserByIdQuery ile ilgili olan handlerı yakalayacak

        }
    }
}
