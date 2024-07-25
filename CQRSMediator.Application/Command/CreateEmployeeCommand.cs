﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMediator.Application.Command
{
    public record CreateEmployeeCommand(string Name, string Email) : IRequest<Guid>
    {
    }
}
