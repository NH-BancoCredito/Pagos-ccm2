using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pagos.Domain.Models;

namespace Pagos.Domain.Repositories
{
    public  interface IPagoRepository: IRepository
    {
        Task<bool> Adicionar(Pago entity);

        Task<bool> Modificar(Pago entity);

        Task<bool> Eliminar(Pago entity);

        Task<Pago> Consultar(int id);

        Task<IEnumerable<Pago>> Consultar(string nombre);


    }
}
