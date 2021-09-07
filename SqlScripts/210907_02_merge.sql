DECLARE @t TABLE (id INT IDENTITY(1,1), login NVARCHAR(50), surname NVARCHAR(250), name NVARCHAR(250));

INSERT INTO @t (login, surname, name) VALUES 
('iva', 'Иванов', 'Иван'),
('petro', 'Петров', 'Сергей');

SELECT * FROM @t t;

DECLARE @login NVARCHAR(50),
        @surname NVARCHAR(250), 
        @name NVARCHAR(250);


--1--
SET @login = 'petro';
SET @surname = 'Петров1';
SET @name = 'Петр';

MERGE @t AS tgt  
USING (SELECT @login, @surname, @name) AS src (login, surname, name)  
ON (tgt.login = src.login)  
WHEN MATCHED THEN
    UPDATE SET name = src.name  
WHEN NOT MATCHED THEN  
    INSERT (login, surname, name)  
    VALUES (src.login, src.surname, src.name);

SELECT * FROM @t t;


--2--
SET @login = 'sidr';
SET @surname = 'Сидоров';
SET @name = 'Сидр';

MERGE @t AS tgt  
USING (SELECT @login, @surname, @name) AS src (login, surname, name)  
ON (tgt.login = src.login)  
WHEN MATCHED THEN
    UPDATE SET name = src.name  
WHEN NOT MATCHED THEN  
    INSERT (login, surname, name)  
    VALUES (src.login, src.surname, src.name);

SELECT * FROM @t t;