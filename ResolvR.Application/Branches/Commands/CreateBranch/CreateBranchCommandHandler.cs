using AutoMapper;
using MediatR;
using ResolvR.Domain.Abstractions;
using ResolvR.Domain.Entities;
using ResolvR.Domain.Shared;

namespace ResolvR.Application.Branches.Commands.CreateBranch;

public sealed class CreateBranchCommandHandler: IRequestHandler<CreateBranchCommand, Result<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBranchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<Result<Guid>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = new Branch(Guid.NewGuid(), request.Name, request.Email, request.PhoneNumber, request.Address, request.BrandId);
        await _unitOfWork.BranchRepository.AddAsync(branch);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return branch.Id;
    }
}