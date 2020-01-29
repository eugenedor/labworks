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

--SELECT AnimalCode, AnimalName, SquadCode, TypeCode, TypicalWeight
--FROM dbo.IM_Animals

--SELECT SquadCode, SquadName
--FROM dbo.IM_Squads

--SELECT TypeCode, TypeName
--FROM dbo.IM_Types

--SELECT CountryCode, CountryName, ContinentCode, Capital, AmountNationalReserves
--FROM dbo.IM_Countries

--SELECT ContinentCode, ContinentName
--FROM dbo.IM_Continents

--SELECT AnimalCode, CountryCode, Population
--FROM dbo.IM_Habitat

--SELECT a.AnimalCode, a.AnimalName, a.SquadCode, s.SquadName, a.TypeCode, t.TypeName, a.TypicalWeight
--FROM dbo.IM_Animals a
--     LEFT JOIN dbo.IM_Squads s
--	   ON a.SquadCode = s.SquadCode
--	 LEFT JOIN dbo.IM_Types t
--	   ON a.TypeCode = t.TypeCode;

--SELECT c.CountryCode, c.CountryName, c.ContinentCode, cc.ContinentName,  c.Capital, c.AmountNationalReserves
--FROM dbo.IM_Countries c
--     LEFT JOIN dbo.IM_Continents cc
--	   ON c.ContinentCode = cc.ContinentCode;

--SELECT h.AnimalCode, a.AnimalName, h.CountryCode, c.CountryName, h.Population
--FROM dbo.IM_Habitat h
--     LEFT JOIN dbo.IM_Animals a
--	   ON h.AnimalCode = a.AnimalCode
--	 LEFT JOIN dbo.IM_Countries c
--	   ON h.CountryCode = c.CountryCode;