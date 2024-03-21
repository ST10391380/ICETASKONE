using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ICETASKONE.Models;


namespace ICETASKONE.Data
{
    public class ICETASKONEContext : DbContext
    {
        public ICETASKONEContext (DbContextOptions<ICETASKONEContext> options)
            : base(options)
        {
        }

        public DbSet<ICETASKONE.Models.RapMusic> RapMusic { get; set; } = default!;
    }
}
