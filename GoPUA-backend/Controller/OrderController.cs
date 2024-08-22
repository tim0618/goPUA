using backend.ImportModel;
using backend.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service;
    public OrderController(IOrderService service)
    {
        _service = service;
    }
    [HttpPost("CreateOrder")]
    [Authorize]
    public IActionResult CreateOrder(CreateOrderImportModel createOrder)
    {
        if (createOrder != null)
        {
            _service.CreateOrder(createOrder);
            return Ok();
        }
        return BadRequest();
    }
    [HttpPut("EditOrder")]
    [Authorize]
    public IActionResult EditOrder(EditOrderImportModel editOrder)
    {
        if (editOrder != null)
        {
            _service.EditOrder(editOrder);
            return Ok();
        }
        return BadRequest();
    }
    [HttpDelete("DeleteOrder")]
    [Authorize]
    public IActionResult DeleteOrder(DeleteOrderImportModel deleteOrder)
    {
        if (deleteOrder != null)
        {
            _service.DeleteOrder(deleteOrder.Id, deleteOrder.cart_Id);
            return Ok();
        }
        return BadRequest();
    }
    [HttpPut("Checkout")]
    [Authorize]
    public IActionResult Checkout(CheckoutImportModel checkout)
    {
        if (checkout != null)
        {
            _service.Checkout(checkout);
            return Ok();
        }
        return BadRequest();
    }
    [HttpPost("GetOrder")]
    [Authorize]
    public IActionResult GetOrder(int order_Id)
    {
        var order = _service.GetOrder(order_Id);
        if (order != null)
        {
            return Ok(order);
        }
        return BadRequest();
    }
    [HttpPost("GetCartOrder")]
    [Authorize]
    public IActionResult GetCartOrder(int cart_Id)
    {
        var cartorder = _service.GetCartOrder(cart_Id);
        if (cartorder != null)
        {
            return Ok();
        }
        return BadRequest();
    }

}