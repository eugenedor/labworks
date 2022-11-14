DECLARE @String     NVARCHAR(4000),
        @Delimiter  NVARCHAR(100),
	    @WithDouble BIT,
        @Pos INT;


SET @Delimiter = '_';

SET @String = '12_23';
SELECT @String strng;
SELECT CHARINDEX(@Delimiter, @String) charix;
SELECT LEN(@String) lenstrng;


SELECT @Pos = CASE CHARINDEX(@Delimiter, @String) 
				WHEN 0 THEN LEN(@String) 
				ELSE CHARINDEX(@Delimiter, @String) - 1
				END;
SELECT @Pos pos;

SELECT CAST(SUBSTRING(@String, 1, @Pos) AS NVARCHAR(1000)) val;
SELECT RIGHT(@String, LEN(@String) - @Pos - 1) nextval;


SET @String = '12234';
SELECT @String strng;
SELECT CHARINDEX(@Delimiter, @String) charix;
SELECT LEN(@String) lenstrng;

SELECT @Pos = CASE CHARINDEX(@Delimiter, @String) 
				WHEN 0 THEN LEN(@String) 
				ELSE CHARINDEX(@Delimiter, @String) - 1
				END;
SELECT @Pos pos;

SELECT CAST(SUBSTRING(@String, 1, @Pos) AS NVARCHAR(1000)) val;