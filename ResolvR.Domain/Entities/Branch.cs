using ResolvR.Domain.Primitives;
using ResolvR.Domain.Shared;
using ResolvR.Domain.ValueObjects;

namespace ResolvR.Domain.Entities;

public class Branch : Entity<Guid>
{
    private Branch(Guid id, string? name, string? email, string? phoneNumber, Address address, Guid brandId)
        : base(id)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        BrandId = brandId;
        CreatedAt = DateTime.UtcNow;
    }
    
    private Branch()
    {
    }

    public static Result<Branch> Create(string? name, string? email, string? phoneNumber, Address address, Guid brandId)
    {
        return new Branch(Guid.NewGuid(), name, email, phoneNumber, address, brandId);
    }
    
    public string? Name { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Address Address { get; private set; }
    public Guid BrandId { get; private set; }
    public List<Complaint> Complaints { get; private set; } = [];
}