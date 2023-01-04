using AutoMapper;
using Camada.InfraStructure.Repository.DTO.Usuarios;
using Camada.InfraStructure.Repository.interfaces.Usuarios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CamadaAPI.Application.Users.Command.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IMapper _mapper;

        private readonly IUsersRepository _usersRepository;
        public UpdateUserHandler(IMapper mapper, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }
        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            if (request.user == null)
            {
                return new UpdateUserResponse()
                {
                    Success = false,
                    Message = "usuario invalido"
                };
            };


            var userDTO = _mapper.Map<UserDTO>(request.user);
            var rowsAffected = await _usersRepository.UpdateUser(userDTO);

            return new UpdateUserResponse()
            {
                Success = rowsAffected > 0,
                Message = rowsAffected > 0 ? "usuario atualizado com sucesso." : "Erro ao atualizar usuario"
            };
        }
    }
}

