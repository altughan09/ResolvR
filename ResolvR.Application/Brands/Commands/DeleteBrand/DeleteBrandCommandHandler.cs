using MediatR;
using ResolvR.Application.Errors;
using ResolvR.Domain.Abstractions;
using ResolvR.Domain.Errors;
using ResolvR.Domain.Shared;

namespace ResolvR.Application.Brands.Commands.DeleteBrand;

public sealed class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Result<bool>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBrandCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<bool>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _unitOfWork.BrandRepository.GetAsync(request.Id);
        
        if(brand is null)
        {
            return Result.Failure<bool>(DomainErrors.Brand.NoResultFoundForGivenId);
        }
        
        _unitOfWork.BrandRepository.Delete(brand);
        
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;
        
        return result ? Result.Success(true) : Result.Failure<bool>(ApplicationErrors.Generic.DatabaseError);
    }
}