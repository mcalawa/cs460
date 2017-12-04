CREATE TABLE dbo.Artists
(
	[ArtistId] INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[BirthCity] VARCHAR(128) NOT NULL,
	[DoB] DATETIME NOT NULL
);

CREATE TABLE dbo.Genres
(
	[GenreId] INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[Name] VARCHAR(128) NOT NULL UNIQUE
);

CREATE TABLE dbo.ArtWorks
(
	[ArtWorkId] INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[ArtistId] INT NOT NULL,
	[Title] VARCHAR(512) NOT NULL,
	FOREIGN KEY(ArtistId) REFERENCES Artists
);

CREATE TABLE dbo.Classifications
(
	[ClassificationId] INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[GenreId] INT NOT NULL,
	[ArtWorkId] INT NOT NULL,
	FOREIGN KEY(GenreId) REFERENCES Genres,
	FOREIGN KEY(ArtWorkId) REFERENCES ArtWorks
);

INSERT INTO dbo.Genres ([Name]) VALUES
	('Tesselation'),
	('Surrealism'),
	('Portrait'),
	('Renaissance');

INSERT INTO dbo.Artists ([Name],[BirthCity],[DoB]) VALUES
	('M.C. Escher','Leeuwarden, Netherlands', 06-17-1898),
	('Leonardo Da Vinci', 'Vinci, Italy', 05-02-1519),
	('Hatip Mehmed Efendi', 'Unknown', 11-18-1680),
	('Salvador Dali', 'Figueres, Spain', 05-11-1904);

INSERT INTO dbo.ArtWorks ([ArtistId],[Title]) VALUES
	('1', 'Circle Limit III'),
	('1', 'Twon Tree'),
	('2', 'Mona Lisa'),
	('2', 'The Vitruvian Man'),
	('3', 'Ebru'),
	('4', 'Honey Is Sweeter Than Blood');

INSERT INTO dbo.Classifications ([GenreId],[ArtWorkId]) VALUES
	('1','1'),
	('1','2'),
	('2','2'),
	('3','3'),
	('4','3'),
	('4','4'),
	('1','5'),
	('2','6');

GO