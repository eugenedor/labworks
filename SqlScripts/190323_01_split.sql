DECLARE @String     NVARCHAR(4000),
        @Delimiter  NVARCHAR(5),
	    @WithDouble BIT,
        @Pos INT;

DECLARE @SplittedValues TABLE
(
    Id      INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Value   NVARCHAR(100) 
);

SET @String = '1_3_5_7_7_13_19';
SET @Delimiter = '_';
SET @WithDouble = '0';


WHILE LEN(@String) > 0
BEGIN 
    SELECT @Pos = CASE CHARINDEX(@Delimiter, @String) 
						WHEN 0 THEN LEN(@String) 
						ELSE CHARINDEX(@Delimiter, @String) - 1
					END;

    IF (@WithDouble = 1 OR
		NOT EXISTS(SELECT Value 
		           FROM @SplittedValues 
			       WHERE Value = (SELECT CAST(SUBSTRING(@String, 1, @Pos) AS NVARCHAR(100))))
		)
		INSERT INTO @SplittedValues (Value)  
		SELECT CAST(SUBSTRING(@String, 1, @Pos) AS NVARCHAR(100))

    SELECT @String = CASE 
		                    WHEN @Pos != LEN(@String) THEN RIGHT(@String, LEN(@String) - @Pos - 1)
                            ELSE ''
					    END
END 

SELECT * 
FROM @SplittedValues;