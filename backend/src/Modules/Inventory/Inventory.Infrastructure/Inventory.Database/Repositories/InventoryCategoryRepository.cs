using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory.Database.Context;
using Inventory.Database.DataModels;
using Inventory.Database.Repositories.Base;
using Inventory.Domain;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Database.Repositories;

internal class InventoryCategoryRepository(
    IDbContextFactory<InventoryDbContext> contextFactory,
    IMapper mapper) : AbstractGuidBaseRepository<InventoryCategory, InventoryCategoryDataModel, InventoryDbContext>
{
    private readonly IDbContextFactory<InventoryDbContext> _contextFactory = contextFactory;
    private readonly IMapper _mapper = mapper;

    public override async Task<InventoryCategory?> GetItemByIdAsync(Guid id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        var query = GetItemByIdQuery(id, context.InventoryCategories);

        var inventoryCategory = await query
            .ProjectTo<InventoryCategory>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return inventoryCategory;
    }

    public override async Task<bool> AddItemAsync(InventoryCategory item)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await AddItemAsync(_mapper.Map<InventoryCategoryDataModel>(item), context.InventoryCategories, context);
    }

    public override async Task<bool> UpdateItemAsync(InventoryCategory item)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        var rowsAffected = await context.InventoryCategories
            .Where(x => x.Id == item.Id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(p => p.CategoryName, item.CategoryName)
                .SetProperty(p => p.HeadInventoryCategoryId, item.HeadInventoryCategoryId)
                .SetProperty(p => p.UpdatedAt, DateTimeOffset.UtcNow));

        return rowsAffected > 0;
    }

    public override async Task<bool> DeleteItemByIdAsync(Guid id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await DeleteItemByIdAsync(id, context.InventoryCategories);
    }

    public override async Task<bool> MarkAsDeleteItemByIdAsync(Guid id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await MarkAsDeleteItemByIdAsync(id, context.InventoryCategories);
    }
}
