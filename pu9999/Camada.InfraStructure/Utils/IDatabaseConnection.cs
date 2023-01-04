using System.Collections.Generic;
using System.Threading.Tasks;

namespace Camada.structure.Utils
{
    public interface IDatabaseConnection
    {
        Task<U> GetSingle<U>(string query, object parameter = null);

        Task<IEnumerable<U>> GetAllAsync<U>(string query, object parameter = null);

        Task<int> ExecuteAsync(string query, object parameter = null);
    }
}
