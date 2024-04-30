using CExchange.Services.Users.Application.DTO;
using Convey.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExchange.Services.Users.Application.Queries
{
    public class GetUsers : IQuery<IEnumerable<UserDto>>
    {
    }
}
