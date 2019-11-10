using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApi.Controllers
{
    [Authorize]
    [Route("api/test")]
    [ApiController]
    public class TestController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        IActionResult Get()
        {
            return new JsonResult("Test");
        }
    }
}
