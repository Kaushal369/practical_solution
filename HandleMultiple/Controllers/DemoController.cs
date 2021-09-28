using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandleMultiple.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Calculation()
        {
            float num1=0;
            float num2=0;
            try
            {
                 num1 = float.Parse(Request["Num1"]);

                num2 = float.Parse(Request["Num2"]);

                float result = 0;

                if (Request["Command"] == "Add")
                    result = num1 + num2;
                else if (Request["Command"] == "Sub")
                    result = num1 - num2;

                else if (Request["Command"] == "Mul")
                    result = num1 * num2;

                else if (Request["Command"] == "Div")
                {
                    if (num2 == 0)
                        throw new DivideByZeroException("You Cann't divide by zero");
                    result = num1 / num2;
                }
                    

                ViewBag.results = result.ToString();
            }
            catch (Exception ex)
            {
               
                    throw;
            }  
            
            return View("~/Views/Demo/Index.cshtml");
        }
    }
}