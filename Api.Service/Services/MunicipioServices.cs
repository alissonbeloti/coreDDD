using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Api.Domain.Entities;
using Api.Domain.Repository;

using AutoMapper;

using Domain.Dtos.Municipio;
using Domain.Interfaces.Services.Municipio;
using Domain.Models;

namespace Service.Services
{
    public class MunicipioServices : IMunicipioService
    {
        private readonly IMapper mapper;
        private readonly IMunicipioRepository repository;

        public MunicipioServices(IMapper mapper, IMunicipioRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<MunicipioDto> Get(Guid id)
        {
            var entity = await this.repository.SelectAsync(id);
            return mapper.Map<MunicipioDto>(entity);
        }

        public async Task<MunicipioDtoCompleto> GetCompleteById(Guid id)
        {
            var entity = await this.repository.SelectAsync(id);
            return mapper.Map<MunicipioDtoCompleto>(entity);
        }

        public async Task<IEnumerable<MunicipioDtoCompleto>> GetCompleteByUf(Guid idUf)
        {
            var entity = await this.repository.GetMunicipioByUf(idUf);
            return mapper.Map<IEnumerable<MunicipioDtoCompleto>>(entity);
        }

        public async Task<MunicipioDtoCompleto> GetCompletoByIbge(int codIbge)
        {
            var entity = await this.repository.GetMunicipioByIbge(codIbge);
            return mapper.Map<MunicipioDtoCompleto>(entity);
        }

        public async Task<MunicipioDtoCreateResult> Post(MunicipioDtoCreate municipio)
        {
            var model = this.mapper.Map<MunicipioModel>(municipio);
            var entity = this.mapper.Map<MunicipioEntity>(model);
            var result = await this.repository.InsertAsync(entity);
            var createResult = this.mapper.Map<MunicipioDtoCreateResult>(result);
            return createResult;
        }

        public async Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipio)
        {
            var model = this.mapper.Map<MunicipioModel>(municipio);
            var entity = this.mapper.Map<MunicipioEntity>(model);
            var result = await this.repository.UpdateAsync(entity);
            var updateResult = this.mapper.Map<MunicipioDtoUpdateResult>(result);
            return updateResult;
        }
    }
}
