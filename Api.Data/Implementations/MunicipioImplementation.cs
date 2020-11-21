using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Repository;

using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class MunicipioImplementation : BaseRepository<MunicipioEntity>, IMunicipioRepository
    {
        private DbSet<MunicipioEntity> municipioEntities;

        public MunicipioImplementation(MyContext context) : base(context)
        {
            this.municipioEntities = context.Set<MunicipioEntity>();
        }

        public async Task<MunicipioEntity> GetMunicipioByIbge(int codigo)
        {
            return await this.municipioEntities
                .Include(m => m.Uf)
                .FirstOrDefaultAsync(m => m.CodIbge == codigo);
        }

        public async Task<MunicipioEntity> GetMunicipioById(Guid id)
        {
            return await this.municipioEntities
                .Include(m => m.Uf)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<MunicipioEntity>> GetMunicipioByUf(Guid ufId)
        {
            return await this.municipioEntities
                .Include(m => m.Uf)
                .Where(m => m.UfId == ufId)
                .ToListAsync();
        }
    }
}
