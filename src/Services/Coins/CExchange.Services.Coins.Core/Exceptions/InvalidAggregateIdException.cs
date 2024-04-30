﻿using Micro.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Coins.Core.Exceptions
{
    public class InvalidAggregateIdException : CustomException
    {
        public Guid Id { get; set; }
        public InvalidAggregateIdException(Guid id) : base($"Invalid aggregate id :{id}")
        {
            Id = id;
        }
    }
}