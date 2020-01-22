USE RedBook
GO

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