using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;

using AutoMapper;

using Domain.Dtos.Uf;
using Domain.Dtos.User;
using Domain.Interfaces.Services.Uf;

namespace Service.Services
{
    public class UfServices : IUfService
    {
        private readonly IMapper mapper;
        private readonly IUfRepository repository;

        public UfServices(IMapper mapper, IUfRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<UfDto> Get(Guid id)
        {
            var entity = await this.repository.SelectAsync(id);
            return this.mapper.Map<UfDto>(entity);
        }

        public async Task<IEnumerable<UfDto>> GetAll()
        {
            var entities = await this.repository.SelectAsync();
            return this.mapper.Map<IEnumerable<UfDto>>(entities);
        }
    }
}
