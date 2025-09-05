using Common.Database.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Database.Repositories;

/// <summary>
/// Абстрактный класс с базовым CRUD функционалом для GuidBaseDataModel.
/// </summary>
/// <typeparam name="TDomain"></typeparam>
/// <typeparam name="TDataModel"></typeparam>
/// <typeparam name="TContext"></typeparam>
public abstract class AbstractGuidBaseRepository<TDomain, TDataModel, TContext> : IBaseRepository<TDomain, TDataModel> 
    where TDataModel : GuidBaseDataModel
    where TContext : DbContext
{
    public abstract Task<bool> AddItemAsync(TDomain item);

    public abstract Task<bool> DeleteItemByIdAsync(Guid id);

    public abstract Task<TDomain?> GetItemByIdAsync(Guid id);

    public abstract Task<bool> MarkAsDeleteItemByIdAsync(Guid id);

    public abstract Task<bool> UpdateItemAsync(TDomain item);

    /// <summary>
    /// Базовый запрос для получения модели по ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="models"></param>
    /// <returns></returns>
    protected IQueryable<TDataModel> GetItemByIdQuery(Guid id, DbSet<TDataModel> models)
    {
        var query = from i in models

                    where
                        i.Id == id

                    select i;

        return query;
    }

    /// <summary>
    /// Базовый механизм добавления модели в БД.
    /// </summary>
    /// <param name="dataModel"></param>
    /// <param name="models"></param>
    /// <param name="dbContext"></param>
    /// <returns></returns>
    protected async Task<bool> AddItemAsync(TDataModel dataModel, DbSet<TDataModel> models, TContext dbContext)
    {
        await models.AddAsync(dataModel);

        if (await dbContext.SaveChangesAsync() > 0)
            return true;

        return false;
    }

    /// <summary>
    /// Базовый механизм "мягкого" удаления.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="models"></param>
    /// <returns></returns>
    protected async Task<bool> MarkAsDeleteItemByIdAsync(Guid id, DbSet<TDataModel> models)
    {
        var deletedAt = DateTimeOffset.UtcNow;

        var rowsAffected = await models
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(p => p.IsDeleted, true)
                .SetProperty(p => p.DeletedAt, deletedAt)
                .SetProperty(p => p.UpdatedAt, deletedAt));

        return rowsAffected > 0;
    }

    /// <summary>
    /// Базовый механизм удаления модели из БД.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="models"></param>
    /// <returns></returns>
    protected async Task<bool> DeleteItemByIdAsync(Guid id, DbSet<TDataModel> models)
    {
        var rowsAffected = await models
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();

        return rowsAffected > 0;
    }
}
