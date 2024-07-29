using CQRSMediator.Domain.Entities;
using CQRSMediator.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMediator.Application.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EEmployee>
    {
        private readonly IEmployeeService _employeeService;
        public GetEmployeeByIdQueryHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<EEmployee> Handle(GetEmployeeByIdQuery request,CancellationToken cancellationToken)
        {
            return await _employeeService.GetEmployeeById(request.employeeId);
        }
    }
}
