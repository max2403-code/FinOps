using AutoMapper;
using Inventory.Database.DataModels;
using Inventory.Domain;

namespace Inventory.Database.Mappers.Profiles;

public class InventoryCategoryProfile : Profile
{
    public InventoryCategoryProfile()
    {
        CreateMap<InventoryCategoryDataModel, InventoryCategory>();

        CreateMap<InventoryCategory, InventoryCategoryDataModel>()
            .ForMember(dest => dest.HeadInventoryCategory,
                opt => opt.Ignore())
            .ForMember(dest => dest.SubInventoryCategories,
                opt => opt.Ignore())
            .ForMember(dest => dest.InventoryItems,
                opt => opt.Ignore());
    }
}
