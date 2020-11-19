using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;

using AutoMapper;

using Domain.Dtos.User;
using Domain.Models;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private readonly IMapper mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return this.mapper.Map<UserDto>(entity) ?? new UserDto();
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var entities = await _repository.SelectAsync();
            return this.mapper.Map<IEnumerable<UserDto>>(entities);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            var model = this.mapper.Map<UserModel>(user);
            var entity = this.mapper.Map<UserEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return this.mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            var model = this.mapper.Map<UserModel>(user);
            var entity = this.mapper.Map<UserEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return this.mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}
