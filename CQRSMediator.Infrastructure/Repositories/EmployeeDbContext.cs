using CQRSMediator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CQRSMediator.Infrastructure.Repositories
{
    public class EmployeeDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Connect to PostgreSQL with connection string
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DbContext"));
            }
        }

        public DbSet<EEmployee> Employees { get; set; }
    }
}
