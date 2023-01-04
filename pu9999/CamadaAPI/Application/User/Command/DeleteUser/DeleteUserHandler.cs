using Camada.InfraStructure.Repository.interfaces.Usuarios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CamadaAPI.Application.Users.Command.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IUsersRepository _usersRepository;
        public DeleteUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                return new DeleteUserResponse()
                {
                    Success = false,
                    Message = "Usuario inválido.!"
                };
            };
            var rowsAffected = await _usersRepository.DeleteUser(request.Id);
            return new DeleteUserResponse()
            {
                Success = rowsAffected > 0 ? true : false,
                Message = rowsAffected > 0 ? $"Usuario {request.Id} removido com sucesso" : $" erro ao remover usuario {request.Id}"
            };
        }
    }
}
