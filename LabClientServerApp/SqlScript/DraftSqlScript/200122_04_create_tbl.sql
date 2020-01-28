USE RedBook
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE dbo.CT_Squads(
	SquadId BIGINT IDENTITY(1,1) NOT NULL,
	SquadCode NVARCHAR(100) NOT NULL,
	SquadName NVARCHAR(100) NOT NULL,
 CONSTRAINT [PK_CT_Squads] PRIMARY KEY CLUSTERED 
(
	SquadId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [AK_CT_Squads] ON dbo.CT_Squads
(
	SquadCode ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE TABLE dbo.CT_Types (
	TypeId BIGINT IDENTITY(1,1) NOT NULL,
	TypeCode NVARCHAR(100) NOT NULL,
	TypeName NVARCHAR(100) NOT NULL,
 CONSTRAINT [PK_CT_Types] PRIMARY KEY CLUSTERED 
(
	TypeId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [AK_CT_Types] ON dbo.CT_Types
(
	TypeCode ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE TABLE dbo.SK_Animals(
	AnimalId BIGINT IDENTITY(1,1) NOT NULL,
	AnimalCode NVARCHAR(100) NOT NULL,
	AnimalName NVARCHAR(100) NOT NULL,
	SquadId BIGINT NOT NULL,
	TypeId BIGINT NULL,
	TypicalWeight DECIMAL(18,3) NOT NULL
 CONSTRAINT PK_SK_Animals PRIMARY KEY CLUSTERED 
(
	AnimalId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE dbo.SK_Animals  WITH NOCHECK ADD  CONSTRAINT FK_SK_Animals_CT_Squads FOREIGN KEY(SquadId)
REFERENCES dbo.CT_Squads (SquadId)
GO

ALTER TABLE dbo.SK_Animals CHECK CONSTRAINT FK_SK_Animals_CT_Squads
GO

ALTER TABLE dbo.SK_Animals  WITH NOCHECK ADD  CONSTRAINT FK_SK_Animals_CT_Types FOREIGN KEY(TypeId)
REFERENCES dbo.CT_Types (TypeId)
GO

ALTER TABLE dbo.SK_Animals CHECK CONSTRAINT FK_SK_Animals_CT_Types
GO


CREATE TABLE dbo.CT_Continents (
	ContinentId BIGINT IDENTITY(1,1) NOT NULL,
	ContinentCode NVARCHAR(100) NOT NULL,
	ContinentName NVARCHAR(100) NOT NULL,
 CONSTRAINT [PK_CT_Continents] PRIMARY KEY CLUSTERED 
(
	ContinentId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE dbo.SK_Countries(
	CountryId BIGINT IDENTITY(1,1) NOT NULL,
	CountryCode NVARCHAR(100) NOT NULL,
	CountryName NVARCHAR(100) NOT NULL,
	ContinentId BIGINT NOT NULL,
	Capital NVARCHAR(100) NOT NULL, 
	AmountNationalReserves INT NULL,
 CONSTRAINT PK_SK_Countries PRIMARY KEY CLUSTERED 
(
	CountryId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE dbo.SK_Countries  WITH NOCHECK ADD  CONSTRAINT FK_SK_Countries_CT_Continents FOREIGN KEY(ContinentId)
REFERENCES dbo.CT_Continents (ContinentId)
GO

ALTER TABLE dbo.SK_Countries CHECK CONSTRAINT FK_SK_Countries_CT_Continents
GO


CREATE TABLE dbo.RS_Habitat(
    HabitatId BIGINT IDENTITY(1,1) NOT NULL,
	AnimalId BIGINT NOT NULL,
	CountryId BIGINT NOT NULL,
	Population BIGINT NOT NULL
 CONSTRAINT PK_RS_Habitat PRIMARY KEY CLUSTERED 
(
	HabitatId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE dbo.RS_Habitat  WITH CHECK ADD  CONSTRAINT FK_RS_Habitat_SK_Animals FOREIGN KEY(AnimalId)
REFERENCES dbo.SK_Animals (AnimalId)
GO

ALTER TABLE dbo.RS_Habitat CHECK CONSTRAINT FK_RS_Habitat_SK_Animals
GO

ALTER TABLE dbo.RS_Habitat  WITH CHECK ADD  CONSTRAINT FK_RS_Habitat_SK_Countries FOREIGN KEY(CountryId)
REFERENCES dbo.SK_Countries (CountryId)
GO

ALTER TABLE dbo.RS_Habitat CHECK CONSTRAINT FK_RS_Habitat_SK_Countries
GO