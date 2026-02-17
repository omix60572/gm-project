using Microsoft.AspNetCore.Mvc;

namespace GM.WebApi.Controllers;

[Route("api/test")]
public class TestController : BaseController
{
    [HttpGet]
    [Route("get")]
    public IActionResult GetTest() =>
        Ok(new { Message = "test" });
}
