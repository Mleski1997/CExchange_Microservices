using CExchange.Services.Users.Core.ValueObjects;
using Convey.CQRS.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Events
{
    public class SignedUp : IEvent
    {
        public Guid UserId { get; set; }
        public Email Email { get; set; }
        public Name Name { get; set; }
        public LastName LastName { get; set; }
        public Role Role { get; set; }

        public SignedUp(Guid userId, Email email, Name name, LastName lastName, Role role)
        {
            UserId = userId;
            Email = email;
            Name = name;
            LastName = lastName;
            Role = role;
        }
    }
}
