CREATE DATABASE ExamenLiveMed
GO

USE ExamenLiveMed
GO

CREATE TABLE Country
(
Id_country INT PRIMARY KEY IDENTITY (1,1),
Country VARCHAR (50)
)
GO


INSERT INTO Country
           ([Country])
     VALUES
           ('Francia')
GO

INSERT INTO Country
           ([Country])
     VALUES
           ('Mexico')
GO


CREATE TABLE Usuario
(
Id_user INT IDENTITY (1,1),
Usuario VARCHAR (50),
Id_country INT,

CONSTRAINT Fk_CountryUsuario FOREIGN KEY (Id_country)
REFERENCES Country (Id_country)
)

GO

ALTER TABLE Usuario
DROP CONSTRAINT Fk_CountryUsuario;
GO


INSERT INTO Usuario
           ([Usuario]
           ,[Id_country])
     VALUES
           ('Estefany'
           ,1)

GO

INSERT INTO Usuario
           ([Usuario]
           ,[Id_country])
     VALUES
           ('Carla'
           ,2)

GO

INSERT INTO Usuario
           ([Usuario]
           ,[Id_country])
     VALUES
           ('Oscar'
           ,3)

GO


SELECT [Id_user]
      ,Usuario
      ,Usuario.Id_country
	  ,Country.Country
  FROM [dbo].[Usuario]

  LEFT JOIN Country ON Country.Id_country = Usuario.Id_country
GO

