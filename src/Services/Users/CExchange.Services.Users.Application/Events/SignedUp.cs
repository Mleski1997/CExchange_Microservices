using Convey.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Events
{
    [Contract]
    public class SignedUp : IEvent
    {
        public Guid Id { get; }
        public string  Email { get; }
        public string Name { get; }
        public string LastName { get; set; }

        public SignedUp(Guid id, string email, string name, string lastName)
        {
            Id = id;
            Email = email;
            Name = name;
            LastName = lastName;
        }
    }   
}
