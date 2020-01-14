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
            builder.HasOne(p => p.Account).WithMany(p => p.Transactions).HasForeignKey(p => p.AccountId).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Amount).IsRequired();
            
        }
    }
}