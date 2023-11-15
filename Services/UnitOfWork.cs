using InternetGameShopAPI.Infrastructure;

namespace InternetGameShopAPI.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _databaseContext.SaveChangesAsync();
        }
        public void SaveChanges()
        {
            _databaseContext.SaveChanges();
        }
    }
}
