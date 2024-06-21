-----------------------------------------------------------------------
-----------------------------------------------------------------------
----------------------------MLG_POS_DB---------------------------------
-----------------------------------------------------------------------
-----------------------------------------------------------------------
USE [master]
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'MLG_POS_DB')
BEGIN
    DROP DATABASE MLG_POS_DB;
	PRINT('Deleting DB');
END;
CREATE DATABASE MLG_POS_DB;
PRINT('Creating DB');
GO



-----------------------------------------------------------------------
--TABLE
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF OBJECT_ID('dbo.Pos_Clients_Tab', 'U') IS NOT NULL
	DROP TABLE dbo.Pos_Clients_Tab;
  
CREATE TABLE dbo.Pos_Clients_Tab(
	Id_Client INT PRIMARY KEY IDENTITY(1, 1),
	Nam_Name VARCHAR(150) NOT NULL,
	Nam_Surname VARCHAR(150) NOT NULL,
	Des_Address VARCHAR(250) NOT NULL,
	Des_Email VARCHAR(250) NOT NULL,
	Des_Password VARCHAR(100) NOT NULL,
	Date_Creation DATETIME NULL,
	Date_Last_Modified DATETIME NULL,
	Id_User_Creation INT NULL,
	Id_User_Last_Modif INT NULL,
	Id_Status BIT NOT NULL
)
GO



-----------------------------------------------------------------------
--TABLE
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF OBJECT_ID('dbo.Pos_Store_Tab', 'U') IS NOT NULL
	DROP TABLE dbo.Pos_Store_Tab;
  
CREATE TABLE dbo.Pos_Store_Tab(
	Id_Store INT PRIMARY KEY IDENTITY(1, 1),
	Des_Branch VARCHAR(250) NOT NULL,
	Des_Address VARCHAR(250) NOT NULL,
	Date_Creation DATETIME NULL,
	Date_Last_Modified DATETIME NULL,
	Id_User_Creation INT NULL,
	Id_User_Last_Modif INT NULL,
	Id_Status BIT NOT NULL
)
GO



-----------------------------------------------------------------------
--TABLE
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF OBJECT_ID('dbo.Pos_Articles_Tab', 'U') IS NOT NULL
	DROP TABLE dbo.Pos_Articles_Tab;
  
CREATE TABLE dbo.Pos_Articles_Tab(
	Id_Article INT PRIMARY KEY IDENTITY(1, 1),
	Cve_Code VARCHAR(250) NOT NULL,
	Des_Description VARCHAR(250) NOT NULL,
	Val_Price DECIMAL(18,2) NOT NULL,
	Img_Image VARBINARY(MAX) NULL,
	Val_Stock INT NOT NULL,
	Date_Creation DATETIME NULL,
	Date_Last_Modified DATETIME NULL,
	Id_User_Creation INT NULL,
	Id_User_Last_Modif INT NULL,
	Id_Status BIT NOT NULL
)
GO



-----------------------------------------------------------------------
--TABLE
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF OBJECT_ID('dbo.Pos_Articles_Store_Tab', 'U') IS NOT NULL
	DROP TABLE dbo.Pos_Articles_Store_Tab;
  
CREATE TABLE dbo.Pos_Articles_Store_Tab(
	Id_Article_Store INT PRIMARY KEY IDENTITY(1, 1),
	Id_Article INT NOT NULL,
	Id_Store INT NOT NULL,
	Date_Creation DATETIME NULL,
	Date_Last_Modified DATETIME NULL,
	Id_User_Creation INT NULL,
	Id_User_Last_Modif INT NULL,
	Id_Status BIT NOT NULL,
	CONSTRAINT fk_Article_Store FOREIGN KEY (Id_Article) REFERENCES Pos_Articles_Tab (Id_Article),
	CONSTRAINT fk_Store FOREIGN KEY (Id_Store) REFERENCES Pos_Store_Tab (Id_Store)
)
GO



-----------------------------------------------------------------------
--TABLE
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF OBJECT_ID('dbo.Pos_Clients_Articles_Tab', 'U') IS NOT NULL
	DROP TABLE dbo.Pos_Clients_Articles_Tab;
  
