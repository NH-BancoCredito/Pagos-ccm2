  using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = Pagos.Domain.Models;

namespace Pagos.Application.CasosUso.AdministrarPagos.RegistrarPagos
{
    public class ActualizarProductoMapper : Profile
    {
        public ActualizarProductoMapper()
        {
            CreateMap<RegistrarPagosRequest, Models.Pago>();

        }
    }
}
