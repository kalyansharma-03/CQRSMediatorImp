using CQRSMediator.Domain.Entities;
using CQRSMediator.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMediator.Application.Command.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeeService _employeeService;
        public UpdateEmployeeCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = await _employeeService.GetEmployeeById(request.id);
            if (emp is null)
            {
                return false;
            }
            var model = new EEmployee()
            {
                Id = request.id,
                Email = request.Email,
                Name = request.Name,
            };
            return await _employeeService.UpdateEmployeeAsync(model);
        }
    }
}
