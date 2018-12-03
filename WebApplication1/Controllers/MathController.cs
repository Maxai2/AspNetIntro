using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class MathController : Controller
    {
        //public IActionResult Add(int num1, int num2)
        //{
        //    return new ContentResult()
        //    {
        //        Content = $"{num1} + {num2} = {num1 + num2}"
        //    }; 
        //}

        public IActionResult Add(string catchall)
        {
            string res = "";
            int sum = 0;
            var data = catchall.Split('/', StringSplitOptions.RemoveEmptyEntries);

            foreach (var num in data)
            {
                int d = Int32.Parse(num);
                res += d + " + ";
                sum += d;
            }

            res = res.Substring(0, res.Length - 2) + "= " + sum;

            return new ContentResult()
            {
                Content = res,
                ContentType = "text/plain",
                StatusCode = 200
            };
        }

        public IActionResult Substract(int num1, int num2)
        {
            return new ContentResult()
            {
                Content = $"{num1} - {num2} = {num1 - num2}"
            };
        }
    }
}