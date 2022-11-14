DECLARE @String     NVARCHAR(4000),
        @Delimiter  NVARCHAR(100),
        @WithDouble BIT;

DECLARE @tValues TABLE 
(
    Id    INT IDENTITY(1,1),
    Value NVARCHAR(1000)
)

SET @String = '1_3_5_7_7_13_19';
SET @Delimiter = '_';
SET @WithDouble = '0';


DECLARE @i INT, @j INT, @len INT;
SET @i = 1;
SET @j = 1;
SET @len = LEN(@String);

WHILE (@j < @len+1)
BEGIN 

    if (CHARINDEX(@Delimiter, @String, @j) !=0)
       SELECT @j = CHARINDEX(@Delimiter, @String, @j);
	else
	   SELECT @j = @len+1;

    IF (@WithDouble = 1 OR NOT EXISTS(SELECT Value 
	                                  FROM @tValues 
									  WHERE Value = (SELECT CAST(SUBSTRING(@String, @i, @j - @i) AS NVARCHAR(1000)))))
	INSERT INTO @tValues (Value)
	SELECT CAST(SUBSTRING(@String, @i, @j - @i) AS NVARCHAR(1000)) Value;

	SET @j = @j + LEN(@Delimiter);
	SET @i = @j;
END

SELECT * 
FROM @tValues;