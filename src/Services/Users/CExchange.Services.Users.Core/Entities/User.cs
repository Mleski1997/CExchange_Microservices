using CExchange.Services.Users.Core.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Core.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        [EmailAddress]
        public Email Email { get; set; }
        public Name Name { get; set; }
        public LastName LastName { get; set; }
        public Role Role { get; set; }
        public Password Password { get; set; }

        public User(Guid userId, Email email, Name name, LastName lastName, Role role, Password password)
        {
            UserId = userId;
            Email = email;
            Name = name;
            LastName = lastName;
            Role = role;
            Password = password;
            
        }
    }

}
