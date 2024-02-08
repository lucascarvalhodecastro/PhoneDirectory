using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Models
{
    public class PhoneBookContext : DbContext
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=PhoneDirectory100;Trusted_Connection=False;";

        public DbSet<PhoneBookEntry> Directory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
