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

SELECT * FROM @users_programs_blocked;

/*UPDATE*/ SELECT id, programid AS FromProgram, @ToProgram AS ToProgram, userID FROM @users_programs_blocked
--SET programID = @ToProgram
WHERE 
	programid = @FromProgram
	AND userID NOT IN 
		(	
			SELECT userID
			FROM @users_programs_blocked
			WHERE programid = @ToProgram
		);

--myVar
SELECT t1.id, t1.programid AS FromProgram, @ToProgram AS ToProgram, t1.userID,
       t2.id
FROM @users_programs_blocked t1
     LEFT JOIN @users_programs_blocked t2
	   ON @ToProgram = t2.programID
	      AND t1.userID = t2.userID
WHERE t1.programid = @FromProgram
      AND t2.id IS NULL;

/*DELETE*/ SELECT * FROM @users_programs_blocked 
WHERE programid = @FromProgram;