USE [Cinema]
GO

/****** Object:  Table [dbo].[Biglietti]    Script Date: 5/27/2022 4:49:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Biglietti](
	[IdBiglietto] [int] IDENTITY(1,1) NOT NULL,
	[NumeroPosto] [int] NOT NULL,
	[IdSala] [int] NOT NULL,
	[Prezzo] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdBiglietto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Biglietti]  WITH CHECK ADD FOREIGN KEY([IdSala])
REFERENCES [dbo].[Sale] ([IdSala])
GO

