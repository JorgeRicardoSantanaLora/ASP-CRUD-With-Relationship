using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEST.Models;

namespace TEST.Models
{
    public class TM_GORICOContext : DbContext
    {
        public TM_GORICOContext(DbContextOptions<TM_GORICOContext> options)
            : base(options)
        {
        }

        public DbSet<AccAccount> Account { get; set; } = default!;
        public DbSet<TmProductVersion> TmProductVersion { get; set; } = default!;
        public DbSet<AccContact> Contact { get; set; } = default!;

    }
}