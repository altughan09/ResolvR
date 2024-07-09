using FluentValidation;
using ResolvR.Domain.Errors;

namespace ResolvR.Application.Brands.Commands.UpdateBrand;

public sealed class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(DomainErrors.Brand.NameNullOrEmpty.Message)
            .NotNull()
            .WithMessage(DomainErrors.Brand.NameNullOrEmpty.Message)
            .MaximumLength(200);

        RuleFor(x => x.LogoUrl)
            .Must(url => string.IsNullOrWhiteSpace(url) || Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage(DomainErrors.Brand.InvalidLogoUrl.Message);

        RuleFor(x => x.WebsiteUrl)
            .Must(url => string.IsNullOrWhiteSpace(url) || Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage(DomainErrors.Brand.InvalidWebsiteUrl.Message);
    }
}