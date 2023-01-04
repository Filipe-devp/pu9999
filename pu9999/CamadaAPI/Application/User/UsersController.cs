using CamadaAPI.Application.Users.Command.Delete;
using CamadaAPI.Application.Users.Command.Get;
using CamadaAPI.Application.Users.Command.Insert;
using CamadaAPI.Application.Users.Command.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace CamadaAPI.Application.Users
{
    [Route("api/user")]
    public class UsersController : CustomBaseController
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllUserRequest()));
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] InsertUserRequest request)
        {
            return Ok(await _mediator.Send(request)); // lembre-se de informar a conexão arquivo seguro de conexão...!!!!
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

    }
}
