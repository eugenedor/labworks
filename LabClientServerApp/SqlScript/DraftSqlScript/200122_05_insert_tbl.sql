USE RedBook
GO

UPDATE dbo.CT_Squads
SET SquadName = IM_Squads.SquadName
FROM IM_Squads
WHERE CT_Squads.SquadCode = IM_Squads.SquadCode;

INSERT INTO dbo.CT_Squads (SquadCode, SquadName)
SELECT im.SquadCode, im.SquadName
FROM dbo.IM_Squads im
     LEFT JOIN dbo.CT_Squads ct
	   ON im.SquadCode = ct.SquadCode
WHERE ct.SquadId IS NULL;