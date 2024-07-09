using MediatR;
using ResolvR.Domain.Shared;

namespace ResolvR.Application.Brands.Commands.DeleteBrand;

public sealed record DeleteBrandCommand(Guid Id): IRequest<Result<bool>>;