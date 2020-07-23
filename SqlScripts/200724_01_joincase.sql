DECLARE @x BIT;

DECLARE @t1 TABLE (id BIGINT IDENTITY(1,1), x INT, y INT);
DECLARE @t2 TABLE (z INT);

INSERT INTO @t1 (x, y) VALUES (1, 2), (3, 4);
INSERT INTO @t2 (z) VALUES (1), (2), (3), (4);

SELECT * FROM @t1 t1;
SELECT * FROM @t2 t2;

SET @x = 0;
SELECT *
FROM @t1 t1
     JOIN @t2 t2
	   ON CASE WHEN (@x = 0)
	        THEN t1.x
			ELSE t1.y 
		   END = t2.z;

SET @x = 1;
SELECT *
FROM @t1 t1
     JOIN @t2 t2
	   ON CASE WHEN (@x = 0)
	        THEN t1.x
			ELSE t1.y 
		   END = t2.z;