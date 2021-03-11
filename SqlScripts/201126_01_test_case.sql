DECLARE @users_partners TABLE (ID INT IDENTITY(1,1), userID INT, partnerID INT);
DECLARE @partners_programs TABLE (ID INT IDENTITY(1,1), partnerID INT, programID INT);
DECLARE @users_programs_blocked TABLE (ID INT IDENTITY(1,1), userID INT, programID INT);

INSERT INTO @users_partners (userID, partnerID) VALUES 
(11, 1), 
(12, 1), 
(13, 1), 
(21, 2), 
(22, 2);

INSERT INTO @partners_programs (partnerID, programID) VALUES 
(1, 101), 
(1, 102), 
(1, 103), 
(2, 101), 
(2, 104);

INSERT INTO @users_programs_blocked (userID, programID) VALUES 
(12, 102), 
(13, 102), 
(13, 103);

--var 1--
SELECT up.partnerID, up.userID, pp.programID, CASE WHEN upb.ID IS NULL THEN 'used' ELSE 'blocked' END as isUse, upb.ID
FROM @users_partners up
     JOIN @partners_programs pp
	   ON up.partnerID = pp.partnerID
	 LEFT JOIN @users_programs_blocked upb
	   ON pp.programID = upb.programID
		  AND up.userID = upb.userID 
--WHERE upb.ID IS NULL;


--var 2
SELECT up.partnerID, up.userID, pp.programID
FROM @users_partners up, @partners_programs pp 
WHERE up.partnerID = pp.partnerID
      AND (up.userID NOT IN (select userID from @users_programs_blocked)
	       OR pp.programID NOT IN (select programID from @users_programs_blocked where userID = up.userID));


--antivar
SELECT up.partnerID, up.userID, pp.programID
FROM @users_partners up, @partners_programs pp 
WHERE up.partnerID = pp.partnerID
      AND up.userID IN (select userID from @users_programs_blocked)
	  AND pp.programID IN (select programID from @users_programs_blocked where userID = up.userID);