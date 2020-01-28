USE RedBook
GO

--
--CT_Squads
--
UPDATE CT_Squads
SET SquadName = IM_Squads.SquadName
FROM IM_Squads
WHERE CT_Squads.SquadCode = IM_Squads.SquadCode;

INSERT INTO CT_Squads (SquadCode, SquadName)
SELECT im.SquadCode, im.SquadName
FROM IM_Squads im
     LEFT JOIN CT_Squads ct
	   ON im.SquadCode = ct.SquadCode
WHERE ct.SquadId IS NULL;


--
--CT_Types
--
UPDATE CT_Types
SET TypeName = (SELECT TypeName 
                FROM IM_Types 
				WHERE CT_Types.TypeCode = IM_Types.TypeCode);

INSERT INTO CT_Types (TypeCode, TypeName)
SELECT im.TypeCode, im.TypeName
FROM IM_Types im
     LEFT JOIN CT_Types ct
	   ON im.TypeCode = ct.TypeCode
WHERE ct.TypeId IS NULL;


--
--SK_Animals
--
UPDATE SK_Animals
SET AnimalName = IM_Animals.AnimalName,
    SquadId = CT_Squads.SquadId,
	TypeId = CT_Types.TypeId,
	TypicalWeight = IM_Animals.TypicalWeight
FROM IM_Animals 
     JOIN CT_Squads
	   ON IM_Animals.SquadCode = CT_Squads.SquadCode
	 LEFT JOIN CT_Types
	   ON IM_Animals.TypeCode = CT_Types.TypeCode
     JOIN SK_Animals
	   ON IM_Animals.AnimalCode = SK_Animals.AnimalCode;

INSERT INTO SK_Animals (AnimalCode, AnimalName, SquadId, TypeId, TypicalWeight)
SELECT IM_Animals.AnimalCode, IM_Animals.AnimalName, CT_Squads.SquadId, CT_Types.TypeId, IM_Animals.TypicalWeight
FROM IM_Animals 
     JOIN CT_Squads
	   ON IM_Animals.SquadCode = CT_Squads.SquadCode
	 LEFT JOIN CT_Types
	   ON IM_Animals.TypeCode = CT_Types.TypeCode
     LEFT JOIN SK_Animals
	   ON IM_Animals.AnimalCode = SK_Animals.AnimalCode
WHERE SK_Animals.AnimalId IS NULL;


--
--CT_Continents
--
UPDATE CT_Continents
SET ContinentName = IM_Continents.ContinentName
FROM IM_Continents
WHERE CT_Continents.ContinentCode = IM_Continents.ContinentCode;

INSERT INTO CT_Continents (ContinentCode, ContinentName)
SELECT im.ContinentCode, im.ContinentName
FROM IM_Continents im
     LEFT JOIN CT_Continents ct
	   ON im.ContinentCode = ct.ContinentCode
WHERE ct.ContinentId IS NULL;


--
--SK_Countries
--
UPDATE SK_Countries
SET CountryName = IM_Countries.CountryName,
	ContinentId = CT_Continents.ContinentId,
	Capital = IM_Countries.Capital, 
	AmountNationalReserves = IM_Countries.AmountNationalReserves
FROM IM_Countries 
     JOIN CT_Continents
	   ON IM_Countries.ContinentCode = CT_Continents.ContinentCode
     JOIN SK_Countries
	   ON IM_Countries.CountryCode = SK_Countries.CountryCode;

INSERT INTO SK_Countries (CountryCode, CountryName, ContinentId, Capital, AmountNationalReserves)
SELECT IM_Countries.CountryCode, IM_Countries.CountryName, CT_Continents.ContinentId, IM_Countries.Capital, IM_Countries.AmountNationalReserves
FROM IM_Countries 
     JOIN CT_Continents
	   ON IM_Countries.ContinentCode = CT_Continents.ContinentCode
     LEFT JOIN SK_Countries
	   ON IM_Countries.CountryCode = SK_Countries.CountryCode
WHERE SK_Countries.CountryId IS NULL;


--
--RS_Habitat
--
UPDATE RS_Habitat
SET RS_Habitat.Population = IM_Habitat.Population
FROM IM_Habitat
     JOIN SK_Animals
	   ON IM_Habitat.AnimalCode = SK_Animals.AnimalCode
	 JOIN SK_Countries
	   ON IM_Habitat.CountryCode = SK_Countries.CountryCode
     JOIN RS_Habitat
	   ON SK_Animals.AnimalId = RS_Habitat.AnimalId
	      AND SK_Countries.CountryId = RS_Habitat.CountryId;

INSERT INTO RS_Habitat (AnimalId, CountryId, Population)
SELECT SK_Animals.AnimalId, SK_Countries.CountryId, IM_Habitat.Population
FROM IM_Habitat
     JOIN SK_Animals
	   ON IM_Habitat.AnimalCode = SK_Animals.AnimalCode
	 JOIN SK_Countries
	   ON IM_Habitat.CountryCode = SK_Countries.CountryCode
     LEFT JOIN RS_Habitat
	   ON SK_Animals.AnimalId = RS_Habitat.AnimalId
	      AND SK_Countries.CountryId = RS_Habitat.CountryId
WHERE RS_Habitat.HabitatId IS NULL;