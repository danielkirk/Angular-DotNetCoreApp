using Microsoft.EntityFrameworkCore;

namespace AngularDatingApp.API
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}