DECLARE    
	@pos    INT,
	@pad    NVARCHAR(1),
	@string NVARCHAR(4000),	
	@diff   INT;       
     
SET @pos = 15;
SET @pad = '0';
SELECT @pos pos, @pad pad;


SET @string = '123456789012345';
SET @diff = CASE WHEN LEN(@string) - @pos > 0 THEN LEN(@string) - @pos ELSE 0 END;
SELECT 1 num, @string string, @diff diff, REPLICATE(@pad, @diff) repl,         SUBSTRING(@string, 1, @pos) + REPLICATE(@pad, @diff) string_modify UNION ALL
SELECT 2 num, @string string, @diff diff, REPLICATE(@pad, LEN(@string)) repl,  SUBSTRING(@string, 1, @pos) + SUBSTRING(REPLICATE(@pad, LEN(@string)), 1, @diff) AS string_modify;

SET @string = '';
SET @diff = CASE WHEN LEN(@string) - @pos > 0 THEN LEN(@string) - @pos ELSE 0 END;
SELECT 1 num, @string string, @diff diff, REPLICATE(@pad, @diff) repl,         SUBSTRING(@string, 1, @pos) + REPLICATE(@pad, @diff) string_modify UNION ALL
SELECT 2 num, @string string, @diff diff, REPLICATE(@pad, LEN(@string)) repl,  SUBSTRING(@string, 1, @pos) + SUBSTRING(REPLICATE(@pad, LEN(@string)), 1, @diff) AS string_modify;

SET @string = '123456789';
SET @diff = CASE WHEN LEN(@string) - @pos > 0 THEN LEN(@string) - @pos ELSE 0 END;
SELECT 1 num, @string string, @diff diff, REPLICATE(@pad, @diff) repl,         SUBSTRING(@string, 1, @pos) + REPLICATE(@pad, @diff) string_modify UNION ALL
SELECT 2 num, @string string, @diff diff, REPLICATE(@pad, LEN(@string)) repl,  SUBSTRING(@string, 1, @pos) + SUBSTRING(REPLICATE(@pad, LEN(@string)), 1, @diff) AS string_modify;

SET @string = '1234567890123456';
SET @diff = CASE WHEN LEN(@string) - @pos > 0 THEN LEN(@string) - @pos ELSE 0 END;
SELECT 1 num, @string string, @diff diff, REPLICATE(@pad, @diff) repl,         SUBSTRING(@string, 1, @pos) + REPLICATE(@pad, @diff) string_modify UNION ALL
SELECT 2 num, @string string, @diff diff, REPLICATE(@pad, LEN(@string)) repl,  SUBSTRING(@string, 1, @pos) + SUBSTRING(REPLICATE(@pad, LEN(@string)), 1, @diff) AS string_modify;

SET @string = '1234567890123456789';
SET @diff = CASE WHEN LEN(@string) - @pos > 0 THEN LEN(@string) - @pos ELSE 0 END;
SELECT 1 num, @string string, @diff diff, REPLICATE(@pad, @diff) repl,         SUBSTRING(@string, 1, @pos) + REPLICATE(@pad, @diff) string_modify  UNION ALL
SELECT 2 num, @string string, @diff diff, REPLICATE(@pad, LEN(@string)) repl,  SUBSTRING(@string, 1, @pos) + SUBSTRING(REPLICATE(@pad, LEN(@string)), 1, @diff) AS string_modify;

SET @string = '1234567890123456789012';
SET @diff = CASE WHEN LEN(@string) - @pos > 0 THEN LEN(@string) - @pos ELSE 0 END;
SELECT 1 num, @string string, @diff diff, REPLICATE(@pad, @diff) repl,         SUBSTRING(@string, 1, @pos) + REPLICATE(@pad, @diff) string_modify  UNION ALL
SELECT 2 num, @string string, @diff diff, REPLICATE(@pad, LEN(@string)) repl,  SUBSTRING(@string, 1, @pos) + SUBSTRING(REPLICATE(@pad, LEN(@string)), 1, @diff) AS string_modify;