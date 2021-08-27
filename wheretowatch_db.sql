IF EXISTS(SELECT 1
          FROM   master.dbo.sysdatabases
          WHERE  Name = 'wheretowatch_db')
  BEGIN
      DROP DATABASE wheretowatch_db
      PRINT '' PRINT '*** Dropping Database wheretowatch_db ***'
  END
GO

PRINT '' PRINT '*** creating wheretowatch_db ***'
GO
CREATE DATABASE wheretowatch_db
GO

PRINT '' PRINT '*** Using wheretowatch_db ***'
GO
USE wheretowatch_db
GO

PRINT '' PRINT '*** creating User Table ***'
GO
CREATE TABLE [dbo].[user]
  (
     [UserID]       [INT] IDENTITY(1000000, 1) NOT NULL,
     [UserName]     [NVARCHAR](50) NOT NULL,
	 [Name]			[NVARCHAR](30) NOT NULL,
     [Email]        [NVARCHAR](250) NOT NULL,
     [PasswordHash] [NVARCHAR](100) NOT NULL DEFAULT '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
     [active]       [BIT] 			NOT NULL DEFAULT 1,
     CONSTRAINT [pk_userID] PRIMARY KEY ([UserID] ASC),
     CONSTRAINT [ak_Email] UNIQUE([Email] ASC)
  )
GO

/*CREATE INDEX [UserIDs] ON User ([UserID]);
CREATE INDEX [Emails] ON User ([Email]);*/

print '' print '*** creating User Test Records ***'
GO
INSERT INTO [dbo].[user]
		([UserName], [Name], [Email])
	VALUES
		('userOne', 'zach', 'zach@company.com'),
		('userTwo', 'jacob', 'jacob@company.com'),
		('userThree', 'jack', 'jack@company.com'),
		('userFour', 'tommy', 'tommy@company.com'),
		('userFive', 'ryan', 'ryan@company.com')
GO

PRINT '' PRINT '*** creating Role Table ***'
GO
CREATE TABLE [dbo].[Role]
  (
     [RoleID]      [NVARCHAR](25) NOT NULL,
     [Description] [NVARCHAR](250),
     CONSTRAINT [pk_roleID] PRIMARY KEY ([RoleID] ASC)
  )
GO

print '' print '*** creating role test records ***'
GO
INSERT INTO [dbo].[Role]
		([RoleID], [Description])
	VALUES
		('Admin', 'User administration'),
		('User', 'Regular User')
GO

print '' print '*** creating User Role Table ***'
GO
CREATE TABLE [dbo].[UserRole](
	[UserID]		[int]	NOT NULL,
	[RoleID]		[nvarchar](25)	NOT NULL,
	CONSTRAINT [pk_userID_roleID] PRIMARY KEY([UserID], [RoleID]),
	CONSTRAINT [fk_userID] FOREIGN KEY([UserID])
		REFERENCES [dbo].[User]([UserID])
)
GO


print '' print '*** adding roleID foreign key to user role table ***'
GO
ALTER TABLE [dbo].[UserRole] WITH NOCHECK
	ADD CONSTRAINT [fk_roleID] FOREIGN KEY([RoleID])
		REFERENCES [dbo].[Role]([RoleID])
		ON UPDATE CASCADE
GO

print '' print '*** adding sample user role records ***'
GO
INSERT INTO [dbo].[UserRole]
		([UserID], [RoleID])
	VALUES
		(1000000, 'Admin'),
		(1000000, 'User')
GO

CREATE INDEX [SortByRoleID]
  ON Role ([RoleID]);

print '' print '*** USER STORED PROCEDURES ***'
GO
print '' print '*** creating sp_authenticate_user ***'
GO
CREATE PROCEDURE [dbo].[sp_authenticate_user]
	(
	@Email				[nvarchar](100),
	@PasswordHash		[nvarchar](100)
	)
AS
	BEGIN
		SELECT COUNT(Email)
		FROM [User]
		WHERE Email = @Email
		  AND PasswordHash = @PasswordHash
		  AND Active = 1
	END
GO

print '' print '*** creating sp_update_passwordHash ***'
GO
CREATE PROCEDURE [dbo].[sp_update_passwordHash]
	(
		@Email				[nvarchar](100),
		@OldPasswordHash	[nvarchar](100),
		@NewPasswordHash	[nvarchar](100)
	)
AS
	BEGIN
		UPDATE [User]
			SET PasswordHash = @NewPasswordHash
			WHERE Email = @Email
			  AND PasswordHash = @OldPasswordHash
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** creating sp_select_user_by_email ***'
GO
CREATE PROCEDURE [dbo].[sp_select_user_by_email]
	(
		@Email				[nvarchar](100)
	)
