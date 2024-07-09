using MediatR;
using ResolvR.Application.Brands.Dtos;

namespace ResolvR.Application.Brands.Queries.GetAllBrands;

public sealed record GetAllBrandsQuery : IRequest<IEnumerable<BrandDto>>;