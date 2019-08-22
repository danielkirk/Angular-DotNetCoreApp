using System.Threading.Tasks;

namespace AngularDatingApp.API.Repository
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        public DataContext Context { get; set; }
        public AppUnitOfWork(DataContext context)
        {
            Context = context;
        }

        public async Task Commit()
        => await Context.SaveChangesAsync();

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}