DECLARE @t TABLE (Id INT IDENTITY(1,1), HistoryParentId INT, HistoryState INT, ModifiedDate DATETIME);

INSERT INTO @t (HistoryParentId, HistoryState, ModifiedDate) VALUES (0, 3, GETDATE());
WAITFOR DELAY '00:00:01' 
INSERT INTO @t (HistoryParentId, HistoryState, ModifiedDate) VALUES (0, 3, GETDATE());
WAITFOR DELAY '00:00:03' 
INSERT INTO @t (HistoryParentId, HistoryState, ModifiedDate) VALUES (0, 3, GETDATE());
WAITFOR DELAY '00:00:02' 
INSERT INTO @t (HistoryParentId, HistoryState, ModifiedDate) VALUES (0, 3, GETDATE());

SELECT * FROM @t;

DECLARE @newID TABLE (Id INT);
DECLARE @Id INT;

SET @Id = 2;

INSERT INTO @t 
OUTPUT INSERTED.Id INTO @newID
SELECT HistoryParentId, HistoryState, ModifiedDate
FROM @t
WHERE Id = @Id;

UPDATE @t
SET HistoryParentId = @Id
WHERE Id = (SELECT TOP 1 Id FROM @newID);

UPDATE @t
SET HistoryParentId = (SELECT TOP 1 Id FROM @newID)
WHERE HistoryParentId = @Id
      AND Id != (SELECT TOP 1 Id FROM @newID)


WAITFOR DELAY '00:00:05' 
UPDATE @t
SET HistoryState = 4,
	ModifiedDate = GETDATE()
WHERE Id = @Id


SELECT * FROM @t;