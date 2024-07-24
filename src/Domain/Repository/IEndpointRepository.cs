namespace Domain.Repository
{
    public interface IEndpointRepository
    {
        Task<bool> RegisterEndpoint(string idEndpoint, string idUser, string path);
    }
}
