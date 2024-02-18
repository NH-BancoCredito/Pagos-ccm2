using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagos.Application.CasosUso.AdministrarPagos.RegistrarPagos
{
    public  class RegistrarPagosValidator: AbstractValidator<RegistrarPagosRequest>
    {
        public RegistrarPagosValidator()
        {
            //El sistema solo debería procesar pagos con tarjeta de crédito
            RuleFor(item => item.FormaPago).Equal(1).WithMessage("solo se aceptan pagos con tarjeta de crédito (FormaPago = 1)");
        }
    }
}
