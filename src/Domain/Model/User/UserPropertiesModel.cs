namespace Domain.Model.User
{
    public class UserPropertiesModel
    {
        public string? IdUser { get; set; }
        public int Status { get; set; }
        public string? Profile { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? UpdateUser { get; set; }
    }
}
