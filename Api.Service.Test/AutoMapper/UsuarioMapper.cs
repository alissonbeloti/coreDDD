using System;
using System.Collections.Generic;
using System.Text;

using Api.Domain.Entities;

using Domain.Dtos.User;
using Domain.Models;

using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UsuarioMapper: BaseTestService
    {
        [Fact(DisplayName = "É Possivel Mapear os Modelos")]
        public void Eh_Possivel_Mapear_Modelos()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };

            //Model => Entity
            var dtoToEntity = Mapper.Map<UserEntity>(model);
            Assert.Equal(dtoToEntity.Id, model.Id);
            Assert.Equal(dtoToEntity.Name, model.Name);
            Assert.Equal(dtoToEntity.Email, model.Email);
            Assert.Equal(dtoToEntity.CreateAt, model.CreateAt);
            Assert.Equal(dtoToEntity.UpdateAt, model.UpdateAt);
            //Entity to Dto
            var entityToDto = Mapper.Map<UserDto>(dtoToEntity);
            Assert.Equal(entityToDto.Id, dtoToEntity.Id);
            Assert.Equal(entityToDto.Name, dtoToEntity.Name);
            Assert.Equal(entityToDto.Email, dtoToEntity.Email);
            Assert.Equal(entityToDto.CreateAt, dtoToEntity.CreateAt);
        }
    }
}
