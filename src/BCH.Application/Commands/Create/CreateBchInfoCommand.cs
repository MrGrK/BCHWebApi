using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCH.Domain.Primitives;
using BCH.Application.Models;
using MediatR;

namespace BCH.Application.Commands.Create
{
    public class CreateBchInfoCommand : IRequest<BCHModel>
    {
        public BlockchainType Type { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
