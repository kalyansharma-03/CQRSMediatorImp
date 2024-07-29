using CQRSMediator.Domain.Entities;
using CQRSMediator.Domain.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMediator.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeService
    {
        private readonly string _connectionString;
        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //WRITE FROM ENTITY FRAMEWORK CORE
        public async Task<Guid> CreateEmployeeAsync(EEmployee model)
        {
            using var context = new EmployeeDbContext(_connectionString);
            context.Employees.Add(model);
            await context.SaveChangesAsync();
            return model.Id;
        }

        public async Task<bool> UpdateEmployeeAsync(EEmployee model)
        {
            using var context = new EmployeeDbContext(_connectionString);
            context.Employees.Update(model);
            await context.SaveChangesAsync();
            return true;
        }


        //READ DATA FROM DB USING DAPPER
        public async Task<IEnumerable<EEmployee>> GetAllEmployeesAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryAsync<EEmployee>("SELECT * FROM EEmployee");
        }

        public async Task<EEmployee> GetEmployeeById(Guid employeeId)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM EEmployee WHERE Id = @Id";
            return await connection.QuerySingleAsync<EEmployee>(query, new { Id = employeeId });
        }
    }
}
