using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;

using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class CepImplementation : BaseRepository<CepEntity>, ICepRepository
    {
        private DbSet<CepEntity> cepEntities;

        public CepImplementation(MyContext context) : base(context)
        {
            this.cepEntities = context.Set<CepEntity>();
        }

        public async Task<CepEntity> SelectAsync(string cep)
        {
            return await this.cepEntities
                .Include(c => c.Municipio)
                .ThenInclude(m => m.Uf)
                .FirstOrDefaultAsync(c => c.Cep == cep);
        }

        public async Task<IEnumerable<CepEntity>> SelectByMunicipio(Guid id)
        {
            return await this.cepEntities
                .Include(c => c.Municipio)
                .ThenInclude(m => m.Uf)
                .Where(c => c.MunicipioId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<CepEntity>> SelectLogradouroAsync(string logradouro)
        {
            return await this.cepEntities
                .Include(c => c.Municipio)
                .ThenInclude(m => m.Uf)
                .Where(c => c.Logradouro.Contains(logradouro))
                .ToListAsync();
        }
    }
}
