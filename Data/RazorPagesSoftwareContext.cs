using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesSoftware.Models;

namespace RazorPagesSoftware.Data
{
    public class RazorPagesSoftwareContext : DbContext
    {
        public RazorPagesSoftwareContext (DbContextOptions<RazorPagesSoftwareContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesSoftware.Models.Software> Software { get; set; }
    }
}
