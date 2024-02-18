using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pagos.Domain.Models;

namespace Pagos.Application.CasosUso.AdministrarPagos.ConsultarPagos
{
    public class ConsultarPagosMapper: Profile
    {
        public ConsultarPagosMapper()
        {
            CreateMap<Pago, ConsultaPago>()
                .ForMember(dest=>dest.IdPago, opt=>opt.MapFrom(src=>src.IdPago));
        }
    }
}
