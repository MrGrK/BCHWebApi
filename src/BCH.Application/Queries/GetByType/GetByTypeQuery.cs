using BCH.Application.Models;
using BCH.Domain.Entities;
using BCH.Domain.Primitives;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCH.Application.Queries.GetByDateTime
{
    public record GetByTypeQuery: IRequest<IEnumerable<BCHModel>>
    {
        public BlockchainType Type { get; set; }
    }
}
