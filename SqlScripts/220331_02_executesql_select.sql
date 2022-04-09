DECLARE @table TABLE (rnum BIGINT, val VARCHAR(50));

INSERT INTO @table (rnum, val) 
SELECT 1 AS rnum,'Наименование' AS val UNION ALL
SELECT 2, 'Код' UNION ALL
SELECT 3, 'Значение'
ORDER BY rnum;

SELECT t.rnum, t.val 
FROM @table t 
ORDER BY t.rnum;

DECLARE @query NVARCHAR(MAX);
WITH tcnt AS (SELECT COUNT(t0.rnum) countRows
			  FROM @table t0)
SELECT @query = ISNULL(@query, 'SELECT ') + 
				'''' + t.val + ''' AS clmn' + CAST(t.rnum AS NVARCHAR(25)) +
				CASE 
				  WHEN t.rnum  = tcnt.countRows THEN ';' 
				  ELSE ',' 
				END + ' '
FROM @table t 
     CROSS JOIN tcnt
ORDER BY t.rnum ASC;

PRINT @query

EXECUTE sp_executesql @query