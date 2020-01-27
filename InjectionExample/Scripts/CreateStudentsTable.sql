DROP TABLE [dbo].[Students]

CREATE TABLE [dbo].[Students]
(
	[StudentId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [DOB] DATE NOT NULL, 
    [Phone] NVARCHAR(24) NULL
);

INSERT INTO [dbo].[Students] (FirstName, LastName, DOB, Phone)
VALUES ('John', 'Smith', '19700101', NULL);
INSERT INTO [dbo].[Students] (FirstName, LastName, DOB, Phone)
VALUES ('Shinji', 'Ikari', '20010606', NULL);
INSERT INTO [dbo].[Students] (FirstName, LastName, DOB, Phone)
VALUES ('Tanjiro', 'Kamado', '19180714', '0123456789')
INSERT INTO [dbo].[Students] (FirstName, LastName, DOB, Phone)
VALUES ('Giorno', 'Giovanna', '19850416', NULL);

SELECT *
FROM [dbo].[Students]