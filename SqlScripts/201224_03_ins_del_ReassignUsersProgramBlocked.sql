DECLARE @FromProgram INT
SET @FromProgram = 11;

DECLARE @ToProgram INT
SET @ToProgram = 111;

DECLARE @users_programs_blocked TABLE (id INT IDENTITY(1,1), programID INT, userID INT);
INSERT INTO @users_programs_blocked (programID, userID) VALUES (11, 1);
INSERT INTO @users_programs_blocked (programID, userID) VALUES (11, 2);
INSERT INTO @users_programs_blocked (programID, userID) VALUES (11, 3);
INSERT INTO @users_programs_blocked (programID, userID) VALUES (111, 3);

SELECT @FromProgram FromProgram, 
       @ToProgram ToProgram;

--before--
SELECT * FROM @users_programs_blocked;

--myVar
INSERT INTO @users_programs_blocked (programID, userID) 
SELECT @ToProgram AS programID, t1.userID
FROM @users_programs_blocked t1
     LEFT JOIN @users_programs_blocked t2
	   ON @ToProgram = t2.programID
	      AND t1.userID = t2.userID
WHERE t1.programid = @FromProgram
      AND t2.id IS NULL;

--middle--
SELECT * FROM @users_programs_blocked;

DELETE FROM @users_programs_blocked 
WHERE programid = @FromProgram;

--after--
SELECT * FROM @users_programs_blocked;