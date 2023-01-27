using Microsoft.AspNetCore.Mvc;
using ToDoListWebApi.DataTransferObjects;
using ToDoListWebApi.Models.StronglyTypedIds;
using ToDoListWebApi.Services.Abstractions;

namespace ToDoListWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login(LoginRequest request)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (string.IsNullOrWhiteSpace(request.Username))
        {
            throw new InvalidOperationException("User name is empty");
        }

        if (string.IsNullOrWhiteSpace(request.Password))
        {
            throw new InvalidOperationException("Password is empty");
        }

        var username = new Username(request.Username);

        try
        {
            await _authService.Login(username, request.Password, Request.Cookies, Response.Cookies);
            return new OkResult();
        }
        catch (Exception)
        {
            return new UnauthorizedResult();
        }
    }

    [HttpPost("Logout")]
    public async Task<ActionResult> Logout()
    {
        try
        {
            await _authService.Logout(Response.Cookies);
            return new OkResult();
        }
        catch (Exception)
        {
            return new UnauthorizedResult();
        }
    }

    [HttpPost("GetInfo")]
    public async Task<ActionResult<UserInfoResponse>> GetInfo()
    {
        var user = await _authService.GetInfo(Request.Cookies);
        var response = new UserInfoResponse()
        {
            Username = user.Username,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
        
        return new ActionResult<UserInfoResponse>(response);
    }

    [HttpPost("GetAllUsers")]
    public async Task<ActionResult<List<UserInfoResponse>>> GetAllUsers()
    {
        var users = await _authService.GetAllUsers();
        var responses = users
            .Select(user => new UserInfoResponse()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName
            })
            .ToList();

        return responses;
    }

    [HttpPost("Register")]
    public async Task<ActionResult> Register(RegisterUserRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var username = new Username(request.UserName);
        await _authService.Register(username, request.FirstName, request.LastName, request.Password, Response.Cookies);

        return new OkResult();
    }
}