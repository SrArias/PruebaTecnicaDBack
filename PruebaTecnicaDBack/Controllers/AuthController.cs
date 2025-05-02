using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaDBack.Services;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public IActionResult Login()
    {
        return Ok(_authService.GenerateToken());
    }
}




