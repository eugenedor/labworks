SET CONCAT_NULL_YIELDS_NULL, ANSI_NULLS, ANSI_PADDING, QUOTED_IDENTIFIER, ANSI_WARNINGS, ARITHABORT, XACT_ABORT ON
SET NUMERIC_ROUNDABORT, IMPLICIT_TRANSACTIONS OFF
GO

--
-- ������� ����� ��� ��������� ����� ���� ������
--
IF OBJECT_ID('xp_create_subdir') IS NOT NULL
  EXEC xp_create_subdir N'E:\backup'
GO

--
-- ������� ��������� ����� ���� ������ � ���� � ������: <���_����_������>_<����>_<��>_<��>_<��>_<���>.bak
--
DECLARE @db_name SYSNAME
SET @db_name = N'Test'

DECLARE @filepath NVARCHAR(4000)
SET @filepath = N'E:\backup\' + @db_name + '_backup_' +                                       /*���������� �������� �����*/ 
				REPLACE(CONVERT(NVARCHAR(10), GETDATE(), 2), '.', '') + '_' +                 /*�������� ����*/ 
                REPLACE(CONVERT(NVARCHAR(5), GETDATE(), 8), ':', '') + '.bak'                 /*�������� �����*/

DECLARE @SQL NVARCHAR(MAX)
SET @SQL = 
    N'BACKUP DATABASE ' + QUOTENAME(@db_name) + ' TO DISK = @filepath WITH INIT' + 
      CASE WHEN EXISTS(
                SELECT value
                FROM sys.configurations
                WHERE name = 'backup compression default'
          )
        THEN ', COMPRESSION'
        ELSE ''
      END

EXEC sys.sp_executesql @SQL, N'@filepath NVARCHAR(4000)', @filepath = @filepath
GO