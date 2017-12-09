INSERT INTO dbo.Genres ([Name]) VALUES
	('Yoko-e'),
	('Landscape'),
	('Ukiyo-e'),
	('Woodblock Print');

INSERT INTO dbo.Artists ([Name],[BirthCity],[DoB]) VALUES
	('Katsushika Hokusai','Edo, Japan', '1760-10-31');

INSERT INTO dbo.ArtWorks ([ArtistId],[Title]) VALUES
	('5', 'The Great Wave off Kanagawa'),
	('5', 'Courtesan Standing with Student'),
	('5', 'Telescope');

INSERT INTO dbo.Classifications ([GenreId],[ArtWorkId]) VALUES
	('5','7'),
	('6','7'),
	('6','6'),
	('7','8'),
	('7','9'),
	('8','7'),
	('8','9');

GO