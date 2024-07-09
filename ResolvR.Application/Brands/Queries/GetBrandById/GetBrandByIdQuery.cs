using MediatR;
using ResolvR.Application.Brands.Dtos;
using ResolvR.Domain.Shared;

namespace ResolvR.Application.Brands.Queries.GetBrandById;

public sealed record GetBrandByIdQuery(Guid Id) : IRequest<Result<BrandDto>>;