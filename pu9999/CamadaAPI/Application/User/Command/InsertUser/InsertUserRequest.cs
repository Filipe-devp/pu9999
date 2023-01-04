using Camada.Domain.Models;
using MediatR;

namespace CamadaAPI.Application.Users.Command.Insert
{
    public class InsertUserRequest : IRequest<InsertUserResponse>
    {
        public User User { get; set; }
    }
}
