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