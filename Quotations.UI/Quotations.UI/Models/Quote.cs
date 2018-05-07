using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quotations.UI.Models
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public Author Author { get; set; }
        [DataType(DataType.MultilineText)]
        public string Quotation { get; set; }
        public User Users { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string SourceInfo { get; set; }

    }
}
