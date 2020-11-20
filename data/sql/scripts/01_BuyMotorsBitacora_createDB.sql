USE [master]
GO
/****** Object:  Database [BuyMotorsBitacora]    Script Date: 20/11/2020 16:19:14 ******/
CREATE DATABASE [BuyMotorsBitacora]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BuyMotorsBitacora].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BuyMotorsBitacora] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET ARITHABORT OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BuyMotorsBitacora] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BuyMotorsBitacora] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BuyMotorsBitacora] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BuyMotorsBitacora] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET RECOVERY FULL 
GO
ALTER DATABASE [BuyMotorsBitacora] SET  MULTI_USER 
GO
ALTER DATABASE [BuyMotorsBitacora] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BuyMotorsBitacora] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BuyMotorsBitacora] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BuyMotorsBitacora] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BuyMotorsBitacora] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BuyMotorsBitacora', N'ON'
GO
USE [BuyMotorsBitacora]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 20/11/2020 16:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Usuario] [varchar](100) NOT NULL,
	[Detalle] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (1, CAST(N'2020-04-25T16:59:28.430' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (2, CAST(N'2020-04-25T17:06:56.607' AS DateTime), N'admin@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (3, CAST(N'2020-04-25T17:07:01.370' AS DateTime), N'admin@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (4, CAST(N'2020-04-25T19:55:19.643' AS DateTime), N'admin@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (5, CAST(N'2020-04-25T22:19:54.333' AS DateTime), N'admin@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (6, CAST(N'2020-04-25T22:20:03.863' AS DateTime), N'admin@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (7, CAST(N'2020-04-25T22:21:44.430' AS DateTime), N'admin@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (8, CAST(N'2020-04-25T22:21:46.750' AS DateTime), N'admin@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (9, CAST(N'2020-04-28T20:05:37.973' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (10, CAST(N'2020-05-01T18:39:49.157' AS DateTime), N'admin@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (11, CAST(N'2020-05-01T18:39:53.677' AS DateTime), N'admin@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (12, CAST(N'2020-05-03T18:57:57.340' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (13, CAST(N'2020-05-03T19:00:04.850' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (14, CAST(N'2020-05-03T19:01:19.323' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (15, CAST(N'2020-05-03T19:27:20.300' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (16, CAST(N'2020-05-03T19:28:06.267' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (17, CAST(N'2020-05-03T19:29:46.397' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (18, CAST(N'2020-05-03T19:30:49.197' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (19, CAST(N'2020-05-03T19:30:52.167' AS DateTime), N'webmaster@mail.com', N'Se realizó un backup')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (20, CAST(N'2020-05-05T22:07:01.083' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (21, CAST(N'2020-05-05T22:09:32.957' AS DateTime), N'usuariobasico@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (22, CAST(N'2020-05-05T22:09:50.887' AS DateTime), N'admin@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (23, CAST(N'2020-05-05T22:22:46.173' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (24, CAST(N'2020-05-05T22:23:20.780' AS DateTime), N'usuariobasico@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (25, CAST(N'2020-05-05T22:23:25.567' AS DateTime), N'admin@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (26, CAST(N'2020-05-05T22:24:58.597' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (27, CAST(N'2020-05-05T22:25:18.963' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (28, CAST(N'2020-05-26T21:08:05.493' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (29, CAST(N'2020-05-31T12:38:58.007' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (30, CAST(N'2020-05-31T14:38:21.180' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (31, CAST(N'2020-05-31T14:42:54.940' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (32, CAST(N'2020-05-31T15:08:02.403' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (33, CAST(N'2020-05-31T15:14:44.003' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (34, CAST(N'2020-05-31T15:19:33.847' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (35, CAST(N'2020-05-31T15:26:51.567' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (36, CAST(N'2020-05-31T15:31:26.720' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (37, CAST(N'2020-05-31T15:31:35.517' AS DateTime), N'usuariobasico@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (38, CAST(N'2020-05-31T15:37:38.613' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (39, CAST(N'2020-05-31T15:37:42.100' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (40, CAST(N'2020-06-06T19:23:04.860' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (41, CAST(N'2020-06-06T19:33:02.287' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (42, CAST(N'2020-06-06T19:36:44.520' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (43, CAST(N'2020-06-06T19:39:16.720' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (44, CAST(N'2020-06-08T20:45:22.780' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (45, CAST(N'2020-06-08T20:56:25.407' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (46, CAST(N'2020-06-08T20:59:19.630' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (47, CAST(N'2020-06-08T21:04:32.737' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (48, CAST(N'2020-06-08T21:11:41.807' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (49, CAST(N'2020-07-05T14:37:17.490' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (50, CAST(N'2020-07-05T14:37:24.457' AS DateTime), N'usuariobasico@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (51, CAST(N'2020-07-05T14:37:31.593' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (52, CAST(N'2020-07-05T14:39:12.267' AS DateTime), N'webmaster@mail.com', N'Se realizó un backup')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (53, CAST(N'2020-07-05T14:39:21.323' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (54, CAST(N'2020-07-05T14:39:28.407' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (55, CAST(N'2020-07-05T14:39:30.273' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (56, CAST(N'2020-07-05T14:39:41.900' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (57, CAST(N'2020-07-05T14:40:01.990' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (58, CAST(N'2020-07-05T14:40:06.597' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (59, CAST(N'2020-07-05T14:40:19.180' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (60, CAST(N'2020-07-05T14:40:27.430' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (61, CAST(N'2020-07-05T14:41:29.710' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (62, CAST(N'2020-07-05T14:41:34.540' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (63, CAST(N'2020-07-05T14:41:37.673' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (64, CAST(N'2020-07-05T14:42:58.787' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (65, CAST(N'2020-07-05T14:43:39.513' AS DateTime), N'webmaster@mail.com', N'Se restauró el backup 2020_07_05_14_39_12')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (66, CAST(N'2020-07-05T14:43:47.480' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (67, CAST(N'2020-07-05T14:43:51.587' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (68, CAST(N'2020-07-05T15:33:10.483' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (69, CAST(N'2020-07-05T15:33:56.540' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (70, CAST(N'2020-07-05T15:34:00.990' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (71, CAST(N'2020-07-05T15:36:08.387' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (72, CAST(N'2020-07-05T15:36:20.843' AS DateTime), N'webmaster@mail.com', N'Se realizó un backup')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (73, CAST(N'2020-07-05T15:36:54.923' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (74, CAST(N'2020-07-05T15:37:02.853' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (75, CAST(N'2020-07-05T15:38:05.330' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (76, CAST(N'2020-07-05T15:38:09.420' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (77, CAST(N'2020-07-05T21:32:19.050' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (78, CAST(N'2020-07-05T21:37:03.190' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (79, CAST(N'2020-07-05T21:37:23.203' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (80, CAST(N'2020-07-05T21:38:08.173' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (81, CAST(N'2020-07-05T21:38:21.060' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (82, CAST(N'2020-07-05T21:39:05.117' AS DateTime), N'webmaster@mail.com', N'Se realizó un backup')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (83, CAST(N'2020-07-05T21:39:18.977' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (84, CAST(N'2020-07-05T21:39:23.820' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (85, CAST(N'2020-07-05T21:39:41.440' AS DateTime), N'webmaster@mail.com', N'Se restauró el backup 2020_07_05_21_39_04')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (86, CAST(N'2020-07-05T21:39:44.897' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (87, CAST(N'2020-07-05T21:39:48.773' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (88, CAST(N'2020-07-05T21:43:41.633' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (89, CAST(N'2020-07-05T21:43:44.823' AS DateTime), N'usuariobasico@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (90, CAST(N'2020-07-05T22:06:04.627' AS DateTime), N'otro@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (91, CAST(N'2020-07-05T22:06:09.093' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (92, CAST(N'2020-07-05T22:06:20.697' AS DateTime), N'webmaster@mail.com', N'Se restauró el backup 2020_07_05_21_39_04')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (93, CAST(N'2020-07-05T22:06:25.690' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (94, CAST(N'2020-07-05T22:06:29.883' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (95, CAST(N'2020-07-05T22:06:44.080' AS DateTime), N'usuariobasico@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (96, CAST(N'2020-07-05T22:06:48.213' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (97, CAST(N'2020-07-05T22:07:47.897' AS DateTime), N'webmaster@mail.com', N'Se restauró el backup 2020_07_05_21_39_04')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (98, CAST(N'2020-07-05T22:07:50.247' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (99, CAST(N'2020-07-09T20:50:39.180' AS DateTime), N'webmaster@mail.com', N'Login ok')
GO
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (100, CAST(N'2020-07-09T20:50:50.340' AS DateTime), N'webmaster@mail.com', N'Se realizó un backup')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (101, CAST(N'2020-07-09T20:51:42.447' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (102, CAST(N'2020-07-09T20:51:47.427' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (103, CAST(N'2020-07-09T20:52:07.820' AS DateTime), N'webmaster@mail.com', N'Se restauró el backup 2020_07_09_20_50_50')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (104, CAST(N'2020-07-09T20:52:11.220' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (105, CAST(N'2020-07-09T20:52:15.177' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (106, CAST(N'2020-07-09T20:52:26.073' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (107, CAST(N'2020-07-10T18:06:11.187' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (108, CAST(N'2020-07-10T18:09:40.350' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (109, CAST(N'2020-07-16T17:19:50.180' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (110, CAST(N'2020-07-16T17:19:58.000' AS DateTime), N'usuariobasico@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (111, CAST(N'2020-07-16T17:20:06.883' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (112, CAST(N'2020-07-16T17:21:49.847' AS DateTime), N'webmaster@mail.com', N'Se realizó un backup')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (113, CAST(N'2020-07-16T17:21:55.673' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (114, CAST(N'2020-07-16T17:24:27.427' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (115, CAST(N'2020-07-16T17:24:40.097' AS DateTime), N'webmaster@mail.com', N'Se restauró el backup 2020_07_16_17_21_49')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (116, CAST(N'2020-07-16T17:24:48.680' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (117, CAST(N'2020-07-16T17:24:53.283' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (118, CAST(N'2020-09-02T22:36:55.977' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (119, CAST(N'2020-09-02T22:49:33.960' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (120, CAST(N'2020-10-11T11:41:41.573' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (121, CAST(N'2020-10-11T11:43:49.763' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (122, CAST(N'2020-10-11T11:44:48.617' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (123, CAST(N'2020-10-11T11:45:33.523' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (124, CAST(N'2020-10-11T12:16:14.110' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (125, CAST(N'2020-10-11T12:16:22.637' AS DateTime), N'usuariobasico@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (126, CAST(N'2020-10-11T12:16:44.060' AS DateTime), N'usuarionuevo1@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (127, CAST(N'2020-10-11T12:16:56.333' AS DateTime), N'usuarionuevo1@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (128, CAST(N'2020-10-11T12:17:59.020' AS DateTime), N'usuarionuevo1@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (129, CAST(N'2020-10-11T12:20:59.590' AS DateTime), N'usuarionuevo1@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (130, CAST(N'2020-10-11T12:21:05.050' AS DateTime), N'usuarionuevo1@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (131, CAST(N'2020-10-11T15:32:38.570' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (132, CAST(N'2020-10-11T15:36:40.720' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (133, CAST(N'2020-10-11T15:41:04.803' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (134, CAST(N'2020-10-11T15:43:41.423' AS DateTime), N'usuarionuevo1@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (135, CAST(N'2020-10-11T15:43:45.767' AS DateTime), N'usuarionuevo1@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (136, CAST(N'2020-10-11T15:45:08.093' AS DateTime), N'usuarionuevo1@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (137, CAST(N'2020-10-11T15:45:10.460' AS DateTime), N'usuarionuevo1@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (138, CAST(N'2020-10-11T15:45:15.693' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (139, CAST(N'2020-10-11T15:45:18.507' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (140, CAST(N'2020-11-15T14:20:50.873' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (141, CAST(N'2020-11-17T19:06:09.580' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (142, CAST(N'2020-11-17T19:06:29.797' AS DateTime), N'usuariobasico@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (143, CAST(N'2020-11-17T19:06:34.597' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (144, CAST(N'2020-11-17T19:09:23.193' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (145, CAST(N'2020-11-17T19:11:03.967' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (146, CAST(N'2020-11-17T19:11:16.320' AS DateTime), N'webmaster@mail.com', N'Se realizó un backup')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (147, CAST(N'2020-11-17T19:15:06.457' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (148, CAST(N'2020-11-17T19:15:12.110' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (149, CAST(N'2020-11-17T19:15:35.880' AS DateTime), N'webmaster@mail.com', N'Se restauró el backup 2020_11_17_19_11_16')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (150, CAST(N'2020-11-17T19:15:39.347' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (151, CAST(N'2020-11-17T19:16:02.773' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (152, CAST(N'2020-11-17T19:18:05.940' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (153, CAST(N'2020-11-17T19:18:13.667' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (154, CAST(N'2020-11-17T19:19:59.137' AS DateTime), N'usuariobasico@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (155, CAST(N'2020-11-17T19:20:04.343' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (156, CAST(N'2020-11-17T19:21:04.197' AS DateTime), N'usuariobasico@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (157, CAST(N'2020-11-17T19:21:10.743' AS DateTime), N'usuariobasico@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (158, CAST(N'2020-11-17T19:21:23.350' AS DateTime), N'usuariobasico@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (159, CAST(N'2020-11-17T19:22:42.093' AS DateTime), N'usuarionuevo2@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (160, CAST(N'2020-11-17T19:23:00.673' AS DateTime), N'usuarionuevo2@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (161, CAST(N'2020-11-17T19:23:07.630' AS DateTime), N'usuarionuevo2@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (162, CAST(N'2020-11-17T19:23:12.570' AS DateTime), N'webmaster@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (163, CAST(N'2020-11-17T19:23:16.153' AS DateTime), N'webmaster@mail.com', N'Cierre de sesión')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (164, CAST(N'2020-11-17T19:25:06.273' AS DateTime), N'usuarionuevo2@mail.com', N'Login ok')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Usuario], [Detalle]) VALUES (165, CAST(N'2020-11-17T19:25:24.573' AS DateTime), N'usuarionuevo2@mail.com', N'Cierre de sesión')
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
USE [master]
GO
ALTER DATABASE [BuyMotorsBitacora] SET  READ_WRITE 
GO
