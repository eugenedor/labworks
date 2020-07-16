DECLARE @t1 TABLE (x INT);
DECLARE @t2 TABLE (x INT, y INT);

INSERT INTO @t1 (x) VALUES (1), (2), (3);
INSERT INTO @t2 (x, y) VALUES (1, 1), (2, 1), (3, 2);

SELECT * FROM @t1;
SELECT * FROM @t2;

--all--
SELECT *
FROM @t1 t1
     LEFT JOIN @t2 t2
	   ON t1.x = t2.x;

--1--
SELECT *
FROM @t1 t1
     LEFT JOIN @t2 t2
	   ON t1.x = t2.x
	      AND t2.y = 1;

--2--
SELECT *
FROM @t1 t1
     LEFT JOIN @t2 t2
	   ON t1.x = t2.x
WHERE t2.y = 1;