using MediatR;
using ResolvR.Domain.Shared;
using ResolvR.Domain.ValueObjects;

namespace ResolvR.Application.Branches.Commands.CreateBranch;

public sealed record CreateBranchCommand(string? Name, string? Email, string? PhoneNumber, Address Address, Guid BrandId): IRequest<Result<Guid>>;