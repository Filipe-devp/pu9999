using Camada.InfraStructure.Repository.DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada.InfraStructure.Repository.interfaces.Usuarios
{
    //UTILIZAR SEMPRE NO SINGULAR IUserRepository
    public interface IUsersRepository
    {
        Task<IEnumerable<UserDTO>> GetAllUser();

        Task<int> InsertUser(UserDTO user);

        Task<int> DeleteUser(int id);

        Task<int> UpdateUser(UserDTO user);
    }
}
