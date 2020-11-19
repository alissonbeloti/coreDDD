using System;
using System.Collections.Generic;
using System.Text;

using Domain.Dtos.User;

namespace Api.Service.Test.Usuario
{
    public class UsuarioTestes
    {
        public static string NomeUsuario { get; set; }
        public static string EmailUsuario { get; set; }
        public static string NomeUsuarioAlterado { get; set; }
        public static string EmailUsuarioAlterado { get; set; }
        public static Guid IdUsuario { get; set; }

        public List<UserDto> userDtos = new List<UserDto>();
        public UserDto UserDto { get; set; }
        public UserDtoCreate UserDtoCreate { get; set; }
        public UserDtoCreateResult UserDtoCreateResult { get; set; }
        public UserDtoUpdate UserDtoUpdate { get; set; }
        public UserDtoUpdateResult UserDtoUpdateResult { get; set; }

        public UsuarioTestes()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Faker.Name.FullName();
            EmailUsuario = Faker.Internet.Email();
            NomeUsuarioAlterado = Faker.Name.FullName();
            EmailUsuarioAlterado = Faker.Internet.Email();
            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };
                userDtos.Add(dto);
            }

            this.UserDto = new UserDto
            {
                Id = IdUsuario,
                Email = EmailUsuario,
                Name = NomeUsuario,
            };

            this.UserDtoCreate = new UserDtoCreate
            {
                Name = NomeUsuario,
                Email = EmailUsuario
            };

            this.UserDtoCreateResult = new UserDtoCreateResult
            {
                Name = NomeUsuario,
                Email = EmailUsuario,
                Id = IdUsuario,
                CreateAt = DateTime.UtcNow
            };

            this.UserDtoUpdate = new UserDtoUpdate
            {
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
                Id = IdUsuario
            };

            this.UserDtoUpdateResult = new UserDtoUpdateResult
            {
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
                Id = IdUsuario,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}
