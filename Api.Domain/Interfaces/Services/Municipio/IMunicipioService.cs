using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Domain.Dtos.Municipio;

namespace Domain.Interfaces.Services.Municipio
{
    public interface IMunicipioService
    {
        Task<MunicipioDto> Get(Guid id);
        Task<MunicipioDtoCompleto> GetCompleteById(Guid id);
        Task<MunicipioDtoCompleto> GetCompletoByIbge(int codIbge);
        Task<IEnumerable<MunicipioDtoCompleto>> GetCompleteByUf(Guid idUf);
        Task<MunicipioDtoCreateResult> Post(MunicipioDtoCreate municipio);
        Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipio);
        Task<bool> Delete(Guid id);
    }
}
