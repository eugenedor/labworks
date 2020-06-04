USE TEST;
GO

DECLARE @price DECIMAL(17,2),
        @vat DECIMAL(17,2);

SET @price = CAST(1616 AS DECIMAL(17,2));

--vat = 18
SET @vat = 18;
SELECT t.PriceWithVat, 
       t.PriceWithoutVat,
	   t.Vat,
	   CAST(ROUND(t.PriceWithoutVat*((100 + CAST(@vat AS DECIMAL(17,2)))/100), 2) AS DECIMAL(17,2)) PriceWithVatTest
FROM
(SELECT @price AS PriceWithVat,
        CAST(ROUND(@price*100/(100 + @vat), 2) AS DECIMAL(17,2)) As PriceWithoutVat,
	    @vat AS Vat) t;

--vat = 20
SET @vat = 20;
SELECT t.PriceWithVat, 
       t.PriceWithoutVat,
	   t.Vat,
	   CAST(ROUND(t.PriceWithoutVat*((100 + CAST(@vat AS DECIMAL(17,2)))/100), 2) AS DECIMAL(17,2)) PriceWithVatTest
FROM
(SELECT @price AS PriceWithVat,
        CAST(ROUND(@price*100/(100 + @vat), 2) AS DECIMAL(17,2)) As PriceWithoutVat,
	    @vat AS Vat) t