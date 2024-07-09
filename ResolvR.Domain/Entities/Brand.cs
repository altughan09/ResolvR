using ResolvR.Domain.Errors;
using ResolvR.Domain.Primitives;
using ResolvR.Domain.Shared;

namespace ResolvR.Domain.Entities;

public class Brand : Entity<Guid>
{
    public Brand(Guid id, string name, string? description, string? logoUrl, string? websiteUrl)
        : base(id)
    {
        Name = name;
        Description = description;
        LogoUrl = logoUrl;
        WebsiteUrl = websiteUrl;
        CreatedAt = DateTime.UtcNow;
    }
    
    private Brand()
    {
    }
    
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string? LogoUrl { get; private set; }
    public string? WebsiteUrl { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public List<Branch> Branches { get; private set; } = [];
}