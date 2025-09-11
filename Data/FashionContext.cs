using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fashioninventorysystem.Models;

    public class FashionContext : DbContext
    {
        public FashionContext (DbContextOptions<FashionContext> options)
            : base(options)
        {
        }

        public DbSet<Fashioninventorysystem.Models.Product> Product { get; set; } = default!;
    }
