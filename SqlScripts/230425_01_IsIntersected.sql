DECLARE @DateFrom DATETIME,
		@DateTo DATETIME;

SET @DateFrom = CONVERT(DATETIME, '20230606', 112);
SET @DateTo = CONVERT(DATETIME, '20230707', 112);

SELECT  @DateFrom DateFrom, 
		@DateTo DateTo;

DECLARE @t TABLE (Id INT IDENTITY(1,1), [DateFrom] DATETIME, [DateTo] DATETIME);
INSERT INTO @t ([DateFrom], [DateTo]) VALUES
('2023-01-01', '2023-03-31'),
('2023-04-01', '2023-06-30'),
('2023-07-01', '2023-09-30'),
('2023-10-01', '2023-12-31');

SELECT  t.Id,
		t.DateFrom,
		t.DateTo,
		CASE 
			WHEN [DateFrom] <= @DateTo AND [DateTo] >= @DateFrom THEN 1
		    ELSE 0
		END IsIntersected1,
		CASE 
			WHEN (CASE WHEN [DateFrom] >= @DateFrom THEN [DateFrom] ELSE @DateFrom END <=
				  CASE WHEN [DateTo] <= @DateTo THEN [DateTo] ELSE @DateTo END) THEN 1
			ELSE 0
		END IsIntersected2
FROM @t t
ORDER BY t.Id;