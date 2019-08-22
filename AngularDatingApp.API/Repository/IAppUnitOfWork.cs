using System;
using System.Threading.Tasks;

namespace AngularDatingApp.API.Repository
{
    public interface IAppUnitOfWork : IDisposable
    {
        DataContext Context { get; }
        Task Commit();
    }
}