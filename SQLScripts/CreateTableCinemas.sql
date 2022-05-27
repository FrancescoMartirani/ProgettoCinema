USE [Cinema]
GO

/****** Object:  Table [dbo].[Cinemas]    Script Date: 5/27/2022 4:50:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cinemas](
	[IdCinema] [int] IDENTITY(1,1) NOT NULL,
	[NomeCinema] [varchar](50) NULL,
	[Indirizzo] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCinema] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

