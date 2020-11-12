using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheThreeAmigos.Models;

namespace TheThreeAmigos.Data
{
    public class TheThreeAmigosContext : DbContext
    {
        public TheThreeAmigosContext (DbContextOptions<TheThreeAmigosContext> options)
            : base(options)
        {
        }

        public DbSet<TheThreeAmigos.Models.SuppliersModel> SuppliersModel { get; set; }
    }
}
