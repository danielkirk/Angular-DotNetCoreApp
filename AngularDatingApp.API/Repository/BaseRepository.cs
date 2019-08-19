using System.Threading.Tasks;

namespace AngularDatingApp.API.Repository
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity)
        => await _context.Set<TEntity>().AddAsync(entity);
    }
}