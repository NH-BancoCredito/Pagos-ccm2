using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pagos.Domain.Models;

namespace Pagos.Infrastructure.Repositories.Base.EFConfigurations
{
    public class PagoEntityTypeConfiguration
	: IEntityTypeConfiguration<Pago>
	{
		public void Configure(EntityTypeBuilder<Pago> builder)
		{
			builder.ToTable("Pago");
			builder.HasKey(c => c.IdPago);
			builder.Property(c => c.Monto).HasPrecision(18,2);

        }
	}
}