CREATE TABLE dbo.Pos_Clients_Articles_Tab(
	Id_Client_Article INT PRIMARY KEY IDENTITY(1, 1),
	Id_Client INT NOT NULL,
	Id_Article INT NOT NULL,
	Date_Creation DATETIME NULL,
	Date_Last_Modified DATETIME NULL,
	Id_User_Creation INT NULL,
	Id_User_Last_Modif INT NULL,
	Id_Status BIT NOT NULL,
	CONSTRAINT fk_Client_Article FOREIGN KEY (Id_Client) REFERENCES Pos_Clients_Tab (Id_Client),
	CONSTRAINT fk_Article FOREIGN KEY (Id_Article) REFERENCES Pos_Articles_Tab (Id_Article)
)
GO



-----------------------------------------------------------------------
--TABLE
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF OBJECT_ID('dbo.Pos_Roles_Tab', 'U') IS NOT NULL
	DROP TABLE dbo.Pos_Roles_Tab;
  
CREATE TABLE dbo.Pos_Roles_Tab(
	Id_Role INT PRIMARY KEY IDENTITY(1, 1),
	Nam_Role VARCHAR(150) NOT NULL,
	Date_Creation DATETIME NULL,
	Date_Last_Modified DATETIME NULL,
	Id_User_Creation INT NULL,
	Id_User_Last_Modif INT NULL,
	Id_Status BIT NOT NULL
)
GO


INSERT dbo.Pos_Roles_Tab (Nam_Role, Date_Creation, Date_Last_Modified, Id_User_Creation, Id_User_Last_Modif, Id_Status)
VALUES ('Administrador', GETDATE(), GETDATE(), NULL, NULL, 1),
('Comprador', GETDATE(), GETDATE(), NULL, NULL, 1)


-----------------------------------------------------------------------
--TABLE
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF OBJECT_ID('dbo.Pos_Clients_Roles_Tab', 'U') IS NOT NULL
	DROP TABLE dbo.Pos_Clients_Roles_Tab;
  
CREATE TABLE dbo.Pos_Clients_Roles_Tab(
	Id_Client_Role INT PRIMARY KEY IDENTITY(1, 1),
	Id_Client INT NOT NULL,
	Id_Role INT NOT NULL,
	Date_Creation DATETIME NULL,
	Date_Last_Modified DATETIME NULL,
	Id_User_Creation INT NULL,
	Id_User_Last_Modif INT NULL,
	Id_Status BIT NOT NULL,
	CONSTRAINT fk_Client_Role FOREIGN KEY (Id_Client) REFERENCES Pos_Clients_Tab (Id_Client),
	CONSTRAINT fk_Role FOREIGN KEY (Id_Role) REFERENCES Pos_Roles_Tab (Id_Role)
)
GO



-----------------------------------------------------------------------
--STORE PROCEDURE (Store)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Insert_Store_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Insert_Store_SP;
GO

CREATE PROCEDURE dbo.Pos_Insert_Store_SP
(
	@Des_Branch VARCHAR(250),
	@Des_Address VARCHAR(250)
)
AS
BEGIN
	
	INSERT INTO dbo.Pos_Store_Tab (Des_Branch, Des_Address, Date_Creation, Date_Last_Modified, Id_User_Creation, Id_User_Last_Modif, Id_Status)
	VALUES (@Des_Branch, @Des_Address, GETDATE(), GETDATE(), NULL, NULL, 1);
	
	SELECT TOP 1 * FROM  dbo.Pos_Store_Tab
	ORDER BY Id_Store DESC;
	
END
GO


-----------------------------------------------------------------------
--STORE PROCEDURE (Store)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Get_Stores_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Get_Stores_SP;
GO

CREATE PROCEDURE dbo.Pos_Get_Stores_SP
AS
BEGIN
	
	SELECT * FROM dbo.Pos_Store_Tab;
	
END
GO


-----------------------------------------------------------------------
--STORE PROCEDURE (Store)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Get_Store_ById_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Get_Store_ById_SP;
GO

CREATE PROCEDURE dbo.Pos_Get_Store_ById_SP
(
	@Id_Store INT
)
AS
BEGIN
	
	SELECT * FROM dbo.Pos_Store_Tab
	WHERE Id_Store = @Id_Store; 
	
END
GO


