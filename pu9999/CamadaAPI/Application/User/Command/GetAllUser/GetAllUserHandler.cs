using AutoMapper;
using Camada.Domain.Models;
using Camada.InfraStructure.Repository.interfaces.Usuarios;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CamadaAPI.Application.Users.Command.Get
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserRequest, GetAllUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;
        
        public GetAllUserHandler(IMapper mapper,IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<GetAllUserResponse> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {

            var dto = await _usersRepository.GetAllUser();
            var objToFront = _mapper.Map<List<User>>(dto);

            return new GetAllUserResponse
            {
                Success = true,
                Message = "Usuarios recuperados com sucesso",
                Usuarios = objToFront
            };
        }
    }
}
