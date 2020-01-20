USE RedBook
GO

SELECT AnimalCode, AnimalName, SquadName, TypeName, TypicalWeight
FROM dbo.IM_Animals

SELECT SquadCode, SquadName
FROM dbo.IM_Squads

SELECT TypeCode, TypeName
FROM dbo.IM_Types

SELECT CountryCode, CountryName, ContinentName, Capital, AmountNationalReserves
FROM dbo.IM_Countries

SELECT ContinentCode, ContinentName
FROM dbo.IM_Continents

SELECT AnimalCode, CountryCode, Population
FROM dbo.IM_Habitat