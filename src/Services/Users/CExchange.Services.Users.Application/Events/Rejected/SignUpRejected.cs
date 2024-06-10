using Convey.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Events.Rejected
{
    [Contract]
    public class SignUpRejected : IRejectedEvent
    {
        public string Email { get; set; }
        public string Reason { get; set; }
        public string  Code { get; set; }

        public SignUpRejected(string email, string reason, string code)
        {
           Email = email;
           Reason = reason;
           Code = code;
        }
    }
}
