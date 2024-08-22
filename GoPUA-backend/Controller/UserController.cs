using backend.ImportModel;
using backend.Service;
using backend.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    private readonly OrderService _orderService;
    public UserController(IUserService service, OrderService orderService)
    {
        _service = service;
        _orderService = orderService;
    }
    [HttpPost("Register")]
    public IActionResult Register(RegisterImportModel register)
    {
        if (register != null)
        {
            _service.Register(register);
            return Ok();
        }
        return BadRequest();
    }
    [HttpPut("EditUser")]
    [Authorize]
    public IActionResult EditUser(EditUserImportModel editUser)
    {
        if (editUser != null)
        {
            _service.EditUser(editUser);
            return Ok();
        }
        return BadRequest();
    }
    [HttpDelete("Eradicate")]
    [Authorize]
    public IActionResult Eradicate(EradicateImportModel eradicate)
    {
        if (eradicate != null)
        {
            _orderService.DeleteCart(eradicate.Id);
            _service.Eradicate(eradicate);
            return Ok();
        }
        return BadRequest();
    }
    [HttpPost("Login")]
    public IActionResult Login(LoginImportModel login)
    {
        if (login != null)
        {
            var token = _service.Login(login);
            _orderService.CreateCart(login.account);
            _orderService.GetCart(login.account);
            return Ok(token);
        }
        return BadRequest();
    }
    [HttpPost("Logout")]
    [Authorize]
    public IActionResult Logout()
    {
        var token = HttpContext.Request.Headers["Authorization"].ToString();
        var newtoken = _service.Logout();
        token = newtoken;
        if (token == newtoken)
        {
            return Ok(token);
        }
        return BadRequest();
    }
}