AS
	BEGIN
		SELECT UserID, UserName, Name, Email, Active
		FROM [User]
		WHERE Email = @Email
	END
GO

print '' print '*** creating sp_select_userroles_by_userid ***'
GO
CREATE PROCEDURE [dbo].[sp_select_userroles_by_userid]
	(
		@UserID				[int]
	)
AS
	BEGIN
		SELECT RoleID
		FROM UserRole
		WHERE UserID = @UserID
	END
GO

print '' print '*** creating sp_update_user_profile_data ***'
GO
CREATE PROCEDURE [dbo].[sp_update_user_profile_data]
	(
		@UserID			[int],
		@OldUserName	[nvarchar](50),
		@OldName		[nvarchar](30),
	    @OldEmail		[nvarchar](30),
		@NewUserName	[nvarchar](50),
		@NewName		[nvarchar](30),
	    @NewEmail		[nvarchar](30)
	)
AS
	BEGIN
		UPDATE [User]
			SET UserName = @NewUserName,
				Email = @NewEmail,
				Name = @NewName
			WHERE UserID = @UserID
			AND UserName = @OldUserName
			AND	Email = @OldEmail
			AND Name = @OldName
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** USER STORED PROCEDURES FOR ADMINS ***'
GO
print '' print '*** creating sp_insert_new_user ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_new_user]
	(
	    @UserName	[nvarchar](50),	
		@Name		[nvarchar](30),
        @Email		[nvarchar](250)		
	)
AS
	BEGIN
		INSERT INTO [User] 
			(UserName, Name, Email)
		VALUES
			(@UserName, @Name, @Email)
		SELECT SCOPE_IDENTITY()
	END
GO

print '' print '*** creating sp_select_all_users ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_users]
AS
	BEGIN
		SELECT		UserID, UserName, Name, Email, Active
		FROM		[User]  
		ORDER BY 	Name ASC
	END
GO

print '' print '*** creating sp_select_users_by_active ***'
GO
CREATE PROCEDURE [dbo].[sp_select_users_by_active]
	(
		@Active		[bit]
	)
AS
	BEGIN
		SELECT		UserID, UserName, Name, Email, Active
		FROM		[User]  
		WHERE		Active = @Active
		ORDER BY 	Name ASC
	END
GO

print '' print '*** creating sp_select_user_by_id ***'
GO
CREATE PROCEDURE [dbo].[sp_select_user_by_id]
	(
		@UserID		[int]
	)
AS
	BEGIN
		SELECT		UserID, Email, UserName, Name, Email, Active
		FROM		[User]  
		WHERE		UserID = @UserID
	END
GO

print '' print '*** creating sp_reset_passwordhash ***'
GO
CREATE PROCEDURE [dbo].[sp_reset_passwordhash]
	(
		@Email			[nvarchar](100)
	)
AS
	BEGIN
		UPDATE [User]
			SET PasswordHash = '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E'
			WHERE Email = @Email
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** creating sp_safely_deactivate_user ***'
GO
CREATE PROCEDURE [dbo].[sp_safely_deactivate_user]
	(
		@UserID			[int]
	)
AS
	BEGIN
		DECLARE @Admins int
		
		SELECT @Admins = COUNT(RoleID)
		FROM UserRole
		WHERE RoleID = 'Admin'
		  AND UserRole.UserID = @UserID
		  
		IF @Admins = 1
			BEGIN
				RETURN 0
			END
		ELSE
			BEGIN
				UPDATE [User]
					SET Active = 0
					WHERE [User].UserID = @UserID
				RETURN @@ROWCOUNT
			END
	END
GO
	
print '' print '*** creating sp_reactivate_user ***'
GO
CREATE PROCEDURE [dbo].[sp_reactivate_user]
	(
		@UserID			[int]
	)
AS
	BEGIN
		UPDATE [User]
			SET Active = 1
			WHERE UserID = @UserID
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** creating sp_add_userrole ***'
GO
CREATE PROCEDURE [dbo].[sp_add_userrole]
	(
		@UserID				[int],
		@RoleID				[nvarchar](25)
	)
AS
	BEGIN
		INSERT INTO UserRole
				([UserID], [RoleID])
			VALUES
				(@UserID, @RoleID)
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** creating sp_safely_remove_usererole ***'
GO
CREATE PROCEDURE [dbo].[sp_safely_remove_usererole]
	(
		@UserID				[int],
		@RoleID				[nvarchar](25)
	)
