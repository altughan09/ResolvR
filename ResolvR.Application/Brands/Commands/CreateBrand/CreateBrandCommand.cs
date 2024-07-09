using MediatR;
using ResolvR.Domain.Shared;

namespace ResolvR.Application.Brands.Commands.CreateBrand;

public sealed record CreateBrandCommand(string Name, string? Description, string? LogoUrl, string? WebsiteUrl): IRequest<Result<Guid>>;