using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Api.Domain.Dtos.Cep;

namespace Domain.Interfaces.Services.Cep
{
    public interface ICepService
    {
        Task<CepDto> Get(Guid id);
        Task<CepDto> Get(string cep);
        Task<IEnumerable<CepDto>> GetByMunicipio(Guid municipioId);
        Task<CepDtoCreateResult> Post(CepDtoCreate cep);
        Task<CepDtoUpdateResult> Put(CepDtoUpdate cep);
        Task<IEnumerable<CepDto>> GetByLogradouroAsync(string logradouro);
        Task<bool> Delete(Guid id);
    }
}
