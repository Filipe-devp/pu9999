using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada.InfraStructure.Repository.SQL.Usuarios
{
    internal class UserSQL
    {
        internal const string GET_ALL = "SELECT * FROM USERS"; //PADRAO TB = TABELAS , SP = PROCEDURES

        internal const string INSERT = @"INSERT INTO USERS(SENHA, NOME, TIPO_USUARIO, ISATIVO, DATACRIADO, DATAMODIFICADO) VALUES (@SENHA, @NOME, @TIPOUSUARIO,  @ISATIVO, GETDATE(), NULL)";

        internal const string DELETE = @" DELETE FROM USERS WHERE ID = @ID";// query verificada

        internal const string UPDATE = @"UPDATE USERS SET NOME = @NOME , SENHA = @SENHA , TIPO_USUARIO = @TIPO_USUARIO , ISATIVO = @ISATIVO"; // ALTERAR DATA MODIFICADO
    }
}
