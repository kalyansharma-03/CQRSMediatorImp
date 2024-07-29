using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMediator.Application.Command.UpdateEmployee
{
    public record UpdateEmployeeCommand(Guid id,string Name,string Email) : IRequest<bool>
    {
    }
}
