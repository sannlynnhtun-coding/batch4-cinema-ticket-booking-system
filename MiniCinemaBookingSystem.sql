USE [master]
GO
/****** Object:  Database [CinemaTicketBookingSystem]    Script Date: 7/1/2024 1:48:31 PM ******/
CREATE DATABASE [CinemaTicketBookingSystem] ON  PRIMARY 
( NAME = N'CinemaTicketBookingSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CinemaTicketBookingSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CinemaTicketBookingSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CinemaTicketBookingSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CinemaTicketBookingSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET  MULTI_USER 
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET DB_CHAINING OFF 
GO
USE [CinemaTicketBookingSystem]
GO
/****** Object:  Table [dbo].[Tbl_Booking]    Script Date: 7/1/2024 1:48:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Booking](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[SeatMovieCode] [varchar](50) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[BookingHistory] [datetime] NOT NULL,
 CONSTRAINT [PK_Tbl_Booking1] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Customer]    Script Date: 7/1/2024 1:48:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Customer4] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Movie]    Script Date: 7/1/2024 1:48:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Movie](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[MovieCode] [varchar](50) NOT NULL,
	[MovieName] [varchar](5000) NOT NULL,
	[Description] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_Tbl_Movie7] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_SeatMovie]    Script Date: 7/1/2024 1:48:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_SeatMovie](
	[SeatMovieId] [int] IDENTITY(1,1) NOT NULL,
	[SeatMovieCode] [varchar](50) NOT NULL,
	[MovieCode] [varchar](50) NOT NULL,
	[SeatCode] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_SeatMoive] PRIMARY KEY CLUSTERED 
(
	[SeatMovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_ShowTime]    Script Date: 7/1/2024 1:48:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_ShowTime](
	[ShowtimeId] [int] IDENTITY(1,1) NOT NULL,
	[Showtime] [datetime] NOT NULL,
	[MovieCode] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_ShowTime1] PRIMARY KEY CLUSTERED 
(
	[ShowtimeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Booking] ON 

INSERT [dbo].[Tbl_Booking] ([BookingId], [SeatMovieCode], [CustomerName], [BookingHistory]) VALUES (1, N'SM001', N'Moe Yan Htun', CAST(N'2024-06-30T20:56:04.377' AS DateTime))
INSERT [dbo].[Tbl_Booking] ([BookingId], [SeatMovieCode], [CustomerName], [BookingHistory]) VALUES (2, N'SM002', N'Moe Yan Htun', CAST(N'2024-06-30T20:58:35.093' AS DateTime))
INSERT [dbo].[Tbl_Booking] ([BookingId], [SeatMovieCode], [CustomerName], [BookingHistory]) VALUES (3, N'SM003', N'Moe Yan Htun', CAST(N'2024-06-30T21:05:52.357' AS DateTime))
INSERT [dbo].[Tbl_Booking] ([BookingId], [SeatMovieCode], [CustomerName], [BookingHistory]) VALUES (4, N'SM004', N'Moe Yan Htun', CAST(N'2024-06-30T21:05:58.727' AS DateTime))
INSERT [dbo].[Tbl_Booking] ([BookingId], [SeatMovieCode], [CustomerName], [BookingHistory]) VALUES (5, N'SM005', N'Moe Yan Htun', CAST(N'2024-06-30T21:06:04.020' AS DateTime))
INSERT [dbo].[Tbl_Booking] ([BookingId], [SeatMovieCode], [CustomerName], [BookingHistory]) VALUES (6, N'SM006', N'Moe Yan Htun', CAST(N'2024-06-30T21:06:42.883' AS DateTime))
INSERT [dbo].[Tbl_Booking] ([BookingId], [SeatMovieCode], [CustomerName], [BookingHistory]) VALUES (7, N'SM007', N'moeyan', CAST(N'2024-06-30T21:26:18.037' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tbl_Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Customer] ON 

INSERT [dbo].[Tbl_Customer] ([CustomerId], [CustomerName]) VALUES (1, N'Moe Yan Htun')
INSERT [dbo].[Tbl_Customer] ([CustomerId], [CustomerName]) VALUES (2, N'Moe Yan Htun')
INSERT [dbo].[Tbl_Customer] ([CustomerId], [CustomerName]) VALUES (3, N'Moe Yan Htun')
INSERT [dbo].[Tbl_Customer] ([CustomerId], [CustomerName]) VALUES (4, N'Moe Yan Htun')
INSERT [dbo].[Tbl_Customer] ([CustomerId], [CustomerName]) VALUES (5, N'Moe Yan Htun')
INSERT [dbo].[Tbl_Customer] ([CustomerId], [CustomerName]) VALUES (6, N'Moe Yan Htun')
INSERT [dbo].[Tbl_Customer] ([CustomerId], [CustomerName]) VALUES (7, N'moeyan')
SET IDENTITY_INSERT [dbo].[Tbl_Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Movie] ON 

INSERT [dbo].[Tbl_Movie] ([MovieId], [MovieCode], [MovieName], [Description]) VALUES (1, N'M001', N'The Shawshank Redemption', N'Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.')
INSERT [dbo].[Tbl_Movie] ([MovieId], [MovieCode], [MovieName], [Description]) VALUES (2, N'M002', N'The Godfather', N'The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.')
INSERT [dbo].[Tbl_Movie] ([MovieId], [MovieCode], [MovieName], [Description]) VALUES (3, N'M003', N'The Dark Knight', N'When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.')
INSERT [dbo].[Tbl_Movie] ([MovieId], [MovieCode], [MovieName], [Description]) VALUES (4, N'M004', N'Pulp Fiction', N'The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.')
INSERT [dbo].[Tbl_Movie] ([MovieId], [MovieCode], [MovieName], [Description]) VALUES (5, N'M005', N'Forrest Gump', N'The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75.')
SET IDENTITY_INSERT [dbo].[Tbl_Movie] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_SeatMovie] ON 

INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (1, N'SM001', N'M001', N'S001')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (2, N'SM002', N'M001', N'S002')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (3, N'SM003', N'M001', N'S003')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (4, N'SM004', N'M001', N'S004')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (5, N'SM005', N'M001', N'S005')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (6, N'SM006', N'M002', N'S001')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (7, N'SM007', N'M002', N'S002')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (8, N'SM008', N'M002', N'S003')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (9, N'SM009', N'M002', N'S004')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (10, N'SM010', N'M002', N'S005')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (11, N'SM011', N'M003', N'S001')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (12, N'SM012', N'M003', N'S002')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (13, N'SM013', N'M003', N'S003')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (14, N'SM014', N'M003', N'S004')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (15, N'SM015', N'M003', N'S005')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (16, N'SM016', N'M004', N'S001')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (17, N'SM017', N'M004', N'S002')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (18, N'SM018', N'M004', N'S003')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (19, N'SM019', N'M004', N'S004')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (20, N'SM020', N'M004', N'S005')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (31, N'SM021', N'M005', N'S001')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (32, N'SM022', N'M005', N'S002')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (33, N'SM023', N'M005', N'S003')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (34, N'SM024', N'M005', N'S004')
INSERT [dbo].[Tbl_SeatMovie] ([SeatMovieId], [SeatMovieCode], [MovieCode], [SeatCode]) VALUES (35, N'SM025', N'M005', N'S005')
SET IDENTITY_INSERT [dbo].[Tbl_SeatMovie] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_ShowTime] ON 

INSERT [dbo].[Tbl_ShowTime] ([ShowtimeId], [Showtime], [MovieCode]) VALUES (1, CAST(N'2024-06-29T10:00:00.000' AS DateTime), N'M001')
INSERT [dbo].[Tbl_ShowTime] ([ShowtimeId], [Showtime], [MovieCode]) VALUES (2, CAST(N'2024-06-29T12:00:00.000' AS DateTime), N'M002')
INSERT [dbo].[Tbl_ShowTime] ([ShowtimeId], [Showtime], [MovieCode]) VALUES (3, CAST(N'2024-06-29T14:00:00.000' AS DateTime), N'M003')
INSERT [dbo].[Tbl_ShowTime] ([ShowtimeId], [Showtime], [MovieCode]) VALUES (4, CAST(N'2024-06-29T16:00:00.000' AS DateTime), N'M004')
INSERT [dbo].[Tbl_ShowTime] ([ShowtimeId], [Showtime], [MovieCode]) VALUES (5, CAST(N'2024-06-29T18:00:00.000' AS DateTime), N'M005')
SET IDENTITY_INSERT [dbo].[Tbl_ShowTime] OFF
GO
USE [master]
GO
ALTER DATABASE [CinemaTicketBookingSystem] SET  READ_WRITE 
GO
