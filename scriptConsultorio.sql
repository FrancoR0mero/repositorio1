USE [Consultorio]
GO
/****** Object:  Table [dbo].[ObrasSociales]    Script Date: 27/6/2022 20:58:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ObrasSociales](
	[idObraSocial] [int] IDENTITY(1,1) NOT NULL,
	[nombreObraSocial] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ObrasSociales] PRIMARY KEY CLUSTERED 
(
	[idObraSocial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 27/6/2022 20:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[numeroHC] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[obraSocial] [int] NOT NULL,
	[sexo] [int] NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
 CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED 
(
	[numeroHC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ObrasSociales] ON 

INSERT [dbo].[ObrasSociales] ([idObraSocial], [nombreObraSocial]) VALUES (1, N'APROSS')
INSERT [dbo].[ObrasSociales] ([idObraSocial], [nombreObraSocial]) VALUES (2, N'MET')
INSERT [dbo].[ObrasSociales] ([idObraSocial], [nombreObraSocial]) VALUES (3, N'OSDE')
INSERT [dbo].[ObrasSociales] ([idObraSocial], [nombreObraSocial]) VALUES (4, N'DASUTEN')
INSERT [dbo].[ObrasSociales] ([idObraSocial], [nombreObraSocial]) VALUES (5, N'DASPU')
INSERT [dbo].[ObrasSociales] ([idObraSocial], [nombreObraSocial]) VALUES (6, N'PAMI')
SET IDENTITY_INSERT [dbo].[ObrasSociales] OFF
GO
SET IDENTITY_INSERT [dbo].[Pacientes] ON 

INSERT [dbo].[Pacientes] ([numeroHC], [nombre], [obraSocial], [sexo], [fechaNacimiento]) VALUES (1, N'Juan Perez', 1, 2, CAST(N'1970-06-26' AS Date))
INSERT [dbo].[Pacientes] ([numeroHC], [nombre], [obraSocial], [sexo], [fechaNacimiento]) VALUES (2, N'Maria Lopez', 3, 1, CAST(N'2000-05-13' AS Date))
SET IDENTITY_INSERT [dbo].[Pacientes] OFF
GO
