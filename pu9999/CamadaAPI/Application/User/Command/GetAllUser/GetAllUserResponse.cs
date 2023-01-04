using Camada.Domain.Models;
using Camada.Domain.Utils;
using Camada.InfraStructure.Repository.DTO.Usuarios;
using System.Collections.Generic;

namespace CamadaAPI.Application.Users.Command.Get
{
    public class GetAllUserResponse : BaseResponse
    {
        public List<User> Usuarios { get; set; }
    }
}
