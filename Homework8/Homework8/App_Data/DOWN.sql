IF EXISTS
(
	SELECT *
	FROM sys.tables
	WHERE tables.name = 'Artwork'

)
BEGIN
	DROP TABLE dbo.Artwork
END

IF EXISTS
(
	SELECT *
	FROM sys.tables
	WHERE tables.name = 'Genre'

)
BEGIN
	DROP TABLE dbo.Genre
END

IF EXISTS
(
	SELECT *
	FROM sys.tables
	WHERE tables.name = 'Classification'

)
BEGIN
	DROP TABLE dbo.Classification
END

IF EXISTS
(
	SELECT *
	FROM sys.tables
	WHERE tables.name = 'Artwork'

)
BEGIN
	DROP TABLE dbo.Artwork
END

IF EXISTS
(
	SELECT *
	FROM sys.tables
	WHERE tables.name = 'Artist'

)
BEGIN
	DROP TABLE dbo.Artist
END
