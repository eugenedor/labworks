DECLARE @t1 TABLE (id BIGINT IDENTITY(1, 1), objectid INT);
DECLARE @t2 TABLE (objectid INT, code INT);

INSERT INTO @t1 (objectid) 
VALUES (117), (118), (139);

INSERT INTO @t2 (objectid, code) 
VALUES (117, 6), (118, 5), (139, 7);

SELECT * FROM @t1;
SELECT * FROM @t2;


--1--
SELECT t1.* 
FROM @t1 t1
     JOIN @t2 t2
	   ON t1.objectid = t2.objectid
	      AND t2.code != 5;

SELECT t1.* 
FROM @t1 t1
     JOIN @t2 t2
	   ON t1.objectid = t2.objectid
WHERE t2.code != 5;


--2--
SELECT * 
FROM @t1 t1
WHERE (SELECT t2.code
       FROM @t2 t2
	   WHERE t2.objectid = t1.objectid) != 5;


--3--
SELECT * 
FROM @t1 t1
WHERE t1.objectid in (SELECT t2.objectid
                      FROM @t2 t2
	                  WHERE t2.code != 5);