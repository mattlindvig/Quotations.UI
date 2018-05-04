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
            var a = new QuotesRepository();
            var b = new Quote()
            {
                Author = new Author(),
                Quotation = "test",
                CreatedDateTime = DateTimeOffset.Now,
                SourceInfo = "test",
                Users = new User()
            };
 
            var ab = a.CreateQuoteAsync(b);
            
            return View();
        }
    }
}
