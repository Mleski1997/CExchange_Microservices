﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Wallets.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public User(Guid id)
        {
            Id = id;
        }
    }


}
