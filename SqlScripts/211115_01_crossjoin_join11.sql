DECLARE @users_programs_blocked TABLE (ID INT IDENTITY(1,1), userID INT, programID INT);
INSERT INTO @users_programs_blocked (userID, programID) VALUES (1, 12), (2, 11);

DECLARE @u TABLE (userID INT);
INSERT INTO @u (userID) VALUES (1), (2), (3);

DECLARE @p TABLE (programID INT);
INSERT INTO @p (programID) VALUES (11), (12);

SELECT * FROM @users_programs_blocked;
--SELECT * FROM @u;
--SELECT * FROM @p;

--VAR1--
SELECT u.userid, p.programId
FROM @u u
     CROSS JOIN @p p
	 LEFT JOIN @users_programs_blocked upb
	   ON u.userID = upb.userID 
	      AND p.programId = upb.programID
WHERE upb.ID IS NULL
ORDER BY u.userid, p.programId;

--VAR2--
SELECT u.userid, p.programId
FROM @u u
     JOIN @p p ON 1=1
WHERE
NOT EXISTS(SELECT * 
           FROM @users_programs_blocked upb 
		   WHERE u.userID = upb.userID 
		         AND p.programId = upb.programID)
ORDER BY u.userid, p.programId;