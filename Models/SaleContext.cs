using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AveryDennisonAPI.Models
{
    public class SaleContext : DbContext
    {
        public SaleContext(DbContextOptions<SaleContext> options)
            : base(options)
        {
        }

        public DbSet<Sale> Sales { get; set; }
    }
}
