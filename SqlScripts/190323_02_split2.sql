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


WHILE (CHARINDEX(@Delimiter,@String) > 0)
BEGIN
    IF (@WithDouble = 1 OR NOT EXISTS(SELECT Value 
	                                  FROM @tValues 
									  WHERE Value = (SELECT CAST(SUBSTRING(@String, 1, CHARINDEX(@Delimiter,@String) - 1) AS NVARCHAR(1000)))))

		INSERT INTO @tValues (Value)
		SELECT CAST(SUBSTRING(@String, 1, CHARINDEX(@Delimiter,@String) - 1) AS NVARCHAR(1000)) Value

    SET @String = RIGHT(@String, LEN(@String) - (CHARINDEX(@Delimiter,@String) - 1) - LEN(@Delimiter))
END
    
INSERT INTO @tValues (Value)
SELECT @String Value

SELECT * 
FROM @tValues;