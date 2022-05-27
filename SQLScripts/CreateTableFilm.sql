USE [Cinema]
GO

/****** Object:  Table [dbo].[Film]    Script Date: 5/27/2022 4:53:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Film](
	[IdFilm] [int] IDENTITY(1,1) NOT NULL,
	[Autore] [varchar](50) NOT NULL,
	[Produttore] [varchar](50) NOT NULL,
	[Genere] [varchar](50) NOT NULL,
	[Durata] [time](7) NOT NULL,
	[Titolo] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFilm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


