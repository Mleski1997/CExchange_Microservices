﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Availability.Application.Exceptions
{
    public class ResourceAlreadyExistsException : AppException
    {
        public override string Code { get; } = "resource_already_exists";
        public Guid Id { get; }

        public ResourceAlreadyExistsException(Guid id) : base($"Resource with id: {id} already exists.")
            => Id = id;
    }
}
