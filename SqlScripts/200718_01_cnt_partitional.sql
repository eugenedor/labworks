DECLARE @t TABLE (id INT IDENTITY(1,1), x INT, y INT);

INSERT INTO @t (x, y) VALUES (174, 1), (174, 2), (174, 3), (238, 1), (238, 2), (359, 1);

--0--
SELECT t.* 
FROM @t t;


--1--
SELECT t.x, COUNT (t.id) AS cnt
FROM @t t
GROUP BY t.x
HAVING COUNT(t.id) > 1;

SELECT DISTINCT tt.x, tt.cnt
FROM
(SELECT t.x, COUNT (t.id) OVER (PARTITION BY t.x) AS cnt
FROM @t t) tt
WHERE tt.cnt > 1;


--2--
SELECT t.id, t.x, t.y
FROM @t t
     JOIN ( SELECT t.x
			FROM @t t
			GROUP BY t.x
			HAVING COUNT(t.id) > 1) tx
       ON t.x = tx.x

SELECT tt.id, tt.x, tt.y, tt.cnt
FROM
(SELECT t.id, t.x, t.y, 
        COUNT (t.id) OVER (PARTITION BY t.x) AS cnt
FROM @t t) tt
WHERE tt.cnt > 1;