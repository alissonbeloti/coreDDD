using System;
using System.Collections.Generic;
using System.Text;

using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;

using AutoMapper;

using Domain.Dtos.Municipio;
using Domain.Dtos.Uf;
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

            //Uf
            CreateMap<UfDto, UfEntity>().ReverseMap();

            //Municipio
            CreateMap<MunicipioDto, MunicipioEntity>().ReverseMap();
            CreateMap<MunicipioDtoCompleto, MunicipioEntity>().ReverseMap();
            CreateMap<MunicipioDtoCreateResult, MunicipioEntity>().ReverseMap();
            CreateMap<MunicipioDtoUpdateResult, MunicipioEntity>().ReverseMap();

            //Cep
            CreateMap<CepDto, CepEntity>().ReverseMap();
            CreateMap<CepDtoCreateResult, CepEntity>().ReverseMap();
            CreateMap<CepDtoUpdateResult, CepEntity>().ReverseMap();
        }
    }
}
