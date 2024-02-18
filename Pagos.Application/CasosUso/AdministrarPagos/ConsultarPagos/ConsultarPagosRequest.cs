using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pagos.Application.Common;

namespace Pagos.Application.CasosUso.AdministrarPagos.ConsultarPagos
{
    public class ConsultarPagosRequest: IRequest<IResult>
    {
        public string FiltroPorNombre { get; set; } 
    }
}
