DECLARE @t TABLE (id INT IDENTITY(1,1), surname1 VARCHAR(250), name1 VARCHAR(250), surname2 VARCHAR(250), name2 VARCHAR(250));

INSERT INTO @t (surname1, name1, surname2, name2)
VALUES ('����������', '������', '������', '����'), 
       ('����������', '����', NULL, NULL),
       ('������', '����', NULL, NULL), 
	   ('������', '������', NULL, NULL), 
	   ('����������', '������', NULL, NULL), 
       ('������', '����', NULL, NULL);
	   

SELECT * FROM @t;

--duplicateTop
SELECT *
FROM @t t1
WHERE (SELECT COUNT(t2.id)
       FROM @t t2
	   WHERE (t2.surname1 = t1.surname1 OR t2.surname1 = t1.surname2)
			  AND 
			 (t2.name1 = t1.name1 OR t2.name1 = t1.name2)) > 1;

--duplicateBottom
SELECT *
FROM @t t1
WHERE (SELECT COUNT(t2.id)
       FROM @t t2
	   WHERE (t2.surname2 = t1.surname1 OR t2.surname2 = t1.surname2)
			  AND 
			 (t2.name2 = t1.name1 OR t2.name2 = t1.name2)) > 1;


--!--
--good--
SELECT *
FROM @t t2
WHERE (t2.surname1 = '����������' OR t2.surname1 = '������')
	  AND 
	  (t2.name1 = '������' OR t2.name1 = '����');


--bad--
SELECT *
FROM @t t2
WHERE (t2.surname1 = '����������' AND t2.name1 = '������' )
	   OR 
	  (t2.surname1 = '������' AND t2.name1 = '����');

SELECT *
FROM @t t2
WHERE (t2.surname1 = '������' AND t2.name1 = '����' )
	   OR 
	  (t2.surname2 = '������' AND t2.name2 = '����');