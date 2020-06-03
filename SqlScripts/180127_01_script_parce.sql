DECLARE @x NVARCHAR(250)

SET @x = 'RS_ORDER_ADDRESS';
PRINT @x

SET @x = SUBSTRING(@x, 4, LEN(@x)- 3);
PRINT @x

SET @x = UPPER(SUBSTRING(@x, 1, 1)) + LOWER(SUBSTRING(@x, 2, LEN(@x)- 1));
PRINT @x

WHILE CHARINDEX('_', @x, 1) <> 0
BEGIN
	SELECT @x =  REPLACE(@x, SUBSTRING(@x, CHARINDEX('_', @x, 1), 2), UPPER(SUBSTRING(@x, CHARINDEX('_', @x, 1) + 1, 1)))
END

SET @x =  @x + 'Id'
PRINT @x
SELECT @x AS x_string