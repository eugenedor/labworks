DECLARE @String     NVARCHAR(4000),
        @Delimiter  NVARCHAR(100);

SET @String = '1_3_5_7_7_13_19';
SET @Delimiter = '_';

DECLARE @tValues TABLE 
(
    Id    INT IDENTITY(1,1),
    Value NVARCHAR(4000)
)

WHILE (CHARINDEX(@Delimiter,@String) > 0)
BEGIN
    INSERT INTO @tValues (Value)
    SELECT LTRIM(RTRIM(SUBSTRING(@String, 1, CHARINDEX(@Delimiter,@String) - 1))) Value

    SET @String = RIGHT(@String, LEN(@String) - (CHARINDEX(@Delimiter,@String) - 1) - LEN(@Delimiter))
END
    
INSERT INTO @tValues (Value)
SELECT LTRIM(RTRIM(@String)) Value

SELECT * 
FROM @tValues;