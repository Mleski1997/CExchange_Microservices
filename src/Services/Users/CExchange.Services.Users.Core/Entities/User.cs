using CExchange.Services.Users.Core.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("email")]
        public Email Email { get; set; }

        [BsonElement("name")]
        public Name Name { get; set; }

        [BsonElement("lastName")]
        public LastName LastName { get; set; }

        [BsonElement("role")]
        public Role Role { get; set; }

        [BsonElement("password")]
        public Password Password { get; set; }

        public User(Guid id, Email email, Name name, LastName lastName, Role role, Password password)
        {
            Id = id;
            Email = email;
            Name = name;
            LastName = lastName;
            Role = role;
            Password = password;
            
        }
    }

}
