using AutoMapper;
using MediatR;
using ResolvR.Application.Brands.Dtos;
using ResolvR.Domain.Abstractions;

namespace ResolvR.Application.Brands.Queries.GetAllBrands;

public sealed class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, IEnumerable<BrandDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllBrandsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await _unitOfWork.BrandRepository.GetAllAsync();
        var brandsDto = _mapper.Map<IEnumerable<BrandDto>>(brands);
        return brandsDto;
    }
}