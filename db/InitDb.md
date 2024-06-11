
# Inicializar Base de Datos

Los objetos de este proyecto están diseñados para una base de datos **SQL Server**, por lo cual debemos iniciar creando la db:

```SQL
CREATE DATABASE [AuthService];

USE [AuthService];
```

A continuación se presenta el orden sugerido de creación de los objetos:

## Tablas
Los scripts `*.sql` se encuentran en `db/Table`.
1. ApiLog
2. ErrorLog
3. UserStatus
4. Genders
5. Profiles
6. Users
7. Passwords
8. UserProperties
9. ProfilesHistory
10. UsersHistory
11. PasswordsHistory
12. UserPropertiesHistory

## Procedimientos Almacenados
Los scripts `*.sql` se encuentran en `db/Stored Procedure`.
1. sp_AddApiLog
2. sp_AddErrorLog
3. sp_GenerateProfilesHistory
4. sp_GenerateUsersHistory
5. sp_GeneratePasswordHistory
6. sp_GenerateUserPropertiesHistory
7. sp_GetGenders
8. sp_GetProfiles
9. sp_GetProfileByName
10. sp_GetProfileById
11. sp_GetUsers
12. sp_GetUserById
13. sp_GetUserByEmail
14. sp_GetUserByPhone
15. sp_GetPassword
16. sp_CreateProfile
17. sp_CreateUser
18. sp_GetUserProperties
19. sp_SetFailedAttempt
20. sp_BlockUser
21. sp_ResetFailedAttempts

## Parametría General
Los scripts `*.sql` se encuentran en `db/Parameter`.
1. INSERT UserStatus
2. INSERT Genders
3. EXECUTE CreateProfile
4. EXECUTE CreateUser

