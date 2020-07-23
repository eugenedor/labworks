DECLARE @i INT,
        @num INT, 
        @sum INT;

DECLARE @x1 INT, @x2 INT, @x3 INT, @x4 INT;

SET @sum = 1+4;

DECLARE _cur CURSOR FOR
SELECT t.num
FROM
(
   SELECT 1 num
   UNION
   SELECT 2
   UNION
   SELECT 4
   UNION
   SELECT 8
) t

OPEN _cur
  FETCH NEXT FROM _cur INTO @num
  WHILE @@FETCH_STATUS = 0
  BEGIN
    SET @i = ISNULL(@i, 0) + 1;

    SELECT @i AS i,
	       @sum AS _sum,
	       @num AS _num,
		   @sum & @num AS _bitand,
		   CASE @num WHEN @sum & @num THEN 1 ELSE 0 END AS _result

	IF (@i = 1) SET @x1 = CASE @num WHEN @sum & @num THEN 1 ELSE 0 END
	IF (@i = 2) SET @x2 = CASE @num WHEN @sum & @num THEN 1 ELSE 0 END
	IF (@i = 3) SET @x3 = CASE @num WHEN @sum & @num THEN 1 ELSE 0 END
	IF (@i = 4) SET @x4 = CASE @num WHEN @sum & @num THEN 1 ELSE 0 END

	FETCH NEXT FROM _cur INTO @num
  END

  SELECT @x1 AS x1, @x2 AS x2, @x3 AS x3, @x4 AS x4;

CLOSE _cur
DEALLOCATE _cur