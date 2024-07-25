using CQRSMediator.Domain.Entities;
using CQRSMediator.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMediator.Application.Command
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IEmployeeService _employeeService;
        public CreateEmployeeCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new EEmployee { Name = request.Name, Email = request.Email };
            return await _employeeService.CreateEmployeeAsync(employee);
        }
    }
}
