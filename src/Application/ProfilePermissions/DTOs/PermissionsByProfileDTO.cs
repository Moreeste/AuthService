namespace Application.ProfilePermissions.DTOs
{
    public class PermissionsByProfileDTO
    {
        public string? IdPermission { get; set; }
        public string? IdEndpoint { get; set; }
        public string? Endpoint { get; set; }
        public bool Active { get; set; }
    }
}
