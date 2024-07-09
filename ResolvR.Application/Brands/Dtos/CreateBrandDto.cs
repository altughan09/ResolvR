namespace ResolvR.Application.Brands.Dtos;

public class CreateBrandDto
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
    public string? WebsiteUrl { get; set; }
}