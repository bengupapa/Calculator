using Calculator.Managers;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Initializes Index page with Calculator model
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(new CalculatorModel
            {
                Screen = ControlsManager.InitializeScreen(),
                ButtonGroups = ControlsManager.GeButtons()
            });
        }


        /// <summary>
        /// Processes input key. The key will determine either it
        /// gets appended to the expression or it calls for
        /// evaluation of the expression.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public JsonResult ProcessKey(Button button)
        {
            Response response = ControlsManager.ProcessButtonKey(button);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}