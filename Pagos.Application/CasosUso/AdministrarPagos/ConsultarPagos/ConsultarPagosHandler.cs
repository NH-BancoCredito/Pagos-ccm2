using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pagos.Application.Common;
using Pagos.Domain.Repositories;

namespace Pagos.Application.CasosUso.AdministrarPagos.ConsultarPagos
{
    public class ConsultarPagosHandler:
        IRequestHandler<ConsultarPagosRequest, IResult>
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IMapper _mapper;

        public ConsultarPagosHandler(IPagoRepository pagoRepository, IMapper mapper)
        {
            _pagoRepository = pagoRepository;
            _mapper = mapper;
        }
       

        public async Task<IResult> Handle(ConsultarPagosRequest request, CancellationToken cancellationToken)
        {

            IResult response = null;

            try
            {
               
                var datos = await _pagoRepository.Consultar(request.FiltroPorNombre);
                response = new SuccessResult<IEnumerable<ConsultaPago>>(
                        _mapper.Map<IEnumerable<ConsultaPago>>(datos)
                        );

                return response;
            }
            catch(Exception ex)
            {
                response = new FailureResult();
                return response;
            }
        }
    }
}
