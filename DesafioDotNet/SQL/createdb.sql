USE master
GO
-- Recria o banco de dados. Fica mais facil desenvolver sobre isso
IF EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'Desafio'
)
DECLARE @DatabaseName nvarchar(50)
SET @DatabaseName = N'Desafio'

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
-- Helpers
CREATE FUNCTION str2uniq(@s VARCHAR(50)) RETURNS UNIQUEIDENTIFIER AS BEGIN
    -- just in case it came in with 0x prefix or dashes...
    SET @s = replace(replace(@s,'0x',''),'-','')
    -- inject dashes in the right places
    SET @s = stuff(stuff(stuff(stuff(@s,21,0,'-'),17,0,'-'),13,0,'-'),9,0,'-')
    RETURN cast(@s AS uniqueidentifier)
END
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
        INSERT INTO [dbo].[Products] VALUES(NEWID(),@currentDate,@currentDate,FORMATMESSAGE('Product N %d',@i),0.99 * @i,'Default Brand')
    END
END
GO
EXEC seed_products
GO