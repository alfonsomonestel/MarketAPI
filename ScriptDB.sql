USE [master]
GO
/****** Object:  Database [market]    Script Date: 04/03/2023 19:16:59 ******/
CREATE DATABASE [market]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'market', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\market.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'market_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\market_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [market] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [market].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [market] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [market] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [market] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [market] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [market] SET ARITHABORT OFF 
GO
ALTER DATABASE [market] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [market] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [market] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [market] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [market] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [market] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [market] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [market] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [market] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [market] SET  DISABLE_BROKER 
GO
ALTER DATABASE [market] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [market] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [market] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [market] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [market] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [market] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [market] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [market] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [market] SET  MULTI_USER 
GO
ALTER DATABASE [market] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [market] SET DB_CHAINING OFF 
GO
ALTER DATABASE [market] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [market] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [market] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [market] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [market] SET QUERY_STORE = OFF
GO
USE [market]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 04/03/2023 19:16:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [numeric](18, 0) NOT NULL,
	[Nome] [nvarchar](150) NOT NULL,
	[Situacao] [bit] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 04/03/2023 19:16:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[Id] [numeric](18, 0) NOT NULL,
	[Nome] [varchar](250) NOT NULL,
	[Descricao] [nvarchar](max) NOT NULL,
	[Preco] [money] NOT NULL,
	[Situacao] [bit] NOT NULL,
	[Categoriaid] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categoria] ADD  CONSTRAINT [DF_Table_1_situacao]  DEFAULT ((1)) FOR [Situacao]
GO
ALTER TABLE [dbo].[Produto] ADD  CONSTRAINT [DF_Table_1_Preco]  DEFAULT ((0)) FOR [Preco]
GO
ALTER TABLE [dbo].[Produto] ADD  CONSTRAINT [DF_Table_1_Situacao_1]  DEFAULT ((1)) FOR [Situacao]
GO
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_Produto] FOREIGN KEY([Categoriaid])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [FK_Categoria_Produto]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'código da categoria - autoincrementado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nome da categoria' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria', @level2type=N'COLUMN',@level2name=N'Nome'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'indica a situação do cadastro da categoria (0 - inativo, 1 - ativo)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria', @level2type=N'COLUMN',@level2name=N'Situacao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nome de venda do produto' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Produto', @level2type=N'COLUMN',@level2name=N'Nome'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição completa do produto' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Produto', @level2type=N'COLUMN',@level2name=N'Descricao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'indica a situação do cadastro da produto (0 - inativo, 1 - ativo)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Produto', @level2type=N'COLUMN',@level2name=N'Situacao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código da categoria do produto' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Produto', @level2type=N'COLUMN',@level2name=N'Categoriaid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Categoria do produto' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Produto', @level2type=N'CONSTRAINT',@level2name=N'FK_Categoria_Produto'
GO
USE [master]
GO
ALTER DATABASE [market] SET  READ_WRITE 
GO
