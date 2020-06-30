SET DATEFORMAT YMD;
SET LANGUAGE 'ENGLISH';

DECLARE @dbeg DATETIME,
        @dend DATETIME;

SET @dbeg = CAST('2018-07-10' AS DATETIME);
SET @dend = CAST('2018-08-10' AS DATETIME);

SELECT @dbeg dbeg1, @dend dend1;

DECLARE @t TABLE (id INT IDENTITY(1,1), dbeg DATETIME, dend DATETIME);
INSERT INTO @t (dbeg, dend)
SELECT CAST('2018-06-01' AS DATETIME) db, CAST('2018-06-30' AS DATETIME) de UNION
SELECT CAST('2018-07-01' AS DATETIME), CAST('2018-07-31' AS DATETIME) UNION
SELECT CAST('2018-08-01' AS DATETIME), CAST('2018-08-31' AS DATETIME) UNION
SELECT CAST('2018-09-01' AS DATETIME), CAST('2018-09-30' AS DATETIME);

SELECT t.id, t.dbeg dbeg2, t.dend dend2
FROM @t t;

--
--var1--
--
SELECT t.*
FROM @t t
WHERE t.dbeg <= @dend
      AND @dbeg <= t.dend;

--
--var2--
--
SELECT t.*
FROM @t t
WHERE (SELECT MAX(t1.dbeg) 
       FROM (SELECT t.dbeg dbeg UNION 
             SELECT @dbeg) t1) <=
      (SELECT MIN(t2.dend) 
       FROM (SELECT t.dend dend UNION 
             SELECT @dend) t2);