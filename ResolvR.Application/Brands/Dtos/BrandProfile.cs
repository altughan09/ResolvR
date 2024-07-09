using AutoMapper;
using ResolvR.Application.Brands.Commands.CreateBrand;
using ResolvR.Application.Brands.Commands.UpdateBrand;
using ResolvR.Domain.Entities;

namespace ResolvR.Application.Brands.Dtos;

public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<CreateBrandCommand, Brand>();
        CreateMap<UpdateBrandCommand, Brand>();
        CreateMap<Brand, BrandDto>();
    }
}