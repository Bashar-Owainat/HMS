namespace HotelApp.Models.Interfaces
{
    public interface IGenericRepo<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        TEntity GetById(object id);
        Task<TEntity> Insert(TEntity obj);
        TEntity Update(TEntity obj);
        void Delete(object id);

    }
}
