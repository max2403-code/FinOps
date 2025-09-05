namespace Common.Database.Repositories;

public interface IBaseRepository<TDomain, TDataModel>
{
    /// <summary>
    /// Получить доменную сущность по идентификатору.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<TDomain?> GetItemByIdAsync(Guid id);

    /// <summary>
    /// Добавить новую сущность в БД.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public Task<bool> AddItemAsync(TDomain item);

    /// <summary>
    /// Обновить сущность в БД.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public Task<bool> UpdateItemAsync(TDomain item);

    /// <summary>
    /// Удалить сущность из БД.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> DeleteItemByIdAsync(Guid id);

    /// <summary>
    /// Пометить сущность как удаленную.
    /// Фактически сущность остается в БД.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> MarkAsDeleteItemByIdAsync(Guid id);
}
