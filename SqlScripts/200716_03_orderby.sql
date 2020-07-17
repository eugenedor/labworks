DECLARE @t TABLE (id BIGINT IDENTITY(1,1), txt NVARCHAR(100));

INSERT INTO @t (txt) VALUES ('Артем'), ('Борис'), ('Владислав');

SELECT t.* 
FROM @t t;

DECLARE @condition INT;

--1--
--order by desc--
SET @condition = 0;
SELECT t.* 
FROM @t t
ORDER BY t.id * CASE WHEN @condition = 1 THEN 1 ELSE (-1) END ASC;

--order by asc--
SET @condition = 1;
SELECT t.* 
FROM @t t
ORDER BY t.id * CASE WHEN @condition = 1 THEN 1 ELSE (-1) END ASC;

--2--
SET @condition = 0;
SELECT t.*, 
       (ROW_NUMBER() over (order by t.txt asc)) as rnum,
	   (ROW_NUMBER() over (order by t.txt asc)) * CASE WHEN @condition = 1 THEN 1 ELSE (-1) END AS rn
FROM @t t
ORDER BY rn ASC;

SET @condition = 1;
SELECT t.*, 
       (ROW_NUMBER() over (order by t.txt asc)) as rnum,
	   (ROW_NUMBER() over (order by t.txt asc)) * CASE WHEN @condition = 1 THEN 1 ELSE (-1) END AS rn
FROM @t t
ORDER BY rn ASC;