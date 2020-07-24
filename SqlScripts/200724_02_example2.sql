DECLARE @t TABLE (id INT IDENTITY(1,1), pers INT, dat INT, sm INT);

INSERT INTO @t (pers, dat, sm) 
VALUES (1, 1, 10), (1, 2, 20), (1, 2, 30), 
       (2, 1, 10), (2, 2, 20), (2, 3 ,30);

SELECT * FROM @t t;

SELECT t.id, t.pers, t.dat,
       (SELECT SUM(tt.sm)
	    FROM @t tt
		WHERE tt.pers = t.pers) s1,
(SELECT SUM(tt.sm)
	    FROM @t tt
		WHERE tt.dat = (SELECT MAX(ttt.dat) 
		                FROM @t ttt
						WHERE ttt.pers = t.pers)
			  AND tt.pers = t.pers) s2
FROM @t t;