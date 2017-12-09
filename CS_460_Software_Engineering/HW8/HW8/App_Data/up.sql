CREATE TABLE dbo.Artists
(
	[ArtistId] INT IDENTITY (1,1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[BirthCity] VARCHAR(128) NOT NULL,
	[DoB] DATETIME2 NOT NULL

	CONSTRAINT [PK_dbo.Artists] PRIMARY KEY (ArtistId)
);

CREATE TABLE dbo.Genres
(
	[GenreId] INT IDENTITY (1,1) NOT NULL,
	[Name] VARCHAR(128) NOT NULL

	CONSTRAINT [PK_dbo.Genres] PRIMARY KEY (GenreId),
	CONSTRAINT [UC_dbo.Genres] UNIQUE (Name)
);

CREATE TABLE dbo.ArtWorks
(
	[ArtWorkId] INT IDENTITY (1,1) NOT NULL,
	[ArtistId] INT NOT NULL,
	[Title] VARCHAR(512) NOT NULL

	CONSTRAINT [PK_dbo.ArtWorks] PRIMARY KEY (ArtWorkId),
	CONSTRAINT [FK_dbo.ArtWorks] FOREIGN KEY (ArtistId) REFERENCES Artists
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

CREATE TABLE dbo.Classifications
(
	[ClassificationId] INT IDENTITY (1,1) NOT NULL,
	[GenreId] INT NOT NULL,
	[ArtWorkId] INT NOT NULL

	CONSTRAINT [PK_dbo.Classifications] PRIMARY KEY (ClassificationId),
	CONSTRAINT [FK1_dbo.Classifications] FOREIGN KEY (GenreId) REFERENCES Genres
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT [FK2_dbo.Classifications] FOREIGN KEY (ArtWorkId) REFERENCES ArtWorks
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

INSERT INTO dbo.Genres ([Name]) VALUES
	('Tesselation'),
	('Surrealism'),
	('Portrait'),
	('Renaissance');

INSERT INTO dbo.Artists ([Name],[BirthCity],[DoB]) VALUES
	('M.C. Escher','Leeuwarden, Netherlands', '1898-06-17'),
	('Leonardo Da Vinci', 'Vinci, Italy', '1519-05-02'),
	('Hatip Mehmed Efendi', 'Unknown', '1680-11-18'),
	('Salvador Dali', 'Figueres, Spain', '1904-05-11');

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