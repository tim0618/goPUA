using backend.ImportModel;
using backend.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _service;
    public CartController(ICartService service)
    {
        _service = service;
    }
    [HttpPost("CreateCart")]
    [Authorize]
    public IActionResult CreateCart(CreateCartImportModel createCart)
    {
        if (createCart != null)
        {
            _service.CreateCart(createCart);
            return Ok();
        }
        return BadRequest();
    }
    [HttpPut("EditCart")]
    [Authorize]
    public IActionResult EditCart(EditCartImportModel editCart)
    {
        if (editCart != null)
        {
            _service.EditCart(editCart);
            return Ok();
        }
        return BadRequest();
    }
    [HttpDelete("DeleteCart")]
    [Authorize]
    public IActionResult DeleteCart(DeleteCartImportModel deleteCart)
    {
        if (deleteCart != null)
        {
            _service.DeleteCart(deleteCart);
            return Ok();
        }
        return BadRequest();
    }

}