AS
	BEGIN
		DECLARE @Admins int
	
		SELECT @Admins = COUNT(RoleID)
		FROM UserRole
		WHERE RoleID = 'Admin'
	
		IF @RoleID = 'Admin' AND @Admins = 1
			BEGIN
				RETURN 0
			END
		ELSE
			BEGIN
				DELETE FROM UserRole
					WHERE UserID = @UserID
					  AND RoleID = @RoleID
				RETURN @@ROWCOUNT
			END
	END
GO

print '' print '*** creating sp_select_all_userroles ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_userroles]
AS
	BEGIN
		SELECT RoleID
		FROM Role
		ORDER BY RoleID ASC
	END
GO

PRINT '' PRINT '*** creating Movie Table ***'
GO
CREATE TABLE [dbo].[movie]
  (
     [accountstates]       [VARBINARY],
     [adult]               [INT] NOT NULL DEFAULT '0',
     [alternativetitles]   [INT],
     [backdroppath]        [INT],
     [belongstocollection] [INT],
     [budget]              [FLOAT],
     [changes]             [VARBINARY],
     [credits]             [VARBINARY],
     [genres]              [VARBINARY] NOT NULL,
     [homepage]            [NVARCHAR](70),
     [images]              [VARBINARY],
     [imdbid]              [NVARCHAR](30),
     [keywords]            [VARBINARY],
     [lists]               [VARBINARY],
     [movieid]             [INT] IDENTITY(1000000, 1) NOT NULL,
     [originallanguage]    [NVARCHAR](6),
     [OriginalTitle]       [NVARCHAR](35),
     [overview]            [NVARCHAR](600),
     [popularity]          [FLOAT] NOT NULL,
     [posterpath]          [NVARCHAR](70),
     [productioncompanies] [VARBINARY],
     [productioncountries] [NVARCHAR](250),
     [recommendations]     [VARBINARY],
     [releasedate]         DATETIME2(0) NOT NULL,
     [releasedates]        [VARBINARY],
     [releases]            [VARBINARY],
     [revenue]             [FLOAT],
     [reviews]             [VARBINARY],
     [runtime]             [INT] NOT NULL,
     [similar]             [VARBINARY],
     [spokenlanguages]     [NVARCHAR](150),
     [status]              [NVARCHAR](20) NOT NULL,
	 [streamonlogo]		   [VARBINARY],
	 [streamon]		       [NVARCHAR](70),
     [tagline]             [NVARCHAR](100),
     [title]               [NVARCHAR](50) NOT NULL,
	 [trailer]             [NVARCHAR](70),
     [translations]        [VARBINARY],
     [video]               [BIT],
     [videos]              [VARBINARY],
     [voteaverage]         [FLOAT] NOT NULL,
     [votecount]           [INT] NOT NULL,
     CONSTRAINT [pk_movieID] PRIMARY KEY ([movieid] ASC)
  )
GO

print '' print '*** creating Movie Test Record ***'
GO
INSERT INTO [dbo].[user]
		([accountstates],[adult],[alternativetitles],[backdroppath],[belongstocollection],
		[budget],[changes],[credits],[genres],[homepage],[images],[imdbid],[keywords],[lists],              
		[movieid],[originallanguage],[OriginalTitle], [overview], [popularity],[posterpath],         
		[productioncompanies],[productioncountries],[recommendations],[releasedate],        
		[releasedates],[releases],[revenue],[reviews],[runtime],[similar],[spokenlanguages],    
		[status],[streamonlogo],[streamon],[tagline],[title],[trailer],[translations],[video],[videos],[voteaverage],[votecount])
	VALUES
		('false', null, '/cxCvrjsrx557XCaydyNogHDvgyw.jpg', null, 10000000, null,
		null, null, 'Comedy', '', 11017, null, 'tt0112508', null, null, 'en', 
		'Billy Madison', 'Billy Madison is the 27 year-old son of Bryan Madison, a very rich man who has made his living in the hotel industry. Billy stands to inherit his fathers empire but only if he can make it through all 12 grades, 2 weeks per grade, to prove that he has what it takes to run the family business.'
		13.416, '/sOdgtJdFalL9kRKaeJItARLTAEq.jpg', null, 'US', null, 
		{2/10/1995 12:00:00 AM}, null, 26488734, null, 89, null, SpokenLanguages,
		'Released', null, null,'Billy is going back to school... Way back.', 'Billy Madison',null,
		null, false, null, 6.2, 1079)
GO

CREATE INDEX [SortByAdult]
  ON movie ([adult]);

CREATE INDEX [SortByGenre]
  ON movie ([genres]);

