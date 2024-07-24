using Dapper;
using Domain.Exceptions;
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

        public async Task<bool> RegisterEndpoint(string idEndpoint, string idUser, string path)
        {
            string qry = "EXECUTE sp_RegisterEndpoint @IdEndpoint, @Path, @RegistrationUser;";
            var parameters = new
            {
                IdEndpoint = idEndpoint,
                Path = path,
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
