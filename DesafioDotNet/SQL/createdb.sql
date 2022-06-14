USE master
GO
-- Recria o banco de dados. Fica mais facil desenvolver sobre isso
IF EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'DesafioDb'
)
DECLARE @DatabaseName nvarchar(50)
SET @DatabaseName = N'DesafioDb'

DECLARE @SQL varchar(max)

SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
FROM MASTER..SysProcesses
WHERE DBId = DB_ID(@DatabaseName) AND SPId <> @@SPId

--SELECT @SQL 
EXEC(@SQL)
GO
DROP DATABASE DesafioDb
GO
CREATE DATABASE DesafioDb
GO
USE DesafioDb
GO

CREATE TABLE [dbo].[Products](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,        
    [CreatedAt] [datetimeoffset](7) NOT NULL,
    [UpdatedAt] [datetimeoffset](7) NOT NULL,
    [Name] [nvarchar](255) NOT NULL,
    [Price] decimal(10,2) NOT NULL,
    [Brand] [nvarchar](255) NOT NULL,
)
GO
CREATE OR ALTER PROCEDURE seed_products AS BEGIN    
    DECLARE @i int = 0
    DECLARE @currentDate DATETIMEOFFSET = GETUTCDATE()     
    WHILE @i < 5
    BEGIN
        SET @i = @i + 1
        SET @currentDate = GETUTCDATE()
        INSERT INTO [dbo].[Products] VALUES(@currentDate,@currentDate,FORMATMESSAGE('Product N %d',@i),0.99 * @i,'Default Brand')
    END
END
GO
EXEC seed_products
GO
SELECT * FROM [dbo].[Products]