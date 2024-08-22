using backend.ImportModel;
using backend.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private readonly IActivityService _service;
    public ActivityController(IActivityService service)
    {
        _service = service;
    }
    [HttpPost("CreateActivity")]
    [Authorize]
    public IActionResult CreateActivity(CreateActivityImportModel createActivity)
    {
        if (createActivity != null)
        {
            _service.CreateActivity(createActivity);
            return Ok();
        }
        return BadRequest();
    }
    [HttpPut("EditActivity")]
    [Authorize]
    public IActionResult EditActivity(EditActivityImportModel editActivity)
    {
        if (editActivity != null)
        {
            _service.EditActivity(editActivity);
            return Ok();
        }
        return BadRequest();
    }
    [HttpDelete("DeleteActivity")]
    [Authorize]
    public IActionResult DeleteActivity(DeleteActivityImportModel deleteActivity)
    {
        if (deleteActivity != null)
        {
            _service.DeleteActivity(deleteActivity);
            return Ok();
        }
        return BadRequest();
    }
    [HttpGet("GetAllActivity")]
    [Authorize]
    public IActionResult GetAllActivity()
    {
        var allactivity = _service.GetAllActivity();
        if (allactivity != null)
        {
            return Ok(allactivity);
        }
        return BadRequest();
    }
    [HttpPost("GetActivity")]
    [Authorize]
    public IActionResult GetActivity(int activity_Id)
    {
        var activity = _service.GetActivity(activity_Id);
        if (activity != null)
        {
            return Ok(activity);
        }
        return BadRequest();
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
    [HttpDelete("DeleteTicket")]
    [Authorize]
    public IActionResult DeleteTicket(DeleteTicketImportModel deleteTicket)
    {
        if (deleteTicket != null)
        {
            _service.DeleteTicket(deleteTicket.Id, deleteTicket.activity_Id);
            return Ok();
        }
        return BadRequest();
    }
    [HttpPost("GetTicket")]
    [Authorize]
    public IActionResult GetTicket(int ticket_Id)
    {
        var ticket = _service.GetTicket(ticket_Id);
        if (ticket != null)
        {
            return Ok(ticket);
        }
        return BadRequest();
    }
    [HttpPost("GetActivityTicket")]
    [Authorize]
    public IActionResult GetActivityTicket(int activity_Id)
    {
        var ticket = _service.GetActivityTicket(activity_Id);
        if (ticket != null)
        {
            return Ok(ticket);
        }
        return BadRequest();
    }
}