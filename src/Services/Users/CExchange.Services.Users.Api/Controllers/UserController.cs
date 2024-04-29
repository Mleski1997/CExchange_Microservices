using CExchange.Services.Users.Application.Commands;
using Convey.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Windows.Input;

namespace CExchange.Services.Users.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICommandHandler<SignUp> _signUpHandler;

        public UserController(ICommandHandler<SignUp> signUpHandler)
        {
            _signUpHandler = signUpHandler;
        }
        [HttpPost]
        public async Task<ActionResult> Post(SignUp command)
        {
            command = command with {UserId = Guid.NewGuid()};
            await _signUpHandler.HandleAsync(command);
            return NoContent();

        }
    }
}
