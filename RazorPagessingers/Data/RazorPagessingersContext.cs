#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagessingers.Models;

    public class RazorPagessingersContext : DbContext
    {
        public RazorPagessingersContext (DbContextOptions<RazorPagessingersContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagessingers.Models.singers> singers { get; set; }
    }
