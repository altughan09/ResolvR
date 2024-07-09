using AutoMapper;
using MediatR;
using ResolvR.Application.Brands.Dtos;
using ResolvR.Domain.Abstractions;
using ResolvR.Domain.Errors;
using ResolvR.Domain.Shared;

namespace ResolvR.Application.Brands.Queries.GetBrandById;

public sealed class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Result<BrandDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBrandByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<Result<BrandDto>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var brand = await _unitOfWork.BrandRepository.GetAsync(request.Id);
        
        if (brand is null)
        {
            return Result.Failure<BrandDto>(DomainErrors.Brand.NoResultFoundForGivenId);
        }
        
        var brandDto = _mapper.Map<BrandDto?>(brand);
        return brandDto;
    }
}