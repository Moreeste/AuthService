namespace Application.ProfilePermissions.DTOs
{
    public class ProfilePermissionsDTO
    {
        public string? IdPermission { get; set; }
        public string? IdProfile { get; set; }
        public string? Profile { get; set; }
        public string? IdEndpoint { get; set; }
        public string? Endpoint { get; set; }
        public bool Active { get; set; }
    }
}
