DECLARE    
	@pad    NVARCHAR(1),
	@string NVARCHAR(4000),
	@length INT;     


SET @string = '123';
SET @length = 7;
SET @pad = '0';

SELECT @string string, 
       @length lngth, 
	   @pad pad, 
	   REPLICATE(@pad, @length) repl;

--LPAD
SELECT SUBSTRING(REPLICATE(@pad, @length),1,@length - LEN(@string)) + @string;

--RPAD
SELECT @string + SUBSTRING(REPLICATE(@pad, @length),1,@length - LEN(@string));