USE [master]
GO
/****** Object:  Database [AvaExt]    Script Date: 17/03/2021 16:33:49 ******/
CREATE DATABASE [AvaExt]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AvaExt', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AvaExt.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AvaExt_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AvaExt_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AvaExt] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AvaExt].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AvaExt] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AvaExt] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AvaExt] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AvaExt] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AvaExt] SET ARITHABORT OFF 
GO
ALTER DATABASE [AvaExt] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AvaExt] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AvaExt] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AvaExt] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AvaExt] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AvaExt] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AvaExt] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AvaExt] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AvaExt] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AvaExt] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AvaExt] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AvaExt] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AvaExt] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AvaExt] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AvaExt] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AvaExt] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AvaExt] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AvaExt] SET RECOVERY FULL 
GO
ALTER DATABASE [AvaExt] SET  MULTI_USER 
GO
ALTER DATABASE [AvaExt] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AvaExt] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AvaExt] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AvaExt] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AvaExt] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AvaExt] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AvaExt] SET QUERY_STORE = OFF
GO
USE [AvaExt]
GO
/****** Object:  Table [dbo].[Aluno]    Script Date: 17/03/2021 16:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aluno](
	[AlunoID] [varchar](50) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Nome] [varchar](150) NOT NULL,
	[DataNasc] [date] NOT NULL,
	[Telefone] [varchar](20) NOT NULL,
	[Morada] [varchar](150) NOT NULL,
	[DataCria] [date] NOT NULL,
	[Turma] [varchar](20) NOT NULL,
	[Oculto] [bit] NOT NULL,
 CONSTRAINT [PK_Aluno] PRIMARY KEY CLUSTERED 
(
	[AlunoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Disciplina]    Script Date: 17/03/2021 16:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disciplina](
	[Sigla] [varchar](50) NOT NULL,
	[Disciplina] [varchar](50) NOT NULL,
	[Componente] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Disciplina] PRIMARY KEY CLUSTERED 
(
	[Sigla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiscProf]    Script Date: 17/03/2021 16:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscProf](
	[Sigla] [varchar](50) NOT NULL,
	[ProfStaffID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DiscProf] PRIMARY KEY CLUSTERED 
(
	[Sigla] ASC,
	[ProfStaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulo]    Script Date: 17/03/2021 16:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulo](
	[ModuloID] [int] NOT NULL,
	[NumModulo] [int] NOT NULL,
	[Sigla] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Modulo] PRIMARY KEY CLUSTERED 
(
	[ModuloID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 17/03/2021 16:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[PedidoID] [int] NOT NULL,
	[Aluno] [varchar](50) NOT NULL,
	[Prof] [varchar](50) NOT NULL,
	[Modulo] [int] NOT NULL,
	[DataCria] [date] NOT NULL,
	[HoraCria] [time](7) NOT NULL,
	[DataExame] [date] NOT NULL,
	[HoraExame] [time](7) NOT NULL,
	[DurExame] [int] NULL,
	[DataAprov] [date] NULL,
	[HoraAprov] [time](7) NULL,
	[DataPago] [date] NULL,
	[HoraPago] [time](7) NULL,
	[DataTermin] [date] NULL,
	[HoraTermin] [time](7) NULL,
	[Estado] [varchar](50) NOT NULL,
	[Preco] [money] NULL,
	[TipoPaga] [varchar](50) NULL,
	[TipoTaxa] [varchar](100) NULL,
	[Nota] [float] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[PedidoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfStaff]    Script Date: 17/03/2021 16:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfStaff](
	[ProfStaffID] [varchar](50) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Nome] [varchar](150) NOT NULL,
	[DataNasc] [date] NOT NULL,
	[Telefone] [varchar](20) NOT NULL,
	[Morada] [varchar](150) NOT NULL,
	[DataCria] [date] NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[Oculto] [bit] NOT NULL,
 CONSTRAINT [PK_ProfStaff] PRIMARY KEY CLUSTERED 
(
	[ProfStaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[DiscProf]  WITH CHECK ADD  CONSTRAINT [FK_DiscProf_Disciplina] FOREIGN KEY([Sigla])
REFERENCES [dbo].[Disciplina] ([Sigla])
GO
ALTER TABLE [dbo].[DiscProf] CHECK CONSTRAINT [FK_DiscProf_Disciplina]
GO
ALTER TABLE [dbo].[DiscProf]  WITH CHECK ADD  CONSTRAINT [FK_DiscProf_ProfStaff] FOREIGN KEY([ProfStaffID])
REFERENCES [dbo].[ProfStaff] ([ProfStaffID])
GO
ALTER TABLE [dbo].[DiscProf] CHECK CONSTRAINT [FK_DiscProf_ProfStaff]
GO
ALTER TABLE [dbo].[Modulo]  WITH CHECK ADD  CONSTRAINT [FK_Modulo_Disciplina] FOREIGN KEY([Sigla])
REFERENCES [dbo].[Disciplina] ([Sigla])
GO
ALTER TABLE [dbo].[Modulo] CHECK CONSTRAINT [FK_Modulo_Disciplina]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Aluno] FOREIGN KEY([Aluno])
REFERENCES [dbo].[Aluno] ([AlunoID])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Aluno]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Modulo] FOREIGN KEY([Modulo])
REFERENCES [dbo].[Modulo] ([ModuloID])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Modulo]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_ProfStaff] FOREIGN KEY([Prof])
REFERENCES [dbo].[ProfStaff] ([ProfStaffID])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_ProfStaff]
GO
/****** Object:  StoredProcedure [dbo].[delDiscProf]    Script Date: 17/03/2021 16:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[delDiscProf] @ProfStaffID varchar(50)
as
delete from DiscProf where ProfStaffID=@ProfStaffID
GO
/****** Object:  StoredProcedure [dbo].[delPedido]    Script Date: 17/03/2021 16:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[delPedido] @PedidoID int
as
Delete from Pedido where PedidoID=@PedidoID
GO
/****** Object:  StoredProcedure [dbo].[InsertAl]    Script Date: 17/03/2021 16:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertAl] @AlunoID varchar(50), @Password varchar(max), @Nome varchar(150), 
@DataNasc date, @Telefone varchar(20), @Morada varchar(150), @DataCria date, @Turma varchar(20), @Oculto bit
AS
Insert into Aluno values (@AlunoID, @Password, @Nome, @DataNasc, @Telefone, @Morada, @DataCria, @Turma, @Oculto)
GO
/****** Object:  StoredProcedure [dbo].[InsertDiscProf]    Script Date: 17/03/2021 16:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertDiscProf] @Sigla varchar(50), @ProfStaffID varchar(50)
AS
Insert into DiscProf values (@Sigla, @ProfStaffID)
GO
/****** Object:  StoredProcedure [dbo].[InsertModulo]    Script Date: 17/03/2021 16:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Inserir Modulo
CREATE PROCEDURE [dbo].[InsertModulo] @ModuloID int, @NumModulo int, @Sigla varchar(50)
AS
Insert into Modulo values (@ModuloID, @NumModulo, @Sigla)
GO
/****** Object:  StoredProcedure [dbo].[InsertPedido]    Script Date: 17/03/2021 16:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertPedido] @PedidoID int, @Aluno varchar(50), @Prof varchar(50), @Modulo int, @DataCria date, @HoraCria time(7), @DataExame date, @HoraExame time(7),
@DurExame int, @DataAprov date, @HoraAprov time(7), @DataPago date, @HoraPago time(7), @DataTermin date, @HoraTermin time(7), @Estado varchar(50), @Preco money,
@TipoPaga varchar(50), @TipoTaxa varchar(100), @Nota float
AS
Insert into Pedido values (@PedidoID, @Aluno, @Prof, @Modulo, @DataCria, @HoraCria, @DataExame, @HoraExame, @DurExame, @DataAprov, @HoraAprov, @DataPago, @HoraPago,
@DataTermin, @HoraTermin, @Estado, @Preco, @TipoPaga, @TipoTaxa, @Nota)
GO
/****** Object:  StoredProcedure [dbo].[InsertProfStaff]    Script Date: 17/03/2021 16:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertProfStaff] @ProfStaffID varchar(50), @Password varchar(max), @Nome varchar(150), 
@DataNasc date, @Telefone varchar(20), @Morada varchar(150), @DataCria date, @Tipo varchar(50), @Oculto bit
AS
Insert into ProfStaff values (@ProfStaffID, @Password, @Nome, @DataNasc, @Telefone, @Morada, @DataCria, @Tipo, @Oculto)
GO
USE [master]
GO
ALTER DATABASE [AvaExt] SET  READ_WRITE 
GO
