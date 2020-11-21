using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;
using Api.Domain.Repository;

using AutoMapper;

using Domain.Interfaces.Services.Cep;
using Domain.Models;

namespace Service.Services
{
    public class CepServices : ICepService
    {
        private readonly IMapper mapper;
        private readonly ICepRepository repository;

        public CepServices(IMapper mapper, ICepRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<CepDto> Get(Guid id)
        {
            var entity = await this.repository.SelectAsync(id);
            return this.mapper.Map<CepDto>(entity);
        }

        public async Task<CepDto> Get(string cep)
        {
            var entity = await this.repository.SelectAsync(cep);
            return this.mapper.Map<CepDto>(entity);
        }

        public async Task<CepDtoCreateResult> Post(CepDtoCreate cep)
        {
            var model = this.mapper.Map<CepModel>(cep);
            var entity = this.mapper.Map<CepEntity>(model);
            var result = await this.repository.InsertAsync(entity);
            var createResult = this.mapper.Map<CepDtoCreateResult>(result);
            return createResult;
        }

        public async Task<CepDtoUpdateResult> Put(CepDtoUpdate cep)
        {
            var model = this.mapper.Map<CepModel>(cep);
            var entity = this.mapper.Map<CepEntity>(model);
            var result = await this.repository.UpdateAsync(entity);
            return this.mapper.Map<CepDtoUpdateResult>(result);
            
        }

        public async Task<IEnumerable<CepDto>> GetByMunicipio(Guid municipioId)
        {
            var entity = await this.repository.SelectByMunicipio(municipioId);
            return this.mapper.Map<IEnumerable<CepDto>>(entity);
        }

        public async Task<IEnumerable<CepDto>> GetByLogradouroAsync(string logradouro)
        {
            var entity = await this.repository.SelectLogradouroAsync(logradouro);
            return this.mapper.Map<IEnumerable<CepDto>>(entity);
        }
    }
}
