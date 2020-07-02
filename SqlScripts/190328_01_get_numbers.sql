DECLARE @From INT,
        @To   INT;

SET @From = 1;
SET @To = 777;

WITH t AS (SELECT n 
	        FROM (VALUES (0),(1),(2),(3),(4),(5),(6),(7),(8),(9)) v(n))
	
SELECT tbl.n
FROM (SELECT 1 + t1.n + t2.n*10 + t3.n*100 + t4.n*1000 + t5.n*10000 + t6.n*100000  AS n
	  FROM t t1,     
		   t t2,
		   t t3,
		   t t4, 
		   t t5,
		   t t6) tbl
WHERE tbl.n BETWEEN @From AND @To
ORDER BY tbl.n;