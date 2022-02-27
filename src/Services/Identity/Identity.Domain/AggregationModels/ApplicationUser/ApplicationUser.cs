using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.AggregationModels.ApplicationUser;

public class ApplicationUser: IdentityUser
{
    [Required]
    public string Street { get; protected set; }
    [Required]
    public string City { get; protected set; }
    [Required]
    public string State { get; protected set; }
    [Required]
    public string Country { get; protected set; }
    [Required]
    public string ZipCode { get; protected set; }
    [Required]
    public string Name { get; protected set; }
    [Required]
    public string LastName { get; protected set; }

    [NotMapped]
    public string FullName
    {
        get => $"{Name} {LastName}";
    }

    public DateTime RegisteredAt { get; protected set; }
    public DateTime LastUpdatedAt { get; protected set; }

    /// <summary>
    /// For Entity Framework purposes
    /// </summary>
    protected ApplicationUser() {}

    public ApplicationUser()
    {
        
    }
}