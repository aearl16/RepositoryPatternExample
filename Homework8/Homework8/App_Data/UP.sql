-- Artist Table
CREATE TABLE dbo.Artist
(
	ArtistID	INT NOT NULL,
	FullName	NVARCHAR(50) NOT NULL,
	DOB			DateTime2 NOT NULL,
	City		NVARCHAR(128),
	CONSTRAINT [PK_dbo.Artist] PRIMARY KEY CLUSTERED (ArtistID ASC),
);
-- Insert Statement
INSERT INTO dbo.Artist (ArtistID, FullName, DOB, City) VALUES 
	(1, 'M.C. Escher', 'June 17, 1898', 'Leeuwarden, Netherlands'),
	(2, 'Leonardo Da Vinci', 'May 2, 1519', 'Vinci, Italy'),
	(3, 'Hatip Mehmed Efendi', 'November 18, 1680', 'Unknown'),
	(4, 'Salvador Dali', 'May 11, 1904', 'Figueres, Spain');

CREATE TABLE dbo.Artwork
(
	ArtworkID INT NOT NULL,
	ArtistID INT NOT NULL,
	Title NVARCHAR (128) NOT NULL,
	CONSTRAINT [PK_dbo.Artwork] PRIMARY KEY CLUSTERED (ArtworkID ASC),
	CONSTRAINT [FK_dbo.Artwork] FOREIGN KEY (ArtistID)
	REFERENCES dbo.Artist (ArtistID)
);

INSERT INTO dbo.Artwork (ArtworkID, ArtistID, Title) VALUES
	(1, 1, 'Circle Limit III'),
	(2, 1, 'Twon Tree'),
	(3, 2, 'Mona Lisa'),
	(4, 2, 'The Vitruvian Man'),
	(5, 3, 'Ebru'),
	(6, 4, 'Honey Is Sweeter Than Blood');

CREATE TABLE dbo.Genre
(
	GenreID INT NOT NULL,
	GenreName NVARCHAR (128) NOT NULL
	CONSTRAINT [PK_dbo.Genre] PRIMARY KEY CLUSTERED (GenreID ASC)
);

INSERT INTO dbo.Genre (GenreID, GenreName) VALUES
	(1, 'Tesselation'),
	(2, 'Surrealism'),
	(3, 'Portrait'),
	(4, 'Renaissance');

CREATE TABLE dbo.Classification
(
	ClassificationID INT NOT NULL,
	ArtworkID INT NOT NULL,
	GenreID INT NOT NULL,
	CONSTRAINT [PK_dbo.Classification] PRIMARY KEY CLUSTERED (ClassificationID),
	CONSTRAINT [FK_dbo.Classification] FOREIGN KEY (ArtworkID)
	REFERENCES dbo.Artwork (ArtworkID),
	CONSTRAINT [FK2_dbo.Classification] FOREIGN KEY (GenreID)
	REFERENCES dbo.Genre (GenreID)

);

INSERT INTO dbo.Classification (ClassificationID, ArtworkID, GenreID) VALUES
	(1,1,1),
	(2,2,1),
	(3,2,2),
	(4,3,3),
	(5,3,4),
	(6,4,4),
	(7,5,1),
	(8,6,2);