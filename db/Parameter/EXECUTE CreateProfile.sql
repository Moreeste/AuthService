
EXECUTE	sp_CreateProfile 
		@IdProfile = '00000000-0000-0000-0000-000000000000', 
		@Description = 'ADMIN', 
		@RegistrationUser = '00000000-0000-0000-0000-000000000000';

EXECUTE	sp_CreateProfile 
		@IdProfile = '11111111-1111-1111-1111-111111111111', 
		@Description = 'BASIC', 
		@RegistrationUser = '00000000-0000-0000-0000-000000000000';
