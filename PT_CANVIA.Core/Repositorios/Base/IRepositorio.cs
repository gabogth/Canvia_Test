using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_CANVIA.Core.Repositorios.Base
{
    public interface IRepositorio<T> where T : class
    {
        Task<IReadOnlyList<T>> GetDatosAsync(int? nId, string cQuery);
        Task<T> GetPorIdAsync(int nId);
        Task<T> GrabarAsync(T oEntity);
        Task EliminarAsync(int nId);
    }
}
