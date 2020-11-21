using System;
using System.Collections.Generic;
using System.Text;

using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;

using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class UfImplementation : BaseRepository<UfEntity>, IUfRepository
    {
        private DbSet<UfEntity> ufEntities;

        public UfImplementation(MyContext context) : base(context)
        {
            this.ufEntities = context.Set<UfEntity>();
        }
    }
}
