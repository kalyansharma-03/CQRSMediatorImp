using CQRSMediator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMediator.Infrastructure.Repositories
{
    public class EmployeeDbContext : DbContext
    {
        private readonly string _connectionString;
        public EmployeeDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString); 
        }
        public DbSet<EEmployee> Employees { get; set; }
    }
}
