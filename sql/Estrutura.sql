USE [Testando]
GO
/****** Object:  Table [dbo].[Conteudo]    Script Date: 14/07/2022 18:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conteudo](
	[Codigo_Conteudo] [int] IDENTITY(1,1) NOT NULL,
	[Titulo_Conteudo] [varchar](255) NULL,
	[Alias_Conteudo] [varchar](255) NULL,
	[Texto_Conteudo] [varchar](max) NULL,
	[DataCriacao_Conteudo] [datetime] NULL,
	[DataAlteracao_Conteudo] [datetime] NULL,
	[Status_Conteudo] [char](1) NULL,
 CONSTRAINT [PK_Conteudo] PRIMARY KEY CLUSTERED 
(
	[Codigo_Conteudo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Storage]    Script Date: 14/07/2022 18:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storage](
	[Codigo_Storage] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome_Storage] [varchar](255) NULL,
	[Alias_Storage] [varchar](255) NULL,
	[Diretorio_Storage] [varchar](255) NULL,
	[Extensao_Storage] [varchar](50) NULL,
	[Tipo_Storage] [varchar](50) NULL,
	[Peso_Storage] [bigint] NULL,
	[Referencia_Storage] [varchar](255) NULL,
	[Status_Storage] [char](1) NULL,
	[DataCriacao_Storage] [datetime] NULL,
	[DataAlteracao_Storage] [datetime] NULL,
	[Checksum_Storage] [varchar](1000) NULL,
 CONSTRAINT [PK_Storage] PRIMARY KEY CLUSTERED 
(
	[Codigo_Storage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 14/07/2022 18:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Codigo_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nome_Usuario] [varchar](255) NULL,
	[Email_Usuario] [varchar](255) NULL,
	[DataCriacao_Usuario] [datetime] NULL,
	[DataAlteracao_Usuario] [datetime] NULL,
	[Status_Usuario] [char](1) NULL,
	[Telefone_Usuario] [varchar](255) NULL,
	[Senha_Usuario] [varchar](255) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Codigo_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
