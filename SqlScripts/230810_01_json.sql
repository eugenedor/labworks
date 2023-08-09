DECLARE @json VARCHAR(MAX);

--Packing--
WITH ds AS (SELECT 0 clmnKey, 'a' clmnName
			UNION ALL
			SELECT 1 clmnKey, 'b' clmnName
			UNION ALL
			SELECT 2 clmnKey, 'c' clmnName)
SELECT @json = (SELECT * FROM ds FOR JSON PATH)

SELECT @json;


--Unpacking--
SET @json = '[{"clmnKey":0,"clmnName":"a"},{"clmnKey":1,"clmnName":"b"},{"clmnKey":2,"clmnName":"c"},{"clmnKey":3,"clmnName":"d"}]';

SELECT * FROM OPENJSON(@json) WITH (
columnKey INT '$.clmnKey',
columnName VARCHAR(100) '$.clmnName'
);