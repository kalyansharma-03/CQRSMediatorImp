using CQRSMediator.Domain.Entities;
using CQRSMediator.Domain.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSMediator.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(IConfiguration configuration, EmployeeDbContext context)
        {
            
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DbContext");
            _context = context;
        }

        // WRITE FROM ENTITY FRAMEWORK CORE
        public async Task<Guid> CreateEmployeeAsync(EEmployee model)
        {
            _context.Employees.Add(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }

        public async Task<bool> UpdateEmployeeAsync(EEmployee model)
        {
            _context.Employees.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }


        //READ DATA FROM DB USING DAPPER
        public async Task<IEnumerable<EEmployee>> GetAllEmployeesAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryAsync<EEmployee>("SELECT * FROM public.\"Employees\"");
        }

        public async Task<EEmployee> GetEmployeeById(Guid employeeId)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM public.\"Employees\" WHERE \"Id\" = @Id";
            return await connection.QuerySingleAsync<EEmployee>(query, new { Id = employeeId });
        }
    }
}
