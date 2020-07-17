DECLARE @condition INT;
DECLARE @tCase TABLE (clmn INT);
DECLARE @tErr TABLE (clmn INT);

INSERT INTO @tCase (clmn) VALUES (1), (2), (3);
INSERT INTO @tErr (clmn) VALUES (3), (3);

--0 (without err)
SELECT *
FROM @tCase tcase
     LEFT JOIN @tErr terr 
	   ON tcase.clmn = terr.clmn
WHERE terr.clmn IS NULL;

--1 without
SET @condition = 1; --@condition = 0;
SELECT *
FROM @tCase tcase
     LEFT JOIN @tErr terr 
	   ON tcase.clmn = terr.clmn
	      AND @condition = 1
WHERE terr.clmn IS NULL;

--1 with
SET @condition = 0;
SELECT *
FROM @tCase tcase
     LEFT JOIN @tErr terr 
	   ON tcase.clmn = terr.clmn
	      AND @condition = 1
WHERE terr.clmn IS NULL;

--2 without
SET @condition = 1; --@condition = 0;
SELECT *
FROM @tCase tcase
     LEFT JOIN @tErr terr 
	   ON tcase.clmn = terr.clmn
WHERE @condition != 1 OR terr.clmn IS NULL;

--2 with
SET @condition = 0;
SELECT *
FROM @tCase tcase
     LEFT JOIN @tErr terr 
	   ON tcase.clmn = terr.clmn
WHERE @condition != 1 OR terr.clmn IS NULL;