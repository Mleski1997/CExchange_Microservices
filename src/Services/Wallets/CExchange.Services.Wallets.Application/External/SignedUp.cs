using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace CExchange.Services.Wallets.Application.External
{
    [Message("identity")]
    public class SignedUp : IEvent
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

        public SignedUp(Guid userId, string email, string name, string lastName, string role)
        {
            UserId = userId;
            Email = email;
            Name = name;
            LastName = lastName;
            Role = role;
        }
    }
}

