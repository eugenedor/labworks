USE RedBook
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE dbo.IM_Animals (
AnimalCode NVARCHAR(100) NOT NULL,
AnimalName NVARCHAR(100) NOT NULL,
SquadCode NVARCHAR(100) NULL,
SquadName NVARCHAR(100) NOT NULL,
TypeCode NVARCHAR(100) NULL,
TypeName NVARCHAR(100) NOT NULL,
TypicalWeight DECIMAL(18,3) NOT NULL
)
GO

CREATE TABLE dbo.IM_Squads (
SquadCode NVARCHAR(100) NOT NULL,
SquadName NVARCHAR(100) NOT NULL,
)
GO

CREATE TABLE dbo.IM_Types (
TypeCode NVARCHAR(100) NOT NULL,
TypeName NVARCHAR(100) NOT NULL,
)
GO

CREATE TABLE dbo.IM_Countries (
CountryCode NVARCHAR(100) NOT NULL,
CountryName NVARCHAR(100) NOT NULL,
ContinentCode NVARCHAR(100) NULL,
ContinentName NVARCHAR(100) NOT NULL,
Capital NVARCHAR(100) NOT NULL, 
AmountNationalReserves INT NULL,
)
GO

CREATE TABLE dbo.IM_Continents (
ContinentCode NVARCHAR(100) NOT NULL,
ContinentName NVARCHAR(100) NOT NULL,
)
GO

CREATE TABLE IM_Habitat (
AnimalCode  NVARCHAR(100) NOT NULL,
CountryCode NVARCHAR(100) NOT NULL,
Population INT NOT NULL
)
GO

--CREATE TABLE Habitat (
--AnimalCode INT NOT NULL,
--CountryCode INT NOT NULL,
--Population INT NOT NULL
--CONSTRAINT FK_Habitat_Animals
--FOREIGN KEY (AnimalCode)
--REFERENCES Animals (AnimalCode),
--CONSTRAINT FK_Habitat_Countries
--FOREIGN KEY (CountryCode)
--REFERENCES Countries (CountryCode)
--)
--GO
