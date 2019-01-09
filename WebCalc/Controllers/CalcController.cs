using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace WebCalc.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        [HttpGet]
        public ActionResult Add(int num1, int num2)
        {
            Log.Logger.Information("Method Add({0} {1})", num1, num2);
            return Ok(num1 + num2);
        }

        [HttpGet]
        public ActionResult Div(int num1, int num2)
        {
            Log.Logger.Information("Method Div({0} {1})", num1, num2);
            return Ok(num1 / num2);
        }
    }
}
