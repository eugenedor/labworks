USE master;  
GO 
 
IF DB_ID (N'Test') IS NOT NULL
	DROP DATABASE Test;
GO


PRINT '<<< CREATE DATABASE TEST >>>'
GO
CREATE DATABASE Test
ON 
( NAME = Test,
    FILENAME = 'E:\databases\Test.mdf',
    SIZE = 10,
    MAXSIZE = 50,
    FILEGROWTH = 5 )
LOG ON
( NAME = ToolsStore_log,
    FILENAME = 'E:\databases\Test.ldf',
    SIZE = 5MB,
    MAXSIZE = 25MB,
    FILEGROWTH = 5MB ) ;
GO


-- Verify the database files and sizes  
SELECT name, size, size*1.0/128 AS [Size in MBs]   
FROM sys.master_files  
WHERE name = N'Test';  
GO