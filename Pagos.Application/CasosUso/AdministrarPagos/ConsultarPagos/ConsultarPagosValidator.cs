using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagos.Application.CasosUso.AdministrarPagos.ConsultarPagos
{
    public class ConsultarPagosValidator: AbstractValidator<ConsultarPagosRequest>
    {
        public ConsultarPagosValidator()
        {
            RuleFor(item => item.FiltroPorNombre).NotEmpty().WithMessage("Debe especificar un filtro por nombre del cliente");
        }
    }
}
