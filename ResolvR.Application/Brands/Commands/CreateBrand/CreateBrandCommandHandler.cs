using AutoMapper;
using MediatR;
using ResolvR.Domain.Abstractions;
using ResolvR.Domain.Entities;
using ResolvR.Domain.Shared;

namespace ResolvR.Application.Brands.Commands.CreateBrand;

public sealed class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Result<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<Result<Guid>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = new Brand(Guid.NewGuid(), request.Name, request.Description, request.LogoUrl, request.WebsiteUrl);
        await _unitOfWork.BrandRepository.AddAsync(brand);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return brand.Id;
    }
}