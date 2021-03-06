USE RedBook
GO

SELECT SquadId, SquadCode, SquadName
FROM dbo.CT_Squads;

SELECT TypeId, TypeCode, TypeName
FROM dbo.CT_Types;

SELECT a.AnimalId, a.AnimalCode, a.AnimalName, s.SquadName, t.TypeName, a.TypicalWeight
FROM dbo.SK_Animals a
     JOIN dbo.CT_Squads s
	   ON a.SquadId = s.SquadId
	 LEFT JOIN dbo.CT_Types t
	   ON a.TypeId = t.TypeId;

SELECT ContinentId, ContinentCode, ContinentName 
FROM CT_Continents;

SELECT c0.CountryId, c0.CountryCode, c0.CountryName, c0.ContinentId, c1.ContinentName, c0.Capital, c0.AmountNationalReserves
FROM dbo.SK_Countries c0
     JOIN dbo.CT_Continents c1
	   ON c0.ContinentId = c1.ContinentId;

SELECT h.HabitatId, h.AnimalId, a.AnimalName, h.CountryId, c.CountryName, h.Population
FROM dbo.RS_Habitat h
     JOIN dbo.SK_Animals a
	   ON h.AnimalId = a.AnimalId
	 JOIN dbo.SK_Countries c
	   ON h.CountryId = c.CountryId;

--Result--
SELECT h.HabitatId, 
       h.AnimalId, a.AnimalCode, a.AnimalName, 
	   s.SquadId, s.SquadCode, s.SquadName,
	   t.TypeId, t.TypeCode, t.TypeName,
	   h.CountryId, c.CountryCode, c.CountryName, 
	   ct.ContinentId, ct.ContinentCode, ct.ContinentName,	   
	   h.Population
FROM dbo.RS_Habitat h
     JOIN dbo.SK_Animals a
	   ON h.AnimalId = a.AnimalId
     JOIN dbo.CT_Squads s
	   ON a.SquadId = s.SquadId
	 LEFT JOIN dbo.CT_Types t
	   ON a.TypeId = t.TypeId
	 JOIN dbo.SK_Countries c
	   ON h.CountryId = c.CountryId
	 JOIN dbo.CT_Continents ct
	   ON c.ContinentId = ct.ContinentId;