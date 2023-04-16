CREATE TABLE #t (
Id INT IDENTITY(1,1), 
HistoryParentId INT, 
HistoryState INT, 
ModifiedDate DATETIME);

SET IDENTITY_INSERT #t ON;

INSERT INTO #t (Id, HistoryParentId, HistoryState, ModifiedDate) VALUES (1, 0, 2, GETDATE());
WAITFOR DELAY '00:00:01' 
INSERT INTO #t (Id, HistoryParentId, HistoryState, ModifiedDate) VALUES (2, 0, 2, GETDATE());
WAITFOR DELAY '00:00:04' 
INSERT INTO #t (Id, HistoryParentId, HistoryState, ModifiedDate) VALUES (3, 0, 4, GETDATE());
INSERT INTO #t (Id, HistoryParentId, HistoryState, ModifiedDate) VALUES (4, 3, 3, DATEADD(ss, -1, GETDATE()));

SET IDENTITY_INSERT #t OFF;

SELECT * FROM #t ORDER BY Id;;

DECLARE @newID TABLE (Id INT);
DECLARE @Id INT;

SET @Id = 3;

INSERT INTO #t 
OUTPUT INSERTED.Id INTO @newID
SELECT HistoryParentId, HistoryState, ModifiedDate
FROM #t
WHERE Id = @Id;

UPDATE #t
SET HistoryParentId = @Id
WHERE Id = (SELECT TOP 1 Id FROM @newID);

UPDATE #t
SET HistoryParentId = (SELECT TOP 1 Id FROM @newID)
WHERE HistoryParentId = @Id
      AND Id != (SELECT TOP 1 Id FROM @newID)


WAITFOR DELAY '00:00:03' 
UPDATE #t
SET HistoryState = 4,
	ModifiedDate = GETDATE()
WHERE Id = @Id


SELECT * FROM #t ORDER BY ModifiedDate DESC;

DROP TABLE #t;
GO