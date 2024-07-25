using CQRSMediator.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMediator.Application.Queries
{
    public class GetAllEmployeeQuery : IRequest<IEnumerable<EEmployee>>
    {
    }
}
