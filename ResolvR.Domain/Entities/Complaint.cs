using ResolvR.Domain.Errors;
using ResolvR.Domain.Primitives;
using ResolvR.Domain.Shared;

namespace ResolvR.Domain.Entities;

public class Complaint : Entity<Guid>
{
    private Complaint(string title, string description, Guid branchId)
    {
        Title = title;
        Description = description;
        BranchId = branchId;
        CreatedAt = DateTime.UtcNow;
    }

    private Complaint()
    {
    }
    
    public static Result<Complaint> Create(string title, string description, Guid branchId)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result.Failure<Complaint>(DomainErrors.Complaint.TitleNullOrEmpty);
        }
        
        if(string.IsNullOrWhiteSpace(description))
        {
            return Result.Failure<Complaint>(DomainErrors.Complaint.DescriptionNullOrEmpty);
        }
        
        return new Complaint(title, description, branchId);
    }
    
    public void SetBranch(Guid branchId)
    {
        BranchId = branchId;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Resolve(string? resolution)
    {
        Resolution = resolution;
        IsResolved = true;
        ResolvedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public string Title { get; private set; }
    public string Description { get; private set; }
    
    public string? Resolution { get; private set; }
    public bool IsResolved { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? ResolvedAt { get; private set; }
    public Guid BranchId { get; private set; }
}