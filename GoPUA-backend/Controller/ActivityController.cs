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
    [HttpPut("DeleteActivity")]
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

}