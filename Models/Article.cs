using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AveryDennisonAPI.Models
{
    public class Article
    {
        public long Id { get; set; }
        public string ArticleNumber { get; set; }
        public double SalesPrice { get; set }
    }
}
