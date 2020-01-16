using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBankManager.Domain.Entities;

namespace MyBankManager.Infra.EntityConfig
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(p => p.AccountId);
            builder.HasIndex(p => p.AccountId);
            builder.Property(p => p.AccountId).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Balance).IsRequired();
            builder.OwnsOne(o => o.Client, user =>
          {
              user.Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
              user.Property(p => p.Document).HasColumnName("Document").HasMaxLength(20).IsRequired();
          });
            builder.Ignore(p => p.TransactionsAccountFrom);
            builder.Ignore(p => p.TransactionsAccountTo);
        }

    }
}