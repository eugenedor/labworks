DECLARE @t TABLE (id INT IDENTITY(1,1), x INT, y INT);

INSERT INTO @t (x, y) VALUES (11, 21), (12, 22), (13, 23), (14, 24);

DECLARE @px INT, @py INT;

DECLARE _cur CURSOR LOCAL FOR
SELECT t.px, t.py
FROM
(
   SELECT NULL px, NULL py, 5 ord
   UNION
   SELECT 12, NULL, 4
   UNION
   SELECT NULL, 23, 3
   UNION
   SELECT 13, 23, 2
   UNION
   SELECT 14, 23, 1
) t
ORDER BY t.Ord

OPEN _cur
  FETCH NEXT FROM _cur INTO @px, @py
  WHILE @@FETCH_STATUS = 0
  BEGIN

    SELECT t.id, t.x, t.y
	FROM @t t
	WHERE (@px IS NULL OR t.x = @px) 
	      AND (@py IS NULL OR t.y = @py);

	FETCH NEXT FROM _cur INTO @px, @py
  END

CLOSE _cur
DEALLOCATE _cur