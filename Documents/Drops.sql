USE [salvo]
GO

/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 02-06-2021 15:45:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
/* ship locations */

/****** Object:  Table [dbo].[ShipLocations]    Script Date: 02-06-2021 15:46:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ShipLocations]') AND type in (N'U'))
DROP TABLE [dbo].[ShipLocations]
GO

/****** Object:  Table [dbo].[SalvoLocations]    Script Date: 02-06-2021 15:46:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalvoLocations]') AND type in (N'U'))
DROP TABLE [dbo].[SalvoLocations]
GO

/****** Object:  Table [dbo].[Ships]    Script Date: 02-06-2021 15:46:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ships]') AND type in (N'U'))
DROP TABLE [dbo].[Ships]
GO

/****** Object:  Table [dbo].[Salvos]    Script Date: 02-06-2021 15:46:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Salvos]') AND type in (N'U'))
DROP TABLE [dbo].[Salvos]
GO

/****** Object:  Table [dbo].[GamePlayers]    Script Date: 02-06-2021 15:46:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GamePlayers]') AND type in (N'U'))
DROP TABLE [dbo].[GamePlayers]
GO

/****** Object:  Table [dbo].[Scores]   Script Date: 02-06-2021 15:46:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Scores]') AND type in (N'U'))
DROP TABLE [dbo].[Scores]
GO

/****** Object:  Table [dbo].[Games]    Script Date: 02-06-2021 15:46:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Games]') AND type in (N'U'))
DROP TABLE [dbo].[Games]
GO

/****** Object:  Table [dbo].[Players]    Script Date: 02-06-2021 15:46:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Players]') AND type in (N'U'))
DROP TABLE [dbo].[Players]
GO