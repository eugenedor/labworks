USE RedBook
GO

SELECT AnimalCode, AnimalName, SquadCode, TypeCode, TypicalWeight
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

SELECT a.AnimalCode, a.AnimalName, a.SquadCode, s.SquadName, a.TypeCode, t.TypeName, a.TypicalWeight
FROM dbo.IM_Animals a
     JOIN dbo.IM_Squads s
	   ON a.SquadCode = s.SquadCode
	 JOIN dbo.IM_Types t
	   ON a.TypeCode = t.TypeCode;