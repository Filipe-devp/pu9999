using AutoMapper;
using Camada.Domain.Models;
using Camada.InfraStructure.Repository.DTO.Usuarios;

namespace CamadaAPI.AutoMappings
{
    public class AutoMap : Profile
    {
        public AutoMap()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
