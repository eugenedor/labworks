SET DATEFORMAT ymd;

DECLARE @t TABLE (id INT IDENTITY(1,1), objectid BIGINT, dat DATETIME)

INSERT INTO @t (objectid, dat)
VALUES (1, CAST('2017-10-09' AS DATETIME)),
       (1, CAST('2017-08-06' AS DATETIME)),
       (1, CAST('2017-12-13' AS DATETIME)),
       (2, CAST('2017-03-03' AS DATETIME)),
       (2, CAST('2017-01-25' AS DATETIME)),
       (3, CAST('2017-10-13' AS DATETIME));

SELECT * 
FROM @t t;


--1--
SELECT t.id, t.objectid, t.dat
FROM @t t
     JOIN (SELECT objectid, MAX(dat) AS dat
	       FROM @t
	       GROUP BY objectid
		   HAVING COUNT(dat) > 1) tt
     ON t.objectid = tt.objectid
	    AND t.dat = tt.dat
ORDER BY t.id;

--2--
SELECT t.id, t.objectid, t.dat
FROM @t t
WHERE t.dat = (SELECT MAX(t1.dat) AS dat
	           FROM @t t1
	           WHERE t1.objectid = t.objectid)
	  AND (SELECT COUNT(t1.dat)
	       FROM @t t1
	       WHERE t1.objectid = t.objectid) > 1
ORDER BY t.id;

--3--
SELECT tt.id, tt.objectid, tt.dat
FROM (SELECT t.id, t.objectid, t.dat,
             COUNT(t.dat) OVER (PARTITION BY t.objectid) AS cnt,
			 MAX(t.dat) OVER (PARTITION BY t.objectid) AS datm
	  FROM @t t) tt
 WHERE tt.dat = tt.datm
	   AND tt.cnt > 1
ORDER BY tt.id;