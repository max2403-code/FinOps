using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Database.Repositories;
using Inventory.Database.Context;
using Inventory.Database.DataModels;
using Inventory.Domain;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Database.Repositories;

internal class InventoryItemRepository(
    IDbContextFactory<InventoryDbContext> contextFactory,
    IMapper mapper) : IBaseRepository<InventoryItem, InventoryItemDataModel>
{
    private readonly IDbContextFactory<InventoryDbContext> _contextFactory = contextFactory;
    private readonly IMapper _mapper = mapper;

    /// <inheritdoc/>
    public async Task<InventoryItem?> GetItemByIdAsync(Guid id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        var query = from i in context.InventoryItems

                    where
                        i.Id == id

                    select i;

        var inventoryItem = await query
            .ProjectTo<InventoryItem>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return inventoryItem;
    }

    /// <inheritdoc/>
    public async Task<bool> AddItemAsync(InventoryItem item)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        await context.InventoryItems.AddAsync(_mapper.Map<InventoryItemDataModel>(item));

        if (await context.SaveChangesAsync() > 0)
            return true;

        return false;
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateItemAsync(InventoryItem item)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        var rowsAffected = await context.InventoryItems
            .Where(x => x.Id == item.Id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(p => p.Name, item.Name)
                .SetProperty(p => p.InventoryCategoryId, item.InventoryCategoryId)
                .SetProperty(p => p.UpdatedAt, DateTimeOffset.UtcNow));

        return rowsAffected > 0;
    }

    /// <inheritdoc/>
    public async Task<bool> MarkAsDeleteItemByIdAsync(Guid id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        var deletedAt = DateTimeOffset.UtcNow;

        var rowsAffected = await context.InventoryItems
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(p => p.IsDeleted, true)
                .SetProperty(p => p.DeletedAt, deletedAt)
                .SetProperty(p => p.UpdatedAt, deletedAt));

        return rowsAffected > 0;
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteItemByIdAsync(Guid id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        var rowsAffected = await context.InventoryItems
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();

        return rowsAffected > 0;
    }
}
