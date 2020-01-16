using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBankManager.Domain.Entities;

namespace MyBankManager.Infra.EntityConfig
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(p => p.TransactionId);
            builder.HasIndex(p => p.TransactionId);
            builder.Property(p => p.TransactionId).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.AccountFromId).IsRequired();
            builder.Property(p => p.AccountToId).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.DateAndTime).IsRequired();
            builder.Ignore(p => p.AccountFrom);
            builder.Ignore(p => p.AccountTo);

            
        }
    }
}