using backend.ImportModel;
using backend.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _service;
    public TicketController(ITicketService service)
    {
        _service = service;
    }
    [HttpPost("CreateTicket")]
    [Authorize]
    public IActionResult CreateTicket(CreateTicketImportModel createTicket)
    {
        if (createTicket != null)
        {
            _service.CreateTicket(createTicket);
            return Ok();
        }
        return BadRequest();
    }
    [HttpPut("EditTicket")]
    [Authorize]
    public IActionResult EditTicket(EditTicketImportModel editTicket)
    {
        if (editTicket != null)
        {
            _service.EditTicket(editTicket);
            return Ok();
        }
        return BadRequest();
    }

}