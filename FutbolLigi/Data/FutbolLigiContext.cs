using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FutbolLigi.Models;

namespace FutbolLigi.Data
{
    public class FutbolLigiContext : DbContext
    {
        public FutbolLigiContext (DbContextOptions<FutbolLigiContext> options)
            : base(options)
        {
        }

        public DbSet<FutbolLigi.Models.PuanTablosu> PuanTablosu { get; set; }
    }
}
