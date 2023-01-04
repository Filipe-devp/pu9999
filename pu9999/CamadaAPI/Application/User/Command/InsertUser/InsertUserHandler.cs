using AutoMapper;
using Camada.InfraStructure.Repository.DTO.Usuarios;
using Camada.InfraStructure.Repository.interfaces.Usuarios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CamadaAPI.Application.Users.Command.Insert
{
    public class InsertUserHandler : IRequestHandler<InsertUserRequest, InsertUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public InsertUserHandler(IMapper mapper, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }
        public async Task<InsertUserResponse> Handle(InsertUserRequest request, CancellationToken cancellationToken)
        {
            if (request.User == null)
            {
                return new InsertUserResponse()
                {
                    Success = false,
                    Message = "Usuario não inseirido" // ARRUMAR PARA USUARIO INVALIDO.
                };
            };

            var userDTO = _mapper.Map<UserDTO>(request.User);
            var rowsAffected = await _usersRepository.InsertUser(userDTO);

            return new InsertUserResponse()
            {
                Success = rowsAffected > 0 ? true : false,
                Message = rowsAffected > 0 ? "usuario inserido com sucesso" : "Erro ao inserir usuario"
            };

        }

    }
}
