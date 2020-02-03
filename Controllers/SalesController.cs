using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AveryDennisonAPI.Models;

public struct revenueOfArticle
{
    public string ArticleNumber { get; set; }
    public double Revenue { get; set; }
    public revenueOfArticle(string articleNumber, double revenue)
    {
        ArticleNumber = articleNumber;
        Revenue = revenue;
    }
}

namespace AveryDennisonAPI.Controllers
{
    [Route("api/Sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SaleContext _context;

        public SalesController(SaleContext context)
        {
            _context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
        {
            return await _context.Sales.ToListAsync();
        }

        // GET: api/Sales/revenueByArticle
        [HttpGet("revenueByArticle")]
        public async Task<ActionResult<List<object>>> GetSalesByArticle()
        {
            var allSales = await _context.Sales.ToListAsync();

            List<string> articles = new List<string>();

            foreach (Sale sale in allSales)
            {
                bool alreadyExists = false;
                foreach (string article in articles)
                {
                    if (sale.ArticleNumber == article)
                    {
                        alreadyExists = true;
                    }
                }
                if (alreadyExists == false)
                {
                    articles.Add(sale.ArticleNumber);
                }
            }

            List<object> revenue = new List<object>();
            foreach (string article in articles)
            {
                double articleRevenue = 0.0;
                foreach (Sale sale in allSales)
                {
                    if(article == sale.ArticleNumber)
                    {
                        articleRevenue += sale.SalesPrice;
                    }
                }
                revenueOfArticle revenueObject = new revenueOfArticle(article, articleRevenue);
                revenue.Add(revenueObject);
            }
            return revenue;
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(long id)
        {
            var sale = await _context.Sales.FindAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }

        // GET: api/Sales/revenueByArticle/article1
        [HttpGet("revenueByArticle/{articleNumber}")]
        public async Task<ActionResult<double>> GetSales(string articleNumber)
        {
            var saleList = await _context.Sales.ToListAsync();

            var filteredSales = saleList.Where(sale => sale.ArticleNumber == articleNumber).ToList();

            var articleRev = 0.0;

            foreach (Sale sale in filteredSales)
            {
                articleRev += sale.SalesPrice;
            }

            return articleRev;
        }

        // GET: api/Sales/revenueByDate/00-00-0000
        [HttpGet("revenueByDate/{date}")]
        public async Task<ActionResult<double>> GetSales(DateTime date)
        {
            var saleList = await _context.Sales.ToListAsync();

            var filteredSales = saleList.Where(sale => sale.Date == date).ToList();

            var daysRev = 0.0;

            foreach(Sale sale in filteredSales)
            {
                daysRev += sale.SalesPrice;
            }

            return daysRev;
        }

        // GET: api/Sales/byDate/00-00-0000
        [HttpGet("salesByDate/{date}")]
        public async Task<int> GetNumberOfSales(DateTime date)
        {
            var saleList = await _context.Sales.ToListAsync();

            var filteredSales = saleList.Where(sale => sale.Date == date).ToList();

            var daysSales = saleList.Count;

            return daysSales;
        }

        // PUT: api/Sales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(long id, Sale sale)
        {
            if (id != sale.Id)
            {
                return BadRequest();
            }

            _context.Entry(sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sales
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSale), new { id = sale.Id }, sale);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sale>> DeleteSale(long id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return sale;
        }

        private bool SaleExists(long id)
        {
            return _context.Sales.Any(e => e.Id == id);
        }
    }
}
