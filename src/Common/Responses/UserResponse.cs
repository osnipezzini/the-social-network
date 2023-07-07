namespace TSN.Common.Responses;

public record UserResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string Email { get; init; } = default!;
}
