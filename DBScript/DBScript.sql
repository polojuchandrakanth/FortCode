CREATE DATABASE Fort

GO

USE Fort

GO

CREATE TABLE [dbo].[UserAccounts](
	[UserAccountId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NULL,
	[Email] [varchar](500) NULL,
	[Password] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE UserCountry (
	UserCountryId INT IDENTITY(1, 1)
	,UserAccountId INT
	,city VARCHAR(50)
	,country VARCHAR(60)
	,FOREIGN KEY (UserAccountId) REFERENCES UserAccounts(UserAccountId)
	)

GO