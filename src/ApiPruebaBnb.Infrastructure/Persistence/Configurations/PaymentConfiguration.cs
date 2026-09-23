using ApiPruebaBnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPruebaBnb.Infrastructure.Persistence.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");
        builder.HasKey(payment => payment.PaymentId);
        builder.Property(payment => payment.PaymentId).HasDefaultValueSql("NEWID()");
        builder.Property(payment => payment.ServiceProvider).HasMaxLength(200).IsRequired();
        builder.Property(payment => payment.Amount).HasPrecision(18, 2);
        builder.Property(payment => payment.Currency).HasMaxLength(3).IsUnicode(false).IsRequired();
        builder.Property(payment => payment.Status).HasConversion<string>()
            .HasMaxLength(20).IsUnicode(false).HasDefaultValue(PaymentStatus.pendiente);
        builder.Property(payment => payment.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");

        builder.HasIndex(payment => payment.CustomerId);
    }
}
