using Camada.InfraStructure.Repository.DTO.Usuarios;
using Camada.InfraStructure.Repository.interfaces.Usuarios;
using Camada.InfraStructure.Repository.SQL.Usuarios;
using Camada.structure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada.InfraStructure.Repository.implementations.Usuarios
{
    public sealed class UsersRepository : IUsersRepository
    {
        private readonly IDatabaseConnection _con;
        public UsersRepository(IDatabaseConnection con)
        {
            _con = con;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUser()
        {
            var response = await _con.GetAllAsync<UserDTO>(UserSQL.GET_ALL);
            return response;
        }


        public async Task<int> InsertUser(UserDTO user)
        {
            //TODO: Erro 2
            var parameter = new
            {

                NOME = user.NOME,

                SENHA = user.SENHA,

                TIPOUSUARIO = user.TIPOUSUARIO,

                ISATIVO = user.ISATIVO

            };
            var response = await _con.ExecuteAsync(UserSQL.INSERT, parameter);
            return response;
        }

        public async Task<int> DeleteUser(int id)
        {
            var parameter = new
            {
                ID = id
            };
            var response = await _con.ExecuteAsync(UserSQL.DELETE, parameter);
            return response;
        }
        

        public async  Task<int> UpdateUser(UserDTO user)
        {
            //TODO: Erro grave 1
            var parameter = new
            {
                NOME = user.NOME,
                SENHA = user.SENHA,
                TIPO_USUARIO = user.TIPOUSUARIO,
                ISATIVO = user.ISATIVO
            };
            var response = await _con.ExecuteAsync(UserSQL.UPDATE, parameter); // ARRUMAR WHERE 'GRAVE'
            return response;
        }

    }
}
