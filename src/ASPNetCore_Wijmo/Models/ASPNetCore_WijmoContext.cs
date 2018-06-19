using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCore_Wijmo.Models
{
    public class ASPNetCore_WijmoContext : DbContext
    {
        public ASPNetCore_WijmoContext (DbContextOptions<ASPNetCore_WijmoContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
