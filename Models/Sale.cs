using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AveryDennisonAPI.Models
{
    public class Sale
    {
        public long Id { get; set; }
        [BsonElement("Date")]
        public DateTime Date { get; set; }
        [BsonElement("ArticleNumber")]
        public string ArticleNumber { get; set; }
        [BsonElement("SalesPrice")]
        public double SalesPrice { get; set; }

    }
}
