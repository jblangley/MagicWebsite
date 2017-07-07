--CREATE DATABASE Capstone
 
USE Capstone
 
 
--CREATE TABLE UserInfo
--(
--Id INT PRIMARY KEY IDENTITY,
--FirstName VARCHAR(50) NOT NULL,
--LastName VARCHAR(50) NOT NULL,
--UserName VARCHAR(50) NOT NULL,
--[Password] VARCHAR(50) NOT NULL,
--Email VARCHAR(MAX) NOT NULL,
--[Role] VARCHAR(10) DEFAULT('User')
--);
 
 
 
--CREATE TABLE Cards
--(
--Id INT PRIMARY KEY IDENTITY,
--PictureURL VARCHAR(MAX) NOT NULL,
--Name VARCHAR(MAX) NOT NULL,
--CMC INT NOT NULL,
--CardColor VARCHAR(15) NOT NULL,
--Attack INT,
--Defense INT,
--Cardtype VARCHAR(15) NOT NULL,
--Subtype VARCHAR(20),
--Ability VARCHAR(MAX),
--Rarity VARCHAR(15) DEFAULT('Common'),
--[Set] VARCHAR(50),
--Flavortext VARCHAR(MAX)
--);
 
--CREATE TABLE Deck
--(
--Id INT PRIMARY KEY IDENTITY,
--Name VARCHAR(25) NOT NULL,
--CardCount INT
--);
 
--CREATE TABLE User_Deck
--(
--Id INT PRIMARY KEY IDENTITY,
--UserId INT FOREIGN KEY REFERENCES UserInfo (Id),
--DeckId INT FOREIGN KEY REFERENCES Deck (Id)
-- );

--CREATE TABLE Card_Deck
--(
--Id INT PRIMARY KEY IDENTITY,
--CardId INT FOREIGN KEY REFERENCES Cards (Id),
--DeckId INT FOREIGN KEY REFERENCES Deck (Id)
--);

-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[AddCardToDeck]
--@CardId INT
--, @DeckId INT
--AS
--BEGIN
--INSERT INTO Card_Deck
--VALUES (@CardId, @DeckId)
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[CreateCard]
--@PictureURL VARCHAR(MAX),
--@Name VARCHAR(MAX),
--@CMC INT,
--@CardColor VARCHAR(15),
--@Attack INT,
--@Defense INT,
--@Cardtype VARCHAR(15),
--@Subtype VARCHAR(20),
--@Ability VARCHAR(MAX),
--@Flavortext VARCHAR(MAX),
--@Rarity VARCHAR(15),
--@Set VARCHAR(50) 
--AS
--BEGIN
--INSERT INTO Cards
--VALUES (@PictureURL,@Name,@CMC,@CardColor,@Attack,@Defense,@Cardtype,@Subtype,@Ability,@Rarity,@Set,@Flavortext)
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[CreateDeck]
--@Name VARCHAR(25)
--, @CardCount INT
--, @UserId INT
--, @DeckId INT
--AS
--BEGIN
--INSERT INTO Deck
--VALUES (@Name,@CardCount)
--Select @DeckId = SCOPE_IDENTITY() 	
--Insert Into User_Deck
--Values (@UserId,@DeckId)
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[CreateUser]
-- @FirstName VARCHAR(50)
--, @LastName VARCHAR(50)
--, @UserName VARCHAR(20)
--, @Password VARCHAR(50)
--, @Email VARCHAR(MAX)
--, @Role VARCHAR(10)
 
--AS
--BEGIN
--INSERT INTO UserInfo
--VALUES (@FirstName,@LastName,@UserName,@Password,@Email,@Role)
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[CreateUserDeckConnection]
--@User INT
--,@CardId INT
--AS
--BEGIN	
--Insert Into User_Deck
--Values (@User,@CardId)
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[DeleteCard]
--	@ID INT
--AS
--BEGIN
--	DELETE 
--	FROM Cards
--	WHERE ID=@ID
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[DeleteCardDeckConnection]
--@CardId INT
--, @DeckId INT
--AS
--BEGIN
--DELETE TOP (1) FROM Card_Deck
--WHERE CardId=@CardId
--AND DeckId = @DeckId
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[DeleteDeck]
--@ID INT
--AS
--BEGIN
--DELETE from Card_Deck
--WHERE Card_Deck.DeckId = @ID 
--DELETE FROM User_Deck
--WHERE User_Deck.DeckId = @ID
--DELETE FROM Deck
--WHERE Deck.Id = @ID
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[DeleteUser] 
-- @ID INT
--AS
--BEGIN
--DELETE FROM UserInfo
--WHERE ID=@ID
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[GetCardDetail] 
--	@Name VARCHAR(MAX)
--AS
--BEGIN
--	SELECT *
--	FROM Cards
--	WHERE Name=@Name
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[GetDecks]
--@Id INT
--AS
--BEGIN
--SELECT Deck.*
--FROM Deck
--inner JOIN User_Deck 
--on Deck.Id = User_Deck.DeckId
--where User_Deck.UserId = @Id
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[GetSingleDeck]
--	@Id INT
--AS
--BEGIN
--	SELECT Cards.*
--FROM Cards
--INNER JOIN Card_Deck
--ON Cards.Id = Card_Deck.CardId
--WHERE Card_Deck.DeckId = @Id
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[GetUser]
--@Email VARCHAR(MAX)
--AS
--BEGIN
-- SELECT *
-- FROM  UserInfo
-- WHERE Email = @Email
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[ReadAllCards]
 
--AS
--BEGIN
--	SELECT *
--	FROM Cards
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[ReadAllUsers] 
 
--AS
--BEGIN
--SELECT *
--FROM UserInfo
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[UpdateCard]
--@Id INT,
--@PictureURL VARCHAR(MAX),
--@Name VARCHAR(MAX),
--@CMC INT,
--@CardColor VARCHAR(15),
--@Attack INT,
--@Defense INT,
--@Cardtype VARCHAR(15),
--@Subtype VARCHAR(20),
--@Ability VARCHAR(MAX),
--@Rarity VARCHAR(15),
--@Set VARCHAR(50),
--@Flavortext VARCHAR(MAX)
--AS
--BEGIN
--	UPDATE Cards
--SET PictureURL=@PictureURL, Name=@Name, CMC=@CMC, CardColor=@CardColor,  Attack=@Attack, Defense=@Defense, Cardtype=@Cardtype
--, Subtype=@Subtype, Ability=@Ability, Rarity=@Rarity, [Set]=@Set, Flavortext=@Flavortext
--WHERE ID=@ID
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--ALTER PROCEDURE [dbo].[UpdateUser] 
-- @FirstName VARCHAR(50)
--, @LastName VARCHAR(50)
--, @UserName VARCHAR(20)
--, @Password VARCHAR(50)
--, @Email VARCHAR(MAX)
--, @Role VARCHAR(10)
--, @ID INT
--AS
--BEGIN
--UPDATE UserInfo
--SET FirstName= @FirstName,LastName=@LastName,UserName=@UserName,[Password]=@Password,Email=@Email,[Role]=@Role
--WHERE ID=@ID
--END
-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


--QUICK QUERIES


select *
from Cards

Select *
from Card_Deck

select *
from Deck

select *
from UserInfo

select *
from User_Deck


--Update UserInfo
--set Role= 'Admin'
--Where Id = 2