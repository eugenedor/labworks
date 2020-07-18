DECLARE @t TABLE (id INT IDENTITY(1,1), accredit INT, covering INT);

INSERT INTO @t (accredit, covering) VALUES (90907, 40401), (90908, 40401), (90909, 40401), (90910, 40402), (90911, 40402);

--0--
SELECT t.id, t.accredit, t.covering
FROM @t t;

--1--
WITH aa AS (SELECT t.id, t.accredit, t.covering
            FROM @t t)

SELECT a1.covering, 
       a1.accredit AS accredit1, 
	   a2.accredit AS accredit2
FROM aa a1
     JOIN aa a2
	   ON a1.covering = a2.covering
	      AND a1.accredit < a2.accredit
ORDER BY a1.covering, a1.accredit, a2.accredit;