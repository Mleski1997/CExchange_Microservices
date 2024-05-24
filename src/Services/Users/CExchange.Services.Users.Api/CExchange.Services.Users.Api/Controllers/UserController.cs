﻿using CExchange.Services.Users.Application.Commands;
using CExchange.Services.Users.Application.DTO;
using CExchange.Services.Users.Application.Events;
using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Application.Queries;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ICommandHandler<SignUp> _signUpHandler;
    private readonly ICommandHandler<SignIn> _signInHandler;
    private readonly IQueryHandler<GetUsers, IEnumerable<UserDto>> _getUsersHandler;
    private readonly IQueryHandler<GetUser, UserDetailsDto> _getUserHandler;
    private readonly ITokenStorage _tokenStorage;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly ILogger _logger;

    public UserController(
        ICommandHandler<SignUp> signUpHandler,
        ICommandHandler<SignIn> signInHandler,
        IQueryHandler<GetUsers, IEnumerable<UserDto>> getUsersHandler,
        IQueryHandler<GetUser, UserDetailsDto> getUserHandler,
        ITokenStorage tokenStorage,
        IEventDispatcher eventDispatcher,
        ILogger<UserController> logger
        )
    {
        _signUpHandler = signUpHandler;
        _signInHandler = signInHandler;
        _getUsersHandler = getUsersHandler;
        _getUserHandler = getUserHandler;
        _tokenStorage = tokenStorage;
        _eventDispatcher = eventDispatcher;
        _logger = logger;
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
    public async Task<ActionResult> Post([FromBody] SignUp command)
    {
        command = command with { UserId = Guid.NewGuid() };
        await _signUpHandler.HandleAsync(command);

        var @event = new SignedUp(command.UserId, command.Email, "User's Name", "User's Last Name", "User Role");
        _logger.LogInformation($"Publishing event for user {command.UserId}");
        await _eventDispatcher.PublishAsync(@event);
        _logger.LogInformation("Event published successfully");

        return CreatedAtAction(nameof(Get), new { command.UserId }, null);
    }

    [HttpPost("sign-in")]
    public async Task<ActionResult<JwtDto>> Post([FromBody] SignIn command)
    {
        await _signInHandler.HandleAsync(command);
        var jwt = _tokenStorage.Get();
        return Ok(jwt);
    }
}
