using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IMunicipioRepository: IRepository<MunicipioEntity>
    {
        Task<MunicipioEntity> GetMunicipioById(Guid id);
        Task<MunicipioEntity> GetMunicipioByIbge(int codigo);
        Task<IEnumerable<MunicipioEntity>> GetMunicipioByUf(Guid ufId);
    }
}
