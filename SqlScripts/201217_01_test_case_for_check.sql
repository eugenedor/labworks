DECLARE @users TABLE (userID INT);
DECLARE @users_programs_blocked TABLE (ID INT IDENTITY(1,1), userID INT, programID INT);

INSERT INTO @users (userID) VALUES 
(11),
(12);

INSERT INTO @users_programs_blocked (userID, programID) VALUES 
(11, 100), 
(12, 101), 
(12, 102);

DECLARE @programID INT;
DECLARE @userID INT;

SET @programID = 101;

--
----userID = 11--
--
SET @userID = 11;

SELECT 1
FROM @users_programs_blocked upb
WHERE upb.programID = @programID
	  and upb.userID = @userID;

SELECT 1
FROM @users u
WHERE 
    EXISTS (SELECT 1 
	        FROM @users_programs_blocked upb
			WHERE upb.programID = @programID
	              AND upb.userID = u.userID)
    AND u.userID = @userID;


--
----userID = 12--
--
SET @userID = 12;

SELECT 1
FROM @users_programs_blocked upb
WHERE upb.programID = @programID
	  and upb.userID = @userID;

SELECT 1
FROM @users u
WHERE 
    EXISTS (SELECT 1 
	        FROM @users_programs_blocked upb
			WHERE upb.programID = @programID
	              AND upb.userID = u.userID)
    AND u.userID = @userID;