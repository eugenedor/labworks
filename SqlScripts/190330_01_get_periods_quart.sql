DECLARE
    @DateBegin DATETIME,
    @DateEnd   DATETIME

SET @DateBegin = CONVERT(DATETIME, '11.10.2019', 104);
SET @DateEnd = CONVERT(DATETIME, '12.07.2020', 104);

--YearNumbers
DECLARE @YearNumbers TABLE 
(
	Value INT
);

WITH t AS (SELECT n 
	        FROM (VALUES (0),(1),(2),(3),(4),(5),(6),(7),(8),(9)) v(n))
	
INSERT INTO @YearNumbers (Value)
SELECT tbl.n
FROM (SELECT t1.n + t2.n*10 + t3.n*100 + t4.n*1000  AS n
	  FROM t t1,     
		   t t2,
		   t t3,
		   t t4) tbl
WHERE tbl.n BETWEEN YEAR(@DateBegin) AND YEAR(@DateEnd)
ORDER BY tbl.n;


--QuartNumbers
DECLARE @QuartNumbers TABLE 
(
	Value INT
);
	
INSERT INTO @QuartNumbers (Value)
SELECT n FROM (VALUES (1),(2),(3),(4)) v(n);


--PeriodsQuart
DECLARE @PeriodsQuart TABLE 
(
	Year      INT, 
	Quart     INT, 
	DateBegin DATETIME, 
	DateEnd   DATETIME,
    Id        INT
);

WITH Periods AS 
(SELECT ROW_NUMBER() OVER (ORDER BY ty.Y, tq.Q) AS Id,
		ty.Y, tq.Q , 
		DATEADD(mm, (tq.Q -1) * 3, CONVERT(DATETIME, CAST(ty.Y AS NVARCHAR(4)) + '0101', 112)) AS DateBegin
	FROM (SELECT n1.Value AS Y
	      FROM @YearNumbers n1) ty
		 CROSS JOIN 
		 (SELECT n2.Value AS Q 
		  FROM @QuartNumbers n2) tq)

INSERT INTO @PeriodsQuart (Year, Quart, DateBegin, DateEnd, Id)  
SELECT tp.Y AS Year,
	   tp.Q AS Quart, 
	   tp.DateBegin, 
	   DATEADD(dd, -1, DATEADD(qq, 1, tp.DateBegin)) AS DateEnd,
	   tp.Id
FROM Periods tp
WHERE tp.Id >= (SELECT DISTINCT tp1.Id
				FROM Periods tp1
				WHERE @DateBegin BETWEEN tp1.DateBegin AND DATEADD(dd, -1, DATEADD(qq, 1, tp1.DateBegin)))
		AND
		tp.Id <= (SELECT DISTINCT tp2.Id
				FROM Periods tp2
				WHERE @DateEnd BETWEEN tp2.DateBegin AND DATEADD(dd, -1, DATEADD(qq, 1, tp2.DateBegin)))
ORDER BY tp.Y, tp.Q;

SELECT pq.Year, pq.Quart, pq.DateBegin, pq.DateEnd --, pq.Id
FROM @PeriodsQuart pq
ORDER BY pq.Year, pq.Quart;