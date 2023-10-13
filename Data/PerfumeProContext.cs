using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PerfumePro.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumePro.Data
{
    public class PerfumeProContext : DbContext
    {
        public PerfumeProContext(DbContextOptions<PerfumeProContext> options)
            : base(options)
        {
        }
        public DbSet<Perfume> Perfume { get; set; }
    }
}
