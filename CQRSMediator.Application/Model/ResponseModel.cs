using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMediator.Application.Model
{
    public class ResponseModel<t>
    {
        public string Message { get; set; }
        public Status Status { get; set; }
    }
    public enum Status
    {
        Ok = 200,
        BadRequest = 400,
        Exception = 500
    }
}
