using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AveryDennisonAPI.Models
{
    public class Sale
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string ArticleNumber { get; set; }
        public double SalesPrice { get; set; }
    }
}
