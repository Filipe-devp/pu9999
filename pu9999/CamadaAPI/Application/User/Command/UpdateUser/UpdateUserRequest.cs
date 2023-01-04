using Camada.Domain.Models;
using MediatR;

namespace CamadaAPI.Application.Users.Command.Update
{
    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public User user { get; set; } // Propriedade comeca com CASE "User"
    }
}
