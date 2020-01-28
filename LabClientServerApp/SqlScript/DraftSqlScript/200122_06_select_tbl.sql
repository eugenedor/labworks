USE RedBook
GO

SELECT SquadId, SquadCode, SquadName
FROM dbo.CT_Squads;

SELECT TypeId, TypeCode, TypeName
FROM dbo.CT_Types;

SELECT a.AnimalId, a.AnimalCode, a.AnimalName, s.SquadName, t.TypeName, a.TypicalWeight
FROM dbo.SK_Animals a
     LEFT JOIN dbo.CT_Squads s
	   ON a.SquadId = s.SquadId
	 LEFT JOIN dbo.CT_Types t
	   ON a.TypeId = t.TypeId;

SELECT ContinentId, ContinentCode, ContinentName 
FROM CT_Continents;

SELECT c0.CountryId, c0.CountryCode, c0.CountryName, c0.ContinentId, c1.ContinentName, c0.Capital, c0.AmountNationalReserves
FROM dbo.SK_Countries c0
     LEFT JOIN dbo.CT_Continents c1
	   ON c0.ContinentId = c1.ContinentId;

SELECT h.HabitatId, h.AnimalId, a.AnimalName, h.CountryId, c.CountryName, h.Population
FROM dbo.RS_Habitat h
     JOIN dbo.SK_Animals a
	   ON h.AnimalId = a.AnimalId
	 JOIN dbo.SK_Countries c
	   ON h.CountryId = c.CountryId;