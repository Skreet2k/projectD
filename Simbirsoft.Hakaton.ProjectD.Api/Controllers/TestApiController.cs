using Microsoft.AspNetCore.Mvc;

namespace Simbirsoft.Hakaton.ProjectD.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestApiController: ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<object>> Get()
    {
        return new {Property = "value"};
    }
}