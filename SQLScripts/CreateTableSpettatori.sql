USE [Cinema]
GO

/****** Object:  Table [dbo].[Spettatori]    Script Date: 5/27/2022 4:54:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Spettatori](
	[IdSpettatore] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Cognome] [varchar](50) NOT NULL,
	[DataNascita] [datetime] NULL,
	[IdBiglietto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSpettatore] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Spettatori]  WITH CHECK ADD FOREIGN KEY([IdBiglietto])
REFERENCES [dbo].[Biglietti] ([IdBiglietto])
GO
