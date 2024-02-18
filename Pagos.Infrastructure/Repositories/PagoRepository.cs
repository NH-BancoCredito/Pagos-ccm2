using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pagos.Domain.Models;
using Pagos.Domain.Repositories;
using Pagos.Infrastructure.Repositories.Base;
using Azure;

namespace Pagos.Infrastructure.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly PagoDbContext _context;
        public PagoRepository(PagoDbContext context)
        {
            _context = context;
        }


        public async Task<bool> Adicionar(Pago entity)
        {
            try
            {
                _context.Pagos.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                 return false;
            }
        }

        public async Task<Pago> Consultar(int id)
        {
            return await _context.Pagos.FindAsync(id);
        }

        public async Task<IEnumerable<Pago>> Consultar(string nombre)
        {
            return await _context.Pagos.Where(p=>p.NombreTitular.Contains(nombre)).ToListAsync();
        }

        public Task<bool> Eliminar(Pago entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Modificar(Pago entity)
        {
            try
            {
                Pago p = await _context.Pagos.FindAsync(entity.IdPago);

                p.Monto = entity.Monto;
                p.FormaPago = entity.FormaPago;
                p.NumeroTarjeta = entity.NumeroTarjeta;
                p.FechaVencimiento = entity.FechaVencimiento;
                p.CVV = entity.CVV;
                p.NombreTitular = entity.NombreTitular;
                p.NumeroCuotas = entity.NumeroCuotas;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
