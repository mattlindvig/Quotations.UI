using Microsoft.AspNetCore.Mvc;
using Quotations.UI.Models;
using Quotations.UI.Repositories;
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

        [HttpPost]
        public void CreateQuote(Quote model)
        {
            var a = new QuotesRepository();
            a.CreateQuoteAsync(model);
            //return null;
        }



        
    }
}
