DECLARE @t1 TABLE (id INT IDENTITY(11, 1), x INT, y INT);
DECLARE @t2 TABLE (id INT IDENTITY(101,1), x INT, z INT);

INSERT INTO @t1 (x, y) values (1, 11), (2, 12), (3, 13), (4, 14);
INSERT INTO @t2 (x, z) values (1, 101), (2, 102), (3, 103), (5, 105);

SELECT * FROM @t1;
SELECT * FROM @t2;

SELECT * 
FROM @t1 t1, @t2 t2
WHERE t1.x = t2.x;

SELECT * 
FROM @t1 t1
     JOIN @t2 t2
	   ON t1.x = t2.x;