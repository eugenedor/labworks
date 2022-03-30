DECLARE @table TABLE (rnum BIGINT, val VARCHAR(50));

INSERT INTO @table (rnum, val) VALUES (1,'Наименование'), (2, 'Код'), (3, 'Значение');

SELECT t.rnum, t.val 
FROM @table t 
ORDER BY t.rnum;

DECLARE @query NVARCHAR(MAX);
WITH tcnt AS (SELECT COUNT(t0.rnum) countRows
			  FROM @table t0)
SELECT @query = ISNULL(@query, 'SELECT ') + 
				'''' + t.val + ''' AS N''' + CAST(t.rnum AS NVARCHAR(25)) + '''' +
				CASE 
				  WHEN ROW_NUMBER() OVER (ORDER BY t.rnum ASC) = tcnt.countRows THEN ';' 
				  ELSE ',' 
				END + ' '
FROM @table t 
     CROSS JOIN tcnt
ORDER BY t.rnum ASC;

PRINT @query

EXECUTE sp_executesql @query