---
title: CS 460 Homework 8/9
layout: hw8
---
## About Homework 8/9

Homework 8 involved combining everything we had learned so far to create a site with a multi-table, relational database of our own design that included CRUD functionality. The assignment page for homework 8 can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW8.html). Homework 9 involved deploying the completed homework 8 to the cloud with Azure. The assignment page for homework 9 can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW9.html). The code for both parts can be found on my GitHub [here](https://github.com/mcalawa/senior_project/tree/master/CS_460_Software_Engineering/HW8).

## Beginning with a Diagram

Since we creating a new database and had not been given a diagram, the first thing that needed to be done was to create an ER (Entity Relation) diagram for the database and then come up with scripts to populate it. The information on the different entities that would be needed and the seed data can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW8_tables.html). My diagram can be seen below.

![An ER diagram for homework 8 and 9](images/erdiagram.png)

We were then required to create the SQL up and down files. We were required to have named constraints in our schema, so the first part of my up.sql file (where the tables are created) looks like the following:

```sql
CREATE TABLE dbo.Artists
(
	[ArtistId] INT IDENTITY (1,1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[BirthCity] VARCHAR(128) NOT NULL,
	[DoB] DATETIME2 NOT NULL

	CONSTRAINT [PK_dbo.Artists] PRIMARY KEY (ArtistId)
);
```
The Name is only 50 characters because that is one of the later requirements in the assignment. The DoB (date of birth) is a DATETIME2 rather than a DATETIME because SQL DATETIMEs only allow dates after 1752, meaning that if you use a DATETIME, there are a lot of artists you wouldn't be able to enter! Additionally, the C# DateTime type includes both DATETIMEs and DATETIME2s, so using a DATETIME2 doesn't cause any unexpected behavior when creating the corresponding models. If not allowing null values hadn't been part of the assignment, I would have allowed for null values for the date of birth, possibly with a separate field for a circa birth year if the date of birth isn't known, since there are plenty of artists with exact birth dates that are unknown, especially if they were women. One such example is Katsushika Ōi, an [ukiyo-e](https://en.wikipedia.org/wiki/Ukiyo-e) artist and the daughter of Hokusai, who was born sometime in 1800.

```sql
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
```
The Name field of Genres is not the primary key, but it is required to be unique because there is no reason that two different genres would have the same name, such as might be the case with an artist or the title of a piece of art. Speaking of titles, I decided to go with the length 512 just in case anyone wanted to add Salvador Dali's *His Declaration Of The Independence Of The Imagination And Of The Rights Of Man To His Own Madness is 10 letters longer but even that pales into insignificance compared with Fifty Abstract Pictures Which As Seen From Two Yards Change Into Three Lenins Masquerading As Chinese And As Seen From Six Yards Appear As The Head Of A Royal Bengal Tiger*. Finally, the `ON DELETE CASCADE` and `ON UPDATE CASCADE` lets the database know that when the foreign key a table item relies on is deleted or updated, the table item itself should also be deleted or updated.

