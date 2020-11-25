using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheThreeAmigos.Models;

namespace SuppliersMicroservice.Data
{
    public class SuppliersMicroserviceContext : DbContext
    {
        public SuppliersMicroserviceContext (DbContextOptions<SuppliersMicroserviceContext> options)
            : base(options)
        {
        }

        public DbSet<TheThreeAmigos.Models.SuppliersModel> SuppliersModel { get; set; }
    }
}
