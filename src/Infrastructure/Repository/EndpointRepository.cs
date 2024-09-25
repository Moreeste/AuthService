using Dapper;
using Domain.Exceptions;
using Domain.Model.Endpoint;
using Domain.Model.Response;
using Domain.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EndpointRepository : IEndpointRepository
    {
        private readonly AuthServiceContext _authServiceContext;

        public EndpointRepository(AuthServiceContext authServiceContext)
        {
            _authServiceContext = authServiceContext;
        }

        public async Task<IEnumerable<EndpointModel>> GetEndpoints()
        {
            string qry = "EXECUTE sp_GetEndpoints;";

            var result = await _authServiceContext.Database.GetDbConnection().QueryAsync<EndpointModel>(qry);

            return result;
        }

        public async Task<EndpointModel?> GetEndpointById(string idEndpoint)
        {
            string qry = "EXECUTE sp_GetEndpointById @IdEndpoint;";
            var parameters = new
            {
                IdEndpoint = idEndpoint
            };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<EndpointModel>(qry, parameters);

            return result;
        }

        public async Task<IEnumerable<EndpointModel>> GetEndpointByPath(string path)
        {
            string qry = "EXECUTE sp_GetEndpointByPath @Path;";
            var parameters = new
            {
                Path = path
            };

            var result = await _authServiceContext.Database.GetDbConnection().QueryAsync<EndpointModel>(qry, parameters);

            return result;
        }

        public async Task<bool> RegisterEndpoint(string idEndpoint, string idUser, string path, string method, bool isPublic, bool isForEveryone)
        {
            string qry = "EXECUTE sp_RegisterEndpoint @IdEndpoint, @Method, @Path, @IsPublic, @IsForEveryone, @RegistrationUser;";
            var parameters = new
            {
                IdEndpoint = idEndpoint,
                Method = method,
                Path = path,
                IsPublic = isPublic,
                IsForEveryone = isForEveryone,
                RegistrationUser = idUser
            };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<DbResponse>(qry, parameters);

            if (result == null)
            {
                throw new DataBaseException(qry, parameters);
            }

            if (!result.Success)
            {
                throw new DataBaseException(qry, parameters, result.ErrorMessage);
            }

            return true;
        }
    }
}
