using BCH.Application.Models;
using BCH.Domain.Primitives;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCH.Application.Queries.GetAll
{
    public class GetAllQuery : IRequest<IEnumerable<BCHModel>>
    {
    }
}
