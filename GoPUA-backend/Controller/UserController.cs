using backend.ImportModel;
using backend.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }
    [HttpPost(nameof(Register))]
    public IActionResult Register(RegisterImportModel registerImportModel)
    {
        if (registerImportModel != null)
        {
            _service.Register(registerImportModel);
            return Ok();
        }
        return BadRequest();
    }
    [HttpPost(nameof(Login))]
    public IActionResult Login(LoginImportModel loginImportModel)
    {
        if (loginImportModel != null)
        {
            var token = _service.Login(loginImportModel);
            return Ok(token);
        }
        return BadRequest();
    }

}