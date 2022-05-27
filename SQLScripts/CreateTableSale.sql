USE [Cinema]
GO

/****** Object:  Table [dbo].[Sale]    Script Date: 5/27/2022 4:54:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sale](
	[IdSala] [int] IDENTITY(1,1) NOT NULL,
	[PostiOccupati] [int] NOT NULL,
	[IdFilm] [int] NOT NULL,
	[IdCinema] [int] NOT NULL,
	[NomeSala] [varchar](50) NULL,
	[MaxPosti] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Sale]  WITH CHECK ADD FOREIGN KEY([IdCinema])
REFERENCES [dbo].[Cinemas] ([IdCinema])
GO

ALTER TABLE [dbo].[Sale]  WITH CHECK ADD FOREIGN KEY([IdFilm])
REFERENCES [dbo].[Film] ([IdFilm])
GO


