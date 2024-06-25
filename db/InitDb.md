
# Inicializar Base de Datos

Los objetos de este proyecto están diseñados para una base de datos **SQL Server**, por lo cual debemos iniciar creando la db:

```SQL
CREATE DATABASE [AuthService];

USE [AuthService];
```

A continuación se presenta el orden sugerido de creación de los objetos:

## Tablas
Los scripts `*.sql` se encuentran en `db/Table`.
- ApiLog
- ErrorLog
- UserStatus
- Genders
- Profiles
- Users
- Passwords
- UserProperties
- ProfilesHistory
- UsersHistory
- PasswordsHistory
- UserPropertiesHistory
- UserLogin

## Procedimientos Almacenados
Los scripts `*.sql` se encuentran en `db/Stored Procedure`.
- sp_AddApiLog
- sp_AddErrorLog
- sp_GenerateProfilesHistory
- sp_GenerateUsersHistory
- sp_GeneratePasswordHistory
- sp_GenerateUserPropertiesHistory
- sp_GetGenders
- sp_GetUserStatus
- sp_GetProfiles
- sp_GetProfileByName
- sp_GetProfileById
- sp_GetUsers
- sp_GetUserById
- sp_GetUserByEmail
- sp_GetUserByPhone
- sp_GetPassword
- sp_CreateProfile
- sp_CreateUser
- sp_GetUserProperties
- sp_UpdateUserPropertiesProfile
- sp_UpdateUserPropertiesStatus
- sp_SetFailedAttempt
- sp_BlockUser
- sp_ResetFailedAttempts
- sp_RegisterLogin

## Parametría General
Los scripts `*.sql` se encuentran en `db/Parameter`.
- INSERT UserStatus
- INSERT Genders
- EXECUTE CreateProfile
- EXECUTE CreateUser

