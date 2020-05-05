using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LifeBoatMediatR.Application.Users.Commands.CreateUser;
using LifeBoatMediatR.Application.Users.Commands.DeleteUser;
using LifeBoatMediatR.Application.Users.Commands.UpdateUser;
using LifeBoatMediatR.Application.Users.Queries.GetUsersList;

namespace LifeBoatMediatR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MediatRController : ControllerBase
    {
        public MediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLookupDto>>> GetAll()
        {
            var queryResult = await _mediator.Send(new GetUsersListQuery());

            return Ok(queryResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            var commandResult = await _mediator.Send(command);

            return Ok(commandResult);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateUserCommand command)
        {
            var commandResult = await _mediator.Send(command);

            return Ok(commandResult);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteUserCommand command)
        {
            var commandResult = await _mediator.Send(command);

            return Ok(commandResult);
        }
    }
}