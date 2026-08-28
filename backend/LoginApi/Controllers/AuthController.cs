using LoginApi.DTOs.Auth;
using LoginApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoginApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup(SignupRequest request)
    {
        try
        {
            var user = await _authService.SignupAsync(request);

            return Ok(new
            {
                message = "Signup successful.",
                user = new
                {
                    id = user.Id,
                    name = user.Name,
                    email = user.Email,
                    createdAt = user.CreatedAt
                }
            });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new
            {
                message = ex.Message
            });
        }
    }
}