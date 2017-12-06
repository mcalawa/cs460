CREATE TABLE dbo.Directors
(
	[DirectorId] INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[Name] VARCHAR(128) NOT NULL
);

CREATE TABLE dbo.Actors
(
	[ActorId] INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[Name] VARCHAR(128) NOT NULL
);

CREATE TABLE dbo.Movies
(
	[MovieId] INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[DirectorId] INT NOT NULL,
	[Title] VARCHAR(512) NOT NULL,
	[Year] INT NOT NULL,
	FOREIGN KEY(DirectorId) REFERENCES Directors
);

CREATE TABLE dbo.Casts
(
	[CastId] INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[ActorId] INT NOT NULL,
	[MovieId] INT NOT NULL,
	FOREIGN KEY(ActorId) REFERENCES Actors,
	FOREIGN KEY(MovieId) REFERENCES Movies
);

INSERT INTO dbo.Directors ([Name]) VALUES
	('Rian Johnson'),
	('Kenneth Branagh'),
	('Rob Marshall'),
	('James Marsh');

INSERT INTO dbo.Actors ([Name]) VALUES
	('Daisy Ridley'),
	('Andy Serkis'),
	('Benicio Del Toro'),
	('Penelope Cruz');

INSERT INTO dbo.Movies ([Title],[Year],[DirectorId]) VALUES
	('Star Wars: The Last Jedi',2017,1),
	('Murder on the Orient Express',2017,2),
	('Pirates of the Caribbean: On Stranger Tides',2011,3),
	('The Theory of Everything',2014,4);

INSERT INTO dbo.Casts ([ActorId],[MovieId]) VALUES
	(1,1),
	(2,1),
	(3,1),
	(1,2),
	(4,2),
	(4,3);