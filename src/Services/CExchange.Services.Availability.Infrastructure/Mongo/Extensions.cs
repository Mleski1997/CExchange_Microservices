using CExchange.Services.Availability.Application.DTO;
using CExchange.Services.Availability.Core.Entities;
using CExchange.Services.Availability.Core.ValueObjects;
using CExchange.Services.Availability.Infrastructure.Mongo.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availability.Infrastructure.Mongo
{
    internal static class Extensions
    {
        public static Resource AsEntity(this ResourceDocument document)
            => new Resource(document.Id, document.Tags, document.Reservations.Select(r => new Reservation(r.TimeStamp.AsDateTime(), r.Priority)));

        public static ResourceDocument AsDocument(this Resource resource) => new ResourceDocument
        {
            Id = resource.Id,
            Version = resource.Version,
            Tags = resource.Tags,
            Reservations = resource.Reservations.Select(r => new ReservationDocument
            {
                TimeStamp = r.DateTime.AsDaysSinceEpoch(),
                Priority = r.Priority,
            })
        };

        public static ResourceDto AsDto(this ResourceDocument document)
            => new ResourceDto
            {
                Id = document.Id,
                Tags = document.Tags ?? Enumerable.Empty<string>(),
                Reservation = document.Reservations?.Select(r => new ReservationDto
                {
                    DateTime = r.TimeStamp.AsDateTime(),
                    Priority = r.Priority,
                }) ?? Enumerable.Empty<ReservationDto>()
            };
        internal static int AsDaysSinceEpoch(this DateTime dateTime)
            => (dateTime - new DateTime()).Days;

        internal static DateTime AsDateTime(this int daysSinceEpoch)
            => new DateTime().AddDays(daysSinceEpoch);
    }
}
