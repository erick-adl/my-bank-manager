using System.Threading;
using System.Threading.Tasks;

namespace MyBankManager.Infra
{
      public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken token = default);
    }
}