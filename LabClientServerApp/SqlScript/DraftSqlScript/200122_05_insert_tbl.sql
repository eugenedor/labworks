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
FROM SK_Animals
     JOIN IM_Animals
	   ON SK_Animals.AnimalCode = IM_Animals.AnimalCode
     LEFT JOIN CT_Squads
	   ON IM_Animals.SquadCode = CT_Squads.SquadCode
	 LEFT JOIN CT_Types
	   ON IM_Animals.TypeCode = CT_Types.TypeCode;

INSERT INTO SK_Animals (AnimalCode, AnimalName, SquadId, TypeId, TypicalWeight)
SELECT IM_Animals.AnimalCode, IM_Animals.AnimalName, CT_Squads.SquadId, CT_Types.TypeId, IM_Animals.TypicalWeight
FROM IM_Animals 
     LEFT JOIN SK_Animals
	   ON IM_Animals.AnimalCode = SK_Animals.AnimalCode
     LEFT JOIN CT_Squads
	   ON IM_Animals.SquadCode = CT_Squads.SquadCode
	 LEFT JOIN CT_Types
	   ON IM_Animals.TypeCode = CT_Types.TypeCode
WHERE SK_Animals.AnimalId IS NULL;