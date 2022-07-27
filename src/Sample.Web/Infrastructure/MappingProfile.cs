using AutoMapper;

namespace Sample.Web.Infrastructure;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BillTo, BillToViewModel>();
        CreateMap<ShipTo, ShipToViewModel>();
        CreateMap<BillToViewModel, BillTo>();
        CreateMap<ShipToViewModel, ShipTo>();
    }
}
