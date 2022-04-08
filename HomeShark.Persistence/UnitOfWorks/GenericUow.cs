using System.Threading.Tasks;
using HomeShark.Core.Contracts.UnitOfWorks;

namespace HomeShark.Persistence.UnitOfWorks
{
    public class GenericUow : IUow
    {
        private readonly HomeSharkContext _context;

        public GenericUow(HomeSharkContext context) => _context = context;

        public void Dispose() => _context.Dispose();

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
