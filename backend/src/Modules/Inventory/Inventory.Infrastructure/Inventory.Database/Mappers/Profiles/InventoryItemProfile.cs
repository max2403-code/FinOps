using AutoMapper;
using Inventory.Database.DataModels;
using Inventory.Domain;

namespace Inventory.Database.Mappers.Profiles;

public class InventoryItemProfile : Profile
{
    public InventoryItemProfile()
    {
        CreateMap<InventoryItemDataModel, InventoryItem>();

        CreateMap<InventoryItem, InventoryItemDataModel>()
            .ForMember(dest => dest.InventoryCategory,
                opt => opt.Ignore())
            .ForMember(dest => dest.InventoryDeliveries,
                opt => opt.Ignore());
    }
}
