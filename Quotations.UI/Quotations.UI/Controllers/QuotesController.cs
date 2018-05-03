using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotations.UI.Controllers
{
    public class QuotesController : Controller
    {
        public IActionResult CreateQuote()
        {
            return View();
        }
    }
}
