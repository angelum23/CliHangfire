using CliHang.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CliHang.Controller;

[ApiController]
[Route("[controller]")]
public class JobController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IServJob _servJob;
    public JobController(IServJob servJob)
    {
        _servJob = servJob;
    }

    [HttpGet("/GroupedErrors")]
    public async Task<IActionResult> GroupedErrors()
    {
        var errors = await _servJob.GroupedErrors();
        return Ok(errors);
    }
}