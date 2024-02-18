using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pagos.Application.Common;
using Pagos.Domain.Repositories;
using Models = Pagos.Domain.Models;

namespace Pagos.Application.CasosUso.AdministrarPagos.RegistrarPagos
{
    public  class RegistrarPagosHandler:
        IRequestHandler<RegistrarPagosRequest, IResult>
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IMapper _mapper;
        private readonly IRandomGenerator _generator;

        private class DefaultRandom : IRandomGenerator
        {
            public int Generate(int min, int max)
            {
                return (new Random()).Next(min, max);
            }
        }

        public RegistrarPagosHandler(IPagoRepository pagoRepository, IMapper mapper)
        {
            _pagoRepository = pagoRepository;
            _mapper = mapper;
            _generator = new DefaultRandom();
        }

        public async Task<IResult> Handle(RegistrarPagosRequest request, CancellationToken cancellationToken)
        {
            IResult response = null;

            try
            {
                var pagoIns = _mapper.Map<Models.Pago>(request);

                //Simular la comunicación con la entidad bancaria, con un resultado aleatorio
                //para retornar resultados satisfactorio o con error

                var retraso = _generator.Generate(1, 11) * 1000;

                await Task.Delay(retraso);
                //await Task.Delay(6000);

                if (retraso <= 5000)
                {
                    var insertar = await _pagoRepository.Adicionar(pagoIns);

                    if (insertar)
                        return new SuccessResult();
                    else
                        return new FailureResult();

                }
                else
                    return new FailureResult();


            }
            catch (Exception ex)
            {
                return new FailureResult();
            }

        }

        public interface IRandomGenerator
        {
            int Generate(int min, int max);
        }



    }
}
