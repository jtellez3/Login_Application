-- Running this script in SQL Server Management Studio
IF DB_ID(N'LoginDatabase') IS NULL
    CREATE DATABASE LoginDatabase;
GO
USE LoginDatabase;
GO
-- Each user has a unique username and a salted password hash never a readable password.
IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users (
        UserID INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(50) COLLATE Latin1_General_100_CI_AS NOT NULL UNIQUE,
        PasswordHash VARBINARY(32) NOT NULL,
        PasswordSalt VARBINARY(16) NOT NULL,
        Iterations INT NOT NULL
    );
END;
GO
-- Running this query after creating an account to see the stored records.
SELECT UserID, Username, PasswordHash, PasswordSalt, Iterations FROM dbo.Users;
