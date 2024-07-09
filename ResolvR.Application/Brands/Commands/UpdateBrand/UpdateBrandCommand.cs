using MediatR;
using ResolvR.Domain.Shared;

namespace ResolvR.Application.Brands.Commands.UpdateBrand;

public sealed class UpdateBrandCommand: IRequest<Result<bool>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
    public string? WebsiteUrl { get; set; }
}