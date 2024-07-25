using CQRSMediator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMediator.Domain.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EEmployee>> GetAllEmployeesAsync();
        Task<Guid> CreateEmployeeAsync(EEmployee model);
    }
}
