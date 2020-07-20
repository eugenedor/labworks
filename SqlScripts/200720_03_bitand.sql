DECLARE @sm INT;
SET @sm = 133;

WITH t AS (SELECT n 
	        FROM (VALUES (0),(1),(2),(3),(4),(5),(6),(7),(8),(9)) v(n))
	
SELECT tbl.n AS n, 
       POWER(2, tbl.n) AS nm,
	   @sm & POWER(2, tbl.n) AS bitand,
	   CASE WHEN @sm & POWER(2, tbl.n) = POWER(2, tbl.n) THEN 1 ELSE 0 END AS isChecked
FROM (SELECT t1.n + t2.n*10 AS n
	  FROM t t1,     
		   t t2) tbl
WHERE tbl.n BETWEEN 0 AND 10
ORDER BY tbl.n;