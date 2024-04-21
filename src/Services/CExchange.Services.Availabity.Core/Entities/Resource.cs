using CExchange.Services.Availabity.Core.Exceptions;
using CExchange.Services.Availabity.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availabity.Core.Entities
{
    public class Resource : AggregateRoot
    {
        private ISet<string> _tags = new HashSet<string>();
        private ISet<Reservation> _reservations = new HashSet<Reservation>();

        public IEnumerable<string> Tags
        {
            get => _tags;
            private set => _tags = new HashSet<string>(value);
        }

        public IEnumerable<Reservation> Reservations
        {
            get => _reservations;
            private set => _reservations = new HashSet<Reservation>(value);
        }

        public Resource(AggregateId id, IEnumerable<string> tags, IEnumerable<Reservation> reservations = null, int version = 0)
        {
            Id = id;
            Tags = tags;
            Reservations = reservations ?? Enumerable.Empty<Reservation>();
            Version = version;
        }

        private static void ValidateTags(IEnumerable<string> tags)
        {
            if (tags is null || !tags.Any())
            {
                throw new MissingResourceTagException();
            }

            if (tags.Any(string.IsNullOrWhiteSpace))
            {
                throw new InvalidResourceTagsException();

            }
        }

        public static Resource Create(AggregateId id, IEnumerable<string> tags, IEnumerable<Reservation> reservations = null)
        {
            var resource = new Resource(id, tags, reservations);
            resource.AddEvent(new ResourceCreated(resource));

            return resource;
        }
    }
}
