using MediatR;

namespace CamadaAPI.Application.Users.Command.Delete
{
    public class DeleteUserRequest : IRequest<DeleteUserResponse>
    {
        public int Id { get; set; }
    }
}
