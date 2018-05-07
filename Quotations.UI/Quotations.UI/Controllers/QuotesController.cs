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

        public IActionResult ShowQuotes()
        {
            var a = new QuotesRepository();
            
            return View(a.GetQuoteAsync());
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
