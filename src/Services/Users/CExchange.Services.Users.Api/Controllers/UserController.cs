// Controllers/UserController.cs
using Microsoft.AspNetCore.Mvc;
using CExchange.Services.Users.Application.Commands;
using CExchange.Services.Users.Application.Commands.Handlers;
using CExchange.Services.Users.Application.DTO;
using CExchange.Services.Users.Application.Queries;
using CExchange.Services.Users.Infrastructure.DAL.Handlers;
using CExchange.Services.Users.Infrastructure.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Application.Abstractions;
using System.Collections;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ICommandHandler<SignUp> _signUpHandler;
    private readonly ICommandHandler<SignIn> _signInHandler;
    private readonly IQueryHandler<GetUser, UserDetailsDto> _getUserHandler;
    private readonly IQueryHandler<GetUsers, IEnumerable<UserDto>> _getUsersHandler;
    private readonly ITokenStorage _tokenStorage;
    private readonly RabbitMqService _rabbitMqService;

    public UserController(
        ICommandHandler<SignUp> signUpHandler,
        ICommandHandler<SignIn> signInHandler,
        IQueryHandler<GetUser, UserDetailsDto> getUserHandler,
        IQueryHandler<GetUsers, IEnumerable<UserDto>> getUsersHandler,
        ITokenStorage tokenStorage,
        RabbitMqService rabbitMqService)
    {
        _signUpHandler = signUpHandler;
        _signInHandler = signInHandler;
        _getUserHandler = getUserHandler;
        _getUsersHandler = getUsersHandler;
        _tokenStorage = tokenStorage;
        _rabbitMqService = rabbitMqService;
    }

    [HttpGet("{userId}")]
    [Authorize(Roles = "admin")]
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

    [HttpPost("sign-up")]
    public async Task<ActionResult> Post([FromBody] SignUp command, CancellationToken cancellationToken)
    {
        command = command with { Id = Guid.NewGuid() };
        await _signUpHandler.HandleAsync(command, cancellationToken);

        var userRegisteredMessage = new
        {
            UserId = command.Id,
            RegisteredAt = DateTime.UtcNow
        };

        var messageJson = System.Text.Json.JsonSerializer.Serialize(userRegisteredMessage);
        _rabbitMqService.PublishUserRegisteredMessage(messageJson);

        return CreatedAtAction(nameof(Get), new { command.Id }, null);
    }

    [HttpPost("sign-in")]
    public async Task<ActionResult<JwtDto>> Post([FromBody] SignIn command, CancellationToken cancellationToken)
    {
        await _signInHandler.HandleAsync(command, cancellationToken);
        var jwt = _tokenStorage.Get();
        return Ok(jwt);
    }
}
