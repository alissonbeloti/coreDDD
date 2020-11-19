using System;
using System.Collections.Generic;
using System.Text;

using Api.Domain.Entities;

using AutoMapper;

using Domain.Dtos.User;

namespace CrossCutting.Mappings
{
    public class EntityToDtoProfile: Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();
        }
    }
}
