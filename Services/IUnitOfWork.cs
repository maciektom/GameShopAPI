namespace InternetGameShopAPI.Services
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task<int> SaveChangesAsync();
    }
}