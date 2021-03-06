USE RedBook
GO

SELECT AnimalCode, AnimalName, SquadCode, TypeCode, TypicalWeight
FROM dbo.IM_Animals

SELECT SquadCode, SquadName
FROM dbo.IM_Squads

SELECT TypeCode, TypeName
FROM dbo.IM_Types

SELECT CountryCode, CountryName, ContinentCode, Capital, AmountNationalReserves
FROM dbo.IM_Countries

SELECT ContinentCode, ContinentName
FROM dbo.IM_Continents

SELECT AnimalCode, CountryCode, Population
FROM dbo.IM_Habitat

SELECT a.AnimalCode, a.AnimalName, a.SquadCode, s.SquadName, a.TypeCode, t.TypeName, a.TypicalWeight
FROM dbo.IM_Animals a
     LEFT JOIN dbo.IM_Squads s
	   ON a.SquadCode = s.SquadCode
	 LEFT JOIN dbo.IM_Types t
	   ON a.TypeCode = t.TypeCode;

SELECT c.CountryCode, c.CountryName, c.ContinentCode, cc.ContinentName,  c.Capital, c.AmountNationalReserves
FROM dbo.IM_Countries c
     LEFT JOIN dbo.IM_Continents cc
	   ON c.ContinentCode = cc.ContinentCode;

SELECT h.AnimalCode, a.AnimalName, h.CountryCode, c.CountryName, h.Population
FROM dbo.IM_Habitat h
     LEFT JOIN dbo.IM_Animals a
	   ON h.AnimalCode = a.AnimalCode
	 LEFT JOIN dbo.IM_Countries c
	   ON h.CountryCode = c.CountryCode;