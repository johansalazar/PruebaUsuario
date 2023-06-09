USE [master]
GO
/****** Object:  Database [PruebaUsuario]    Script Date: 16/03/2023 12:36:06 p. m. ******/
CREATE DATABASE [PruebaUsuario]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaUsuario', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PruebaUsuario.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PruebaUsuario_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PruebaUsuario_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PruebaUsuario] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaUsuario].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PruebaUsuario] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PruebaUsuario] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PruebaUsuario] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PruebaUsuario] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PruebaUsuario] SET ARITHABORT OFF 
GO
ALTER DATABASE [PruebaUsuario] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PruebaUsuario] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PruebaUsuario] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PruebaUsuario] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PruebaUsuario] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PruebaUsuario] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PruebaUsuario] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PruebaUsuario] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PruebaUsuario] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PruebaUsuario] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PruebaUsuario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PruebaUsuario] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PruebaUsuario] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PruebaUsuario] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PruebaUsuario] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PruebaUsuario] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PruebaUsuario] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PruebaUsuario] SET RECOVERY FULL 
GO
ALTER DATABASE [PruebaUsuario] SET  MULTI_USER 
GO
ALTER DATABASE [PruebaUsuario] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PruebaUsuario] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PruebaUsuario] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PruebaUsuario] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PruebaUsuario] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PruebaUsuario] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PruebaUsuario', N'ON'
GO
ALTER DATABASE [PruebaUsuario] SET QUERY_STORE = OFF
GO
USE [PruebaUsuario]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 16/03/2023 12:36:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Sexo] [nvarchar](1) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Usuarios]    Script Date: 16/03/2023 12:36:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_Usuarios] (@Id_Usuario      INT = NULL,
                              @Nombre          NVARCHAR(100) = NULL,
                              @FechaNacimiento DATE = NULL,
                              @Sexo            NVARCHAR(1) = NULL,
                              @Action          VARCHAR(25))
AS
  BEGIN
      IF @Action = 'Create'
        BEGIN
            INSERT INTO usuarios
                        (nombre,
                         fechanacimiento,
                         sexo)
            VALUES      (@Nombre,
                         @FechaNacimiento,
                         @Sexo)
        END

		IF @Action = 'Read'
        BEGIN
            SELECT id_usuario,
                   nombre,
                   fechanacimiento,
                   sexo
            FROM   usuarios
        END

      IF @Action = 'Update'
        BEGIN
            UPDATE usuarios
            SET    nombre = @Nombre,
                   fechanacimiento = @FechaNacimiento,
                   sexo = @Sexo
            WHERE  id_usuario = @Id_Usuario
        END

      

      IF @Action = 'Delete'
        BEGIN
            DELETE usuarios
            WHERE  id_usuario = @Id_Usuario
        END
  END  
GO
USE [master]
GO
ALTER DATABASE [PruebaUsuario] SET  READ_WRITE 
GO
