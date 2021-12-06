using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Victor_Robinson_AspNet_AT.Models;

namespace Victor_Robinson_AspNet_AT.Data
{
    public class Victor_Robinson_AspNet_ATContext : DbContext
    {
        public Victor_Robinson_AspNet_ATContext (DbContextOptions<Victor_Robinson_AspNet_ATContext> options)
            : base(options)
        {
        }

        public DbSet<Victor_Robinson_AspNet_AT.Models.Aniversariante> Aniversariante { get; set; }
    }
}
