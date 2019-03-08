using System;
using Microsoft.EntityFrameworkCore;

namespace Rino
{
    public class SoftwareContext : DbContext
    {
        public SoftwareContext() { }
        public SoftwareContext(DbContextOptions<SoftwareContext> options) : base(options) { }
        public DbSet<Rino.Models.software> software { get; set; }
    }
}