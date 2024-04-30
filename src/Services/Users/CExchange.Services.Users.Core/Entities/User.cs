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
    public class User {
        public Guid Id { get; private set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public User(Guid id, string email, string name, string lastName, string password)
        {
            Id = id;
            Email = email;
            Name = name;
            LastName = lastName;
            Password = password;
        }
    }

    
}
