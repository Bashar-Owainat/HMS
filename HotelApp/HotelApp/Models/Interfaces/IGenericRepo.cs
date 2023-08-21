namespace HotelApp.Models.Interfaces
{
    public interface IGenericRepo<TEntity> where TEntity : class
    {
        Task<TEntity> Insert(TEntity obj);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(object id);
        Task<TEntity> Update(object id, TEntity obj);
        Task Delete(object id);

    }
}
