namespace Application.Auth.DTOs
{
    public sealed record ChangePasswordDTO(string CurrentPassword, string NewPassword);
}
