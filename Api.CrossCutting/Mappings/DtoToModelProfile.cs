
using Api.Domain.Dtos.Cep;

using AutoMapper;

using Domain.Dtos.Municipio;
using Domain.Dtos.Uf;
using Domain.Dtos.User;
using Domain.Models;

namespace CrossCutting.Mappings
{
    public class DtoToModelProfile: Profile
    {
        public DtoToModelProfile()
        {
            #region User
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserModel, UserDtoCreate>().ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();
            #endregion
            #region Uf
            CreateMap<UfModel, UfDto>().ReverseMap();
            #endregion
            #region Municipio
            CreateMap<MunicipioModel, MunicipioDto>().ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoCreate>().ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoUpdate>().ReverseMap();
            #endregion
            #region cep
            CreateMap<CepModel, CepDto>().ReverseMap();
            CreateMap<CepModel, CepDtoCreate>().ReverseMap();
            CreateMap<CepModel, CepDtoUpdate>().ReverseMap();
            #endregion
        }

    }
}
