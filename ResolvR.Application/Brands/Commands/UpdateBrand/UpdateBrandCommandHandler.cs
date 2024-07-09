using AutoMapper;
using MediatR;
using ResolvR.Application.Errors;
using ResolvR.Domain.Abstractions;
using ResolvR.Domain.Errors;
using ResolvR.Domain.Shared;

namespace ResolvR.Application.Brands.Commands.UpdateBrand;

public sealed class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Result<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public UpdateBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<bool>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _unitOfWork.BrandRepository.GetAsync(request.Id);
        
        if(brand is null)
        {
            return Result.Failure<bool>(DomainErrors.Brand.NoResultFoundForGivenId);
        }
        
        _mapper.Map(request, brand);
        _unitOfWork.BrandRepository.Update(brand);
        
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;
        
        return result ? Result.Success(true) : Result.Failure<bool>(ApplicationErrors.Generic.DatabaseError);
    }
}