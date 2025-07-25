using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;

namespace Api.Data.Implementations
{
    public class VeiculoImplementation : BaseRepository<VeiculoEntity, Guid>, IVeiculoRepository
    {
        public VeiculoImplementation(MyContext context) : base(context)
        {
        }
    }
}