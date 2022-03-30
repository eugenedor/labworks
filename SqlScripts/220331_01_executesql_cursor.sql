DECLARE @table TABLE (id INT IDENTITY(1,1), val VARCHAR(50));

INSERT INTO @table (val) VALUES ('Наименование'), ('Код'), ('Значение');

SELECT t.id, t.val 
FROM @table t 
ORDER BY t.id;

DECLARE @query NVARCHAR(MAX), 
		@val   NVARCHAR(50),
		@sym   NVARCHAR(1),
		@cnt   INT,
		@c     INT = 0;

SET @query = '';

SELECT @cnt = COUNT(*) 
FROM @table t;

DECLARE _cur CURSOR LOCAL FOR
SELECT t.val 
FROM @table t 
ORDER BY t.id;

OPEN _cur
  FETCH NEXT FROM _cur INTO @val
  WHILE @@FETCH_STATUS = 0
  BEGIN	
    SET @query = @query + '''' + @val + ''' AS clmn' + CAST(@c AS NVARCHAR(25));
	SET @c = @c + 1;
	IF (@c < @cnt)
		SET @sym = ','
	ELSE
		SET @sym = ';'
	SET @query = @query + @sym + ' ';
	FETCH NEXT FROM _cur INTO @val
  END

CLOSE _cur
DEALLOCATE _cur

SET @query = 'SELECT ' + @query;

PRINT @query

EXECUTE sp_executesql @query