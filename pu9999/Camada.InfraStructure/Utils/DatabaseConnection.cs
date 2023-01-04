using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada.structure.Utils
{
    public sealed class DatabaseConnection : IDatabaseConnection
    // linha de importação da interface "IDatabaseConnection" interface 
    {

        private readonly IConfiguration _config;

        public DatabaseConnection(IConfiguration config)
        {// uso da classe base para criaçãp de objeto conexão (config)
            _config = config;
        }

        private SqlConnection GetConnection()
        // criação do método de conexão "pegar  a conexão(o nome dele), SqlConnection o tipo do método.."
        //
        {
            var user = _config.GetSection("ConnectionString")["UserID"];        // --> formato mais seguro de realizar a conecxão 
            var password = _config.GetSection("ConnectionString")["Password"]; // --> utilizando o arquivo já disponibilizado pelo windows para chamada de conexão 
            var server = _config.GetSection("ConnectionString")["Server"];    // -->  o appsettings.Development (o arquivo apropriado e mais seguro, já disponibilizado pelo windows)
            var database = _config.GetSection("ConnectionString")["Database"];

            // atributos do método com os respectivos valores da conexão do banco de dados (user, password, server, database, etc.. )

            return new SqlConnection($"User ID={user};Password={password};Server={server};DataBase={database}");

            // na linha acima , o tipo de retorno do método (um novo objeto com seus parãmetros recebendo os valores contidos na variaveis)
        }

        public async Task<U> GetSingle<U>(string query, object parameter = null)
        // criação do método "GetSingle, associado a uma interface do tipo "qualquer tipo que o usuario informar.. representado pelo "U", "T"
        // com os parâmetros (string query), (object parameter = null) 
        {
            using (var connection = this.GetConnection())
            // com o using eliminamos a necessidade de usar os métodos dispose, e close connection(disponibilizado e fechado na sequência..)
            // e na sequência a chamada do método GetConnection junto do this ,( há entender) sendo armazenado na variavél connection
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<U>(query, parameter);
                return result;
                // após isso temos a abertura dessa conexão   com o método open aplicado a variavel connection( connection.Open())
                // com essa conexão aberta é usado o método querysingleordefaultasync com os parametros, (query, parameter)
                // e após isso o return result;
                // linha 42 esse trecho ainda não entendi..

            }
        }
        public async Task<IEnumerable<U>> GetAllAsync<U>(string query, object parameter = null)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var result = await connection.QueryAsync<U>(query, parameter);
                return result;
            }
        }
        // acima o método para abrir a conexão

        public async Task<int> ExecuteAsync(string query, object parameter = null)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, parameter);
                return result;
            }


        }

    }

}

