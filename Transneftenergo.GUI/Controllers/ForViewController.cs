using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transneftenergo.GUI.Controllers
{
    public class ForViewController : Controller
    {
        public IActionResult DevicesIn2018()
        {
            return View();
        }

        public IActionResult ExpiredVerificationCounters()
        {
            return View();
        }

        public IActionResult ExpiredVerificationVoltageTransformers()
        {
            return View();
        }

        public IActionResult ExpiredVerificationCurrentTransformers()
        {
            return View();
        }
    }
}
