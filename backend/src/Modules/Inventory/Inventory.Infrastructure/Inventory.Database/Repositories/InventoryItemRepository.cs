using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory.Application.Abstractions.Repository;
using Inventory.Database.Context;
using Inventory.Database.DataModels;
using Inventory.Database.Repositories.Base;
using Inventory.Domain;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Database.Repositories;

internal class InventoryItemRepository(
    IDbContextFactory<InventoryDbContext> contextFactory,
    IMapper mapper) : AbstractGuidBaseRepository<InventoryItem, InventoryItemDataModel, InventoryDbContext>, IInventoryItemRepository<InventoryItem, InventoryItemDataModel>
{
    private readonly IDbContextFactory<InventoryDbContext> _contextFactory = contextFactory;
    private readonly IMapper _mapper = mapper;

    public override async Task<InventoryItem?> GetItemByIdAsync(Guid id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        var query = GetItemByIdQuery(id, context.InventoryItems);

        var inventoryItem = await query
            .ProjectTo<InventoryItem>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return inventoryItem;
    }

    public override async Task<bool> AddItemAsync(InventoryItem item)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await AddItemAsync(_mapper.Map<InventoryItemDataModel>(item), context.InventoryItems, context);
    }

    public override async Task<bool> UpdateItemAsync(InventoryItem item)
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

    public override async Task<bool> DeleteItemByIdAsync(Guid id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await DeleteItemByIdAsync(id, context.InventoryItems);
    }

    public override async Task<bool> MarkAsDeleteItemByIdAsync(Guid id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await MarkAsDeleteItemByIdAsync(id, context.InventoryItems);
    }
}
