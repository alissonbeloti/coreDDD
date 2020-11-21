using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface ICepRepository : IRepository<CepEntity>
    {
        Task<CepEntity> SelectAsync(string cep);
        Task<IEnumerable<CepEntity>> SelectLogradouroAsync(string logradouro);
        Task<IEnumerable<CepEntity>> SelectByMunicipio(Guid id);
    }
}