CREATE INDEX [SortByMovieId]
  ON movie ([movieid]);

CREATE INDEX [SortByPopularity]
  ON movie ([popularity]);

CREATE INDEX [SortByReleaseDate]
  ON movie ([releasedate]);

CREATE INDEX [SortByRuntime]
  ON movie ([runtime]);

CREATE INDEX [SortByTitle]
  ON movie ([title]);

CREATE INDEX [SortByVoteAverage]
  ON movie ([voteaverage]);

CREATE INDEX [SortByVoteCount]
  ON movie ([votecount]);

PRINT '' PRINT '*** creating TVShow Table ***'
GO
CREATE TABLE [dbo].[tvshow]
  (
     [backdroppath]        [NVARCHAR](70),
     [createdby]           [VARBINARY],
     [credits]             [VARBINARY],
     [firstairdate]        DATETIME2(0),
     [genres]              [VARBINARY] NOT NULL,
     [homepage]            [NVARCHAR](70),
     [id]                  [INT] NOT NULL,
     [keywords]            [VARBINARY],
     [Name]                [NVARCHAR](35) NOT NULL,
     [networks]            [VARBINARY] NOT NULL,
     [numberofepisodes]    [INT] NOT NULL,
     [numberofseasons]     [INT] NOT NULL,
     [originalName]        [NVARCHAR](35) NOT NULL,
     [overview]            [NVARCHAR](600),
     [popularity]          [FLOAT] NOT NULL,
     [posterpath]          [NVARCHAR](70),
     [seasons]             [VARBINARY],
     [status]              [NVARCHAR](20) NOT NULL,
	 [streamonlogo]		   [VARBINARY],
	 [streamon]		       [NVARCHAR](70),
	 [trailer]             [NVARCHAR](70),
     [tvshowid]            [INT] IDENTITY(1000000, 1) NOT NULL,
     [type]                [NVARCHAR](20),
     [videos]              [VARBINARY],
     [voteaverage]         [FLOAT] NOT NULL,
     [votecount]           [INT] NOT NULL,
     PRIMARY KEY ([tvshowid] ASC)
  )
GO

print '' print '*** creating TVShow Test Record ***'
GO
INSERT INTO [dbo].[tvshow]
		([backdroppath],     
		[createdby],        
		[credits],          
		[firstairdate],     
		[genres],           
		[homepage],         
		[id],               
		[keywords],         
		[Name],             
		[networks],         
		[numberofepisodes], 
		[numberofseasons],  
		[originalName],     
		[overview],         
		[popularity],       
		[posterpath],       
		[seasons],          
		[status],           
		[streamonlogo],		
		[streamon],		    
		[trailer],                   
		[type],             
		[videos],           
		[voteaverage],      
		[votecount])
	VALUES
		('/suopoADq0k8YZr4dQXcU6pToj6s.jpg', 
		null,
		null, 
		'4/17/2011 12:00:00 AM', 
		Genres.OBJECT, 
		'http://www.hbo.com/game-of-thrones', 
		1399, 
		null, 
		'Game of Thrones', 
		null, 
		5,
		5,
		'Game of Thrones',
		"Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and icy horrors beyond.",
		302.008, 
		'/u3bZgnGQ9T01sWNhyveQz0wH0Hl.jpg', 
		null, 
		'ended',
		null, 
		null, 
		null, 
		'Scripted', 
		null, 
		8.3, 
		11780)
GO

CREATE INDEX [SortByGenres]
  ON tvshow ([genres]);

CREATE INDEX [SortById]
  ON tvshow ([id]);

CREATE INDEX [SortByName]
  ON tvshow ([Name]);

CREATE INDEX [SortByNetwork]
  ON tvshow ([networks]);

CREATE INDEX [SortByOriginalName]
  ON tvshow ([originalName]);

CREATE INDEX [SortByPopularity]
  ON tvshow ([popularity]);

CREATE INDEX [SortBySeasons]
  ON tvshow ([seasons]);

CREATE INDEX [SortByTVShowID]
  ON tvshow ([tvshowid]);

CREATE INDEX [SortByVoteAverage]
  ON tvshow ([voteaverage]);

CREATE INDEX [SortByVoteCount]
  ON tvshow ([votecount]);

