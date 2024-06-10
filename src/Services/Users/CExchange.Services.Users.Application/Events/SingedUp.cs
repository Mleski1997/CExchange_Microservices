using Convey.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Events
{
    [Contract]
    public class SingedUp : IEvent
    {
        public Guid UserId { get; }
        public string  Email { get; }
        public string  Role { get; }

        public SingedUp(Guid userId, string email, string role)
        {
            UserId = userId;
            Email = email;
            Role = role;         
        }
    }   
}
