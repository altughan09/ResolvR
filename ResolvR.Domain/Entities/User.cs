using Microsoft.AspNetCore.Identity;

namespace ResolvR.Domain.Entities;

public class User : IdentityUser
{
    public List<Complaint> OwnedComplaints { get; set; } = [];   
}