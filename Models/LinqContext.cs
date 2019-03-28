using System;
using Microsoft.EntityFrameworkCore;
using Rino.Models;

namespace Rino.Models
{
    public class LinqContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=172.17.0.1;Database=rino;User Id=SA;Password=<YourNewStrong!Passw0rd>;");
        }
        public DbSet<Rino.Models.software> software { get; set; }
    }
}