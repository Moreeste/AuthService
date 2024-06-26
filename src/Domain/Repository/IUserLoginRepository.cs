﻿namespace Domain.Repository
{
    public interface IUserLoginRepository
    {
        Task<bool> RegisterLogin(string? idUser, DateTime loginDate, string? token, DateTime tokenExpiration, string? refreshToken, DateTime refreshTokenExpiration, bool refreshed, string? refreshedBy);
    }
}
