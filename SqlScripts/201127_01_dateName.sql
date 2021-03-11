DECLARE @date DATETIME = GETDATE();

SELECT @date AS d, 
       FORMAT(@date, 'MMMM') AS _mNameRu,
       FORMAT(@date, 'MMMM', 'ru-ru') AS _mNameRu, 
       DATENAME(mm, @date) AS _mName, 
	   MONTH(@date) AS _mNum, 
	   DATEADD(mm, MONTH(@date), -1) AS _d, 
	   DATENAME(mm, DATEADD(mm, MONTH(@date), -1)) AS _mName2;