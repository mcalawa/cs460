CREATE TABLE dbo.Driver
(
	[DriverID] INT NOT NULL PRIMARY KEY,
	[DateOfBirth] Date NOT NULL,
	[FullName] NVARCHAR(128) NOT NULL,
	[Address] NVARCHAR(128) NOT NULL,
	[City] NVARCHAR(64) NOT NULL,
	[State] NVARCHAR(16) NOT NULL,
	[ZipCode] NVARCHAR(16) NOT NULL,
	[County] NVARCHAR(32) NOT NULL,
	[Date] Date NOT NULL
);

INSERT INTO dbo.Driver ([DriverID], [DateOfBirth], [FullName], [Address], [City], [State], [ZipCode], [County], [Date]) VALUES
	(1654200, '1922-05-31', 'Carraway, Melia N', '3714 N Haight Ave', 'Portland', 'OR', '97227', 'Multnomah', '1998-04-10'),
	(2988989, '2000-02-29', 'Highchurch, Merle H', '160 E Jefferson St', 'Huntington', 'OR', '97907', 'Baker', '2016-12-31'),
	(2358532, '1973-06-07', 'Shivers, Nick', '28083 SW Engle St', 'Wilsonville', 'OR', '97070', 'Clackamas', '1975-10-01'),
	(2555756, '1990-11-12', 'Jacobs, Jake J', '250 Clay St W', 'Monmouth', 'OR', '97351', 'Polk', '2002-01-17'),
	(2245820, '1952-03-11', 'Hunter, Janet', '1406 Goldcrest Ave NW', 'Salem', 'OR', '97304', 'Polk', '1983-09-15');

GO