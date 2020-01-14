using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyBankManager.Infra
{
    public class UnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        private DbContext _context;

        public UnitOfWork(T context) => _context = context;

        public async Task SaveChangesAsync(CancellationToken token = default) => await _context.SaveChangesAsync(token);
    }
}
