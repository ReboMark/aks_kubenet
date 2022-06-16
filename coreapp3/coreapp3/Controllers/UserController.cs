using coreapp3.DbModels;
using coreapp3.Handlers;
using coreapp3.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreapp3.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        [Route("api/add_user")]
        public async Task<ActionResponseModel> AddUser([FromBody] dbUsers user)
        {
            var res = await mediator.Send(new CreateUserCommand(user));
            return res;
        }

        [HttpGet]
        [Route("api/get_user")]
        public async Task<ActionResponseModel> GetUser(int id)
        {
            var res = await mediator.Send(new GetUserQuery(id));
            return res;
        }
    }
}