PRINT '' PRINT '*** creating Actor Table ***'
GO
CREATE TABLE [dbo].[actor]
  (
     [actorid]      [INT] IDENTITY(1000000, 1) NOT NULL,
     [adult]        [BIT] NOT NULL DEFAULT '0',
     [alsoknownas]  [VARBINARY],
     [biography]    [NVARCHAR](600),
     [birthday]     DATETIME2(0) NOT NULL,
     [changes]      [VARBINARY],
     [deathday]     DATETIME2(0),
     [externalids]  [VARBINARY],
     [gender]       [VARBINARY],
     [homepage]     [NVARCHAR](70),
     [id]           [INT] NOT NULL,
     [images]       [VARBINARY],
     [imdbid]       [NVARCHAR](30) NOT NULL,
     [moviecredits] [VARBINARY],
     [Name]         [NVARCHAR](30) NOT NULL,
     [placeofbirth] [NVARCHAR](100),
     [popularity]   [FLOAT],
     [profilepath]  [NVARCHAR](70),
     [taggedimages] [VARBINARY],
     [tvcredits]    [VARBINARY],
     CONSTRAINT [pk_actorID_ID_imdbID] PRIMARY KEY ([actorid], [id], [imdbid]
     ASC)
  )
GO

print '' print '*** creating Actor Test Record ***'
GO
INSERT INTO [dbo].[actor]
		([adult],[alsoknownas],[biography],[birthday],[changes],[deathday],    
		[externalids],[gender],[homepage],[id],[images],[imdbid],[moviecredits],
		[Name],[placeofbirth],[popularity],[profilepath],[taggedimages],[tvcredits])
	VALUES
		(0, null,'Jack Black (born August 28, 1969) is an American actor, comedian, singer', '1969-08-28', null, null,
		null, null, 'http', 287, null, 'nm0000093', null, 'Jack Black', "Ohio", 5.051, '/rtCx0fiYxJVhzXXdwZE2XRTfIKE.jpg', null,null)
GO

CREATE INDEX [SortByActorID]
  ON actor ([actorid]);

CREATE INDEX [SortByAdult]
  ON actor ([adult]);

CREATE INDEX [SortByBirthday]
  ON actor ([birthday]);

CREATE INDEX [SortByID]
  ON actor ([id]);

CREATE INDEX [SortByImdbId]
  ON actor ([imdbid]);

CREATE INDEX [SortByName]
  ON actor ([Name]);

PRINT '' PRINT '*** creating FavoriteMoviesList Table ***'
GO

CREATE TABLE [dbo].[FavoriteMoviesList]
  (
     [FavoriteMoviesListID] [INT] IDENTITY(1000000, 1) NOT NULL,
     [UserID]               [INT] NOT NULL,
     [movies]               [VARBINARY],
     CONSTRAINT [pk_FavoriteMoviesListID] PRIMARY KEY ([FavoriteMoviesListID] ASC),
     /*CONSTRAINT [fk_Email] FOREIGN KEY([UserID]) 
		REFERENCES [dbo].[user]([UserID])*/
  )
GO

print '' print '*** creating FavoriteMoviesList Test Record ***'
GO
INSERT INTO [dbo].[FavoriteMoviesList]
		([FavoriteMoviesListID], [movies])
	VALUES
		(1, null)
GO

CREATE INDEX [SortByFavoriteMoviesListID]
  ON FavoriteMoviesList ([FavoriteMoviesListID]);

PRINT '' PRINT '*** creating FavoriteTVShowsList Table ***'
GO
CREATE TABLE [dbo].[favoritetvshowslist]
  (
     [favoritetvshowslistid] [INT] IDENTITY(1000000, 1) NOT NULL,
     [UserID]                [INT] NOT NULL,
     [tvshows]               [VARBINARY],
     CONSTRAINT [pk_favoritetvshowslistID] PRIMARY KEY ([favoritetvshowslistid],
     [UserID] ASC)/*,
                    CONSTRAINT [fk_UserID] FOREIGN KEY([UserID])
                      REFERENCES [dbo].[User]([UserID])*/
  )
GO

CREATE INDEX [SortByFavoriteTVShowsListID]
  ON favoritetvshowslist ([favoritetvshowslistid]);

PRINT '' PRINT '*** creating FavoriteActorsList Table ***'
GO
CREATE TABLE [dbo].[FavoriteActorsList]
  (
     [FavoriteActorsListid] [INT] IDENTITY(1000000, 1) NOT NULL,
     [UserID]               [INT] NOT NULL,
     [actors]               [VARBINARY],
     CONSTRAINT [pk_FavoriteActorsListID] PRIMARY KEY ([FavoriteActorsListid],
     [UserID] ASC)/*,
                    CONSTRAINT [fk_UserID] FOREIGN KEY([UserID])
                      REFERENCES [dbo].[User]([UserID])*/
  )
GO

CREATE INDEX [SortByFavoriteFavoriteActorsListID]
  ON FavoriteActorsList ([FavoriteActorsListid]);  