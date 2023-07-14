namespace TSN.Domain.DataModels;

public class UserCreateDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string PasswordConfirmation { get; set; }
    public required string Email { get; set; }
}
