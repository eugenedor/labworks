DECLARE @DateBegin DATETIME,  
        @DateEnd   DATETIME,
        @Range INT; 

SET @DateBegin = CONVERT(DATETIME, '12.05.2020', 104);
SET @DateEnd = CONVERT(DATETIME, '01.07.2020', 104);

SET @Range = DATEDIFF(DAY, @DateBegin, @DateEnd)+1;
SELECT @DateBegin AS DateBegin, @DateEnd AS DateEnd, @Range AS [Range]
  
SELECT @Range / 7 * 5                                                              --whole part
		+ @Range % 7                                                               --modulo
		- (SELECT COUNT(*)                                                         --modulo (weekend)
		   FROM (SELECT d 
				 FROM (VALUES (1),(2),(3),(4),(5),(6),(7)) v(d)) tWeek
           WHERE d <= @Range % 7  
                 AND DATEPART(WEEKDAY, @DateEnd - d + 1) IN (1, 7)) AS CntWeekDays; --days: sunday, saturday