-----------------------------------------------------------------------
--STORE PROCEDURE (Store)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Update_Store_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Update_Store_SP;
GO

CREATE PROCEDURE dbo.Pos_Update_Store_SP
(
	@Id_Store INT,
	@Des_Branch VARCHAR(250),
	@Des_Address VARCHAR(250)
)
AS
BEGIN
	
	UPDATE dbo.Pos_Store_Tab
	SET Des_Branch = @Des_Branch , Des_Address = @Des_Address
	WHERE Id_Store = @Id_Store;
	
END
GO


-----------------------------------------------------------------------
--STORE PROCEDURE (Store)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Delete_Store_ById_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Delete_Store_ById_SP;
GO

CREATE PROCEDURE dbo.Pos_Delete_Store_ById_SP
(
	@Id_Store INT
)
AS
BEGIN
	
	DELETE FROM dbo.Pos_Store_Tab
	WHERE Id_Store = @Id_Store;
	
END
GO









-----------------------------------------------------------------------
--STORE PROCEDURE (Article)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Insert_Article_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Insert_Article_SP;
GO

CREATE PROCEDURE dbo.Pos_Insert_Article_SP
(
	@Cve_Code VARCHAR(250),
	@Des_Description VARCHAR(250),
	@Val_Price FLOAT,
	@Img_Image VARBINARY(MAX),
	@Val_Stock INT
)
AS
BEGIN
	
	INSERT INTO dbo.Pos_Articles_Tab (Cve_Code, Des_Description, Val_Price, Img_Image, Val_Stock, Date_Creation, Date_Last_Modified, Id_User_Creation, Id_User_Last_Modif, Id_Status)
	VALUES (@Cve_Code, @Des_Description, @Val_Price, @Img_Image, @Val_Stock, GETDATE(), GETDATE(), NULL, NULL, 1);
	
	SELECT TOP 1 * FROM  dbo.Pos_Articles_Tab
	ORDER BY Id_Article DESC;
	
END
GO


-----------------------------------------------------------------------
--STORE PROCEDURE (Article)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Get_Articles_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Get_Articles_SP;
GO

CREATE PROCEDURE dbo.Pos_Get_Articles_SP
AS
BEGIN
	
	SELECT * FROM dbo.Pos_Articles_Tab;
	
END
GO


-----------------------------------------------------------------------
--STORE PROCEDURE (Article)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Get_Article_ById_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Get_Article_ById_SP;
GO

CREATE PROCEDURE dbo.Pos_Get_Article_ById_SP
(
	@Id_Article INT
)
AS
BEGIN
	
	SELECT * FROM dbo.Pos_Articles_Tab
	WHERE Id_Article = @Id_Article; 
	
END
GO


-----------------------------------------------------------------------
--STORE PROCEDURE (Article)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Update_Article_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Update_Article_SP;
GO

CREATE PROCEDURE dbo.Pos_Update_Article_SP
(
	@Id_Article INT,
	@Cve_Code VARCHAR(250),
	@Des_Description VARCHAR(250),
	@Val_Price FLOAT,
	@Img_Image VARBINARY(MAX),
	@Val_Stock INT
)
AS
BEGIN
	
	UPDATE dbo.Pos_Articles_Tab
	SET Cve_Code = @Cve_Code , Des_Description = @Des_Description, Val_Price = @Val_Price, Img_Image = @Img_Image, Val_Stock = @Val_Stock
	WHERE Id_Article = @Id_Article;
	
END
GO


-----------------------------------------------------------------------
--STORE PROCEDURE (Article)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Delete_Article_ById_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Delete_Article_ById_SP;
GO

CREATE PROCEDURE dbo.Pos_Delete_Article_ById_SP
(
	@Id_Article INT
)
AS
BEGIN
	
	DELETE FROM dbo.Pos_Articles_Tab
	WHERE Id_Article = @Id_Article;
	
END
GO









-----------------------------------------------------------------------
--STORE PROCEDURE (Client)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Insert_Client_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Insert_Client_SP;
GO

