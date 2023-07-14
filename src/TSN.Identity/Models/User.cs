using System.ComponentModel.DataAnnotations;

namespace TSN.Identity.Models;

public class User
{
    public Guid Id { get; set; }
    [StringLength(200, MinimumLength = 30)]
    public required string Name { get; set; }
    [StringLength(20, MinimumLength = 4)]
    public required string Username { get; set; }
    [EmailAddress]
    public required string Email { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? LastUpdatedDate { get; set; }
    public DateTimeOffset? LastTimeSeen { get; set; }
    [StringLength(200, MinimumLength = 30)]
    public required string Description { get; set; }
}
