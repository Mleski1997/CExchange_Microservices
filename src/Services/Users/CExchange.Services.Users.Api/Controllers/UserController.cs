using CExchange.Services.Users.Application.Commands;
using CExchange.Services.Users.Application.DTO;
using CExchange.Services.Users.Application.Queries;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Windows.Input;

namespace CExchange.Services.Users.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICommandHandler<SignUp> _signUpHandler;
        private readonly IQueryHandler<GetUsers, IEnumerable<UserDto>> _getUsersHandler;
        private readonly IQueryHandler<GetUser, UserDetailsDto> _getUserHandler;

        public UserController(ICommandHandler<SignUp> signUpHandler, IQueryHandler<GetUsers, IEnumerable<UserDto>> getUsersHandler, IQueryHandler<GetUser, UserDetailsDto> getUserHandler)
        {
            _signUpHandler = signUpHandler;
            _getUsersHandler = getUsersHandler;
            _getUserHandler = getUserHandler;
        }

            [HttpGet("{userId}")]
            public async Task<ActionResult<UserDetailsDto>> Get(Guid userId)
            {
                var user = await _getUserHandler.HandleAsync(new GetUser { UserId = userId });
                if (user is null)
                {
                    return NotFound();
                }
                return Ok(user);
            }

            [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get([FromQuery] GetUsers query)
        => Ok(await _getUsersHandler.HandleAsync(query));



        [HttpPost]
            public async Task<ActionResult> Post(SignUp command)
            {
                command = command with { UserId = Guid.NewGuid() };
                await _signUpHandler.HandleAsync(command);
                return CreatedAtAction(nameof(Get), new { command.UserId }, null);
            }
    }
}
