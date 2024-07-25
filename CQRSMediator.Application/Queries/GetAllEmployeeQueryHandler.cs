using CQRSMediator.Domain.Entities;
using CQRSMediator.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMediator.Application.Queries
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<EEmployee>>
    {
        private readonly IEmployeeService _employeeService;
        public GetAllEmployeeQueryHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IEnumerable<EEmployee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _employeeService.GetAllEmployeesAsync();
        }
    }
}