CREATE PROCEDURE dbo.Pos_Insert_Client_SP
(
	@Nam_Name VARCHAR(150),
	@Nam_Surname VARCHAR(150),
	@Des_Address VARCHAR(250),
	@Des_Email VARCHAR(250),
	@Des_Password VARCHAR(100)
)
AS
BEGIN
	
	INSERT INTO dbo.Pos_Clients_Tab (Nam_Name, Nam_Surname, Des_Address, Des_Email, Des_Password, Date_Creation, Date_Last_Modified, Id_User_Creation, Id_User_Last_Modif, Id_Status)
	VALUES (@Nam_Name, @Nam_Surname, @Des_Address, @Des_Email, @Des_Password, GETDATE(), GETDATE(), NULL, NULL, 1);
	
	SELECT TOP 1 * FROM  dbo.Pos_Clients_Tab
	ORDER BY Id_Client DESC;
	
END
GO


-----------------------------------------------------------------------
--STORE PROCEDURE (Client)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Insert_ClientRole_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Insert_ClientRole_SP;
GO

CREATE PROCEDURE dbo.Pos_Insert_ClientRole_SP
(
	@Id_Client INT,
	@Id_Role INT
)
AS
BEGIN
	
	INSERT INTO dbo.Pos_Clients_Roles_Tab (Id_Client, Id_Role, Date_Creation, Date_Last_Modified, Id_User_Creation, Id_User_Last_Modif, Id_Status)
	VALUES (@Id_Client, @Id_Role, GETDATE(), GETDATE(), NULL, NULL, 1);
	
END
GO

-----------------------------------------------------------------------
--STORE PROCEDURE (Client)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Get_Clients_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Get_Clients_SP;
GO

CREATE PROCEDURE dbo.Pos_Get_Clients_SP
AS
BEGIN
	
	SELECT * FROM dbo.Pos_Clients_Tab;
	
END
GO


-----------------------------------------------------------------------
--STORE PROCEDURE (Client)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Get_Client_ById_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Get_Client_ById_SP;
GO

CREATE PROCEDURE dbo.Pos_Get_Client_ById_SP
(
	@Id_Client INT
)
AS
BEGIN
	
	SELECT * FROM dbo.Pos_Clients_Tab
	WHERE Id_Client = @Id_Client; 
	
END
GO


-----------------------------------------------------------------------
--STORE PROCEDURE (Client)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Update_Client_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Update_Client_SP;
GO

CREATE PROCEDURE dbo.Pos_Update_Client_SP
(
	@Id_Client INT,
	@Nam_Name VARCHAR(150),
	@Nam_Surname VARCHAR(150),
	@Des_Address VARCHAR(250),
	@Des_Email VARCHAR(250),
	@Des_Password VARCHAR(100)
)
AS
BEGIN
	
	UPDATE dbo.Pos_Clients_Tab
	SET Nam_Name = @Nam_Name , Nam_Surname = @Nam_Surname, Des_Address = @Des_Address, Des_Email = @Des_Email, Des_Password = @Des_Password
	WHERE Id_Client = @Id_Client;
	
	--SELECT * FROM dbo.Pos_Clients_Tab
	--WHERE Id_Client = @Id_Client;
	
END
GO



-----------------------------------------------------------------------
--STORE PROCEDURE (Client)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Delete_Client_ById_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Delete_Client_ById_SP;
GO

CREATE PROCEDURE dbo.Pos_Delete_Client_ById_SP
(
	@Id_Client INT
)
AS
BEGIN

	DELETE FROM dbo.Pos_Clients_Roles_Tab
	WHERE Id_Client = @Id_Client;
	
	DELETE FROM dbo.Pos_Clients_Tab
	WHERE Id_Client = @Id_Client;
	
END
GO








-----------------------------------------------------------------------
--STORE PROCEDURE (Client)
-----------------------------------------------------------------------
USE [MLG_POS_DB]
GO

IF (OBJECT_ID('dbo.Pos_Get_Client_Login_SP') IS NOT NULL)
  DROP PROCEDURE dbo.Pos_Get_Client_Login_SP;
GO

CREATE PROCEDURE dbo.Pos_Get_Client_Login_SP
(
	@email VARCHAR(250),
	@password VARCHAR(100)
)
AS
BEGIN
	
	SELECT Id_Client FROM dbo.Pos_Clients_Tab
	WHERE Des_Email = @email AND Des_Password = @password; 
	
END
GO