USE [master]
GO
/****** Object:  Database [fashion-store]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE DATABASE [fashion-store]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'fashion-store', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\fashion-store.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'fashion-store_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\fashion-store_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [fashion-store] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [fashion-store].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [fashion-store] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [fashion-store] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [fashion-store] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [fashion-store] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [fashion-store] SET ARITHABORT OFF 
GO
ALTER DATABASE [fashion-store] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [fashion-store] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [fashion-store] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [fashion-store] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [fashion-store] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [fashion-store] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [fashion-store] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [fashion-store] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [fashion-store] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [fashion-store] SET  ENABLE_BROKER 
GO
ALTER DATABASE [fashion-store] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [fashion-store] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [fashion-store] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [fashion-store] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [fashion-store] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [fashion-store] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [fashion-store] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [fashion-store] SET RECOVERY FULL 
GO
ALTER DATABASE [fashion-store] SET  MULTI_USER 
GO
ALTER DATABASE [fashion-store] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [fashion-store] SET DB_CHAINING OFF 
GO
ALTER DATABASE [fashion-store] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [fashion-store] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [fashion-store] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [fashion-store] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'fashion-store', N'ON'
GO
ALTER DATABASE [fashion-store] SET QUERY_STORE = ON
GO
ALTER DATABASE [fashion-store] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [fashion-store]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[URLImage] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[VerifyCode] [int] NULL,
	[UserPaymentId] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartDetails]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartDetails](
	[Id] [nvarchar](450) NOT NULL,
	[ProductId] [nvarchar](450) NOT NULL,
	[Quantity] [int] NOT NULL,
	[CartId] [nvarchar](450) NOT NULL,
	[SizeId] [nvarchar](450) NULL,
 CONSTRAINT [PK_CartDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[Id] [nvarchar](450) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [nvarchar](450) NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
	[CategoryDescription] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coupons]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coupons](
	[Id] [nvarchar](450) NOT NULL,
	[CouponCode] [nvarchar](max) NOT NULL,
	[CouponName] [nvarchar](max) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [int] NOT NULL,
	[MinRequire] [float] NOT NULL,
	[MaxTotalDiscount] [float] NOT NULL,
	[DateExpire] [datetime2](7) NOT NULL,
	[DateStart] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Coupons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryInformations]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryInformations](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[AddressDetail] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_DeliveryInformations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [nvarchar](450) NOT NULL,
	[ProductPrice] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ProductId] [nvarchar](450) NOT NULL,
	[OrderId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [nvarchar](450) NOT NULL,
	[CouponId] [nvarchar](450) NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[DeliveryInformationId] [nvarchar](450) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentProfiles]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentProfiles](
	[Id] [nvarchar](450) NOT NULL,
	[CardId] [nvarchar](max) NOT NULL,
	[Last4] [nvarchar](max) NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PaymentProfiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [nvarchar](450) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[URLImage] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CategoryId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sizes]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sizes](
	[Id] [nvarchar](450) NOT NULL,
	[SizeName] [nvarchar](max) NOT NULL,
	[Price] [real] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Order] [int] NOT NULL,
	[ProductId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Sizes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 12/6/2024 9:13:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [nvarchar](450) NOT NULL,
	[PaymentId] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[OrderId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241128163149_init', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241130035054_cleanup-schema', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241130102948_size-for-cartDetail', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241201064527_for-checkout-flow', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241204090134_add-transaction', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241204104010_fix-schema', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241205031131_update-order-create-update-time', N'8.0.11')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'09bff914-7005-4937-992e-51ca3efb326f', N'user', N'USER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7739b084-97a1-4fc2-a6ed-b3546679ed33', N'admin', N'ADMIN', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2f0e5b08-7c01-4a3a-98db-cb039574be46', N'09bff914-7005-4937-992e-51ca3efb326f')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ef882ca4-e34c-4113-a6c2-d66fe11fc840', N'09bff914-7005-4937-992e-51ca3efb326f')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8d2a6587-6e7d-4595-a818-30cf52f69be9', N'7739b084-97a1-4fc2-a6ed-b3546679ed33')
GO
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [URLImage], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [VerifyCode], [UserPaymentId]) VALUES (N'2f0e5b08-7c01-4a3a-98db-cb039574be46', N'Tan Vo', N'', N'tan.vo-2@yopmail.com', N'TAN.VO-2@YOPMAIL.COM', N'tan.vo-2@yopmail.com', N'TAN.VO-2@YOPMAIL.COM', 0, N'AQAAAAIAAYagAAAAEAi0wWBu7tCFsV/dHkOFGMYAqZe75NgmD0Y2/ZshUqJ7bmu4tibPoongvjdB+Xsfcg==', N'MBYHVEN65BOBKPBTKUDH3FT2KED77PM6', N'b09ce586-50bd-4a0a-8dab-57f2de8d0c1c', NULL, 0, 0, NULL, 1, 0, NULL, N'cus_RLAzxKnYdF1QDW')
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [URLImage], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [VerifyCode], [UserPaymentId]) VALUES (N'8d2a6587-6e7d-4595-a818-30cf52f69be9', N'Admin', N'', N'admin@yopmail.com', N'ADMIN@YOPMAIL.COM', N'admin@yopmail.com', N'ADMIN@YOPMAIL.COM', 0, N'AQAAAAIAAYagAAAAEEtUlDemsB+/2h4pTV//k+F+awYGXunzhfSY3AiLBATj0drW0wGcQLJZYhHsiDxUsQ==', N'MQFLPIIN6J3LHNCQ6ATQKWSQZOJN352B', N'67b542ae-a839-4257-bbfb-c911e8e035aa', NULL, 0, 0, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [URLImage], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [VerifyCode], [UserPaymentId]) VALUES (N'ef882ca4-e34c-4113-a6c2-d66fe11fc840', N'User', N'', N'user@yopmail.com', N'USER@YOPMAIL.COM', N'user@yopmail.com', N'USER@YOPMAIL.COM', 0, N'AQAAAAIAAYagAAAAEGlCLT/jMcgKTwvUMcUNJ7RHtcCXB7iGO5mmKkYwcxf9j3bvu4Ez3NXzuq2aLEXXig==', N'F26XOS7B46LKYJT6GKEVA5ZVOGNM4PC7', N'82163fba-da9d-41d2-9986-afe4d4385391', NULL, 0, 0, NULL, 1, 0, NULL, N'cus_RKubDROFH7UBYD')
GO
INSERT [dbo].[CartDetails] ([Id], [ProductId], [Quantity], [CartId], [SizeId]) VALUES (N'18a591e3-8925-405f-a230-e42fc7ceacd0', N'047b8ac4-4bfc-4498-8a57-56ffd472603b', 2, N'5f0b2d3a-e61d-4b21-81be-9e4f6c894a43', N'02f88ba0-5f67-4611-9526-173d16d032e0')
INSERT [dbo].[CartDetails] ([Id], [ProductId], [Quantity], [CartId], [SizeId]) VALUES (N'a70c6230-0cf8-437a-94a1-1a39952015f5', N'08befcf8-188d-4f90-98db-bbf670e7c8cd', 3, N'a92b0c8d-4b19-42e6-9013-64768aa8e2ff', N'1aa4b83c-a667-4727-9737-411a642e36f4')
GO
INSERT [dbo].[Carts] ([Id], [UserId], [IsActive]) VALUES (N'51e9263b-0378-4542-9420-3f43bf1ba610', N'2f0e5b08-7c01-4a3a-98db-cb039574be46', 0)
INSERT [dbo].[Carts] ([Id], [UserId], [IsActive]) VALUES (N'5c825ef8-165d-41b3-aa2d-d055b7581bdc', N'2f0e5b08-7c01-4a3a-98db-cb039574be46', 0)
INSERT [dbo].[Carts] ([Id], [UserId], [IsActive]) VALUES (N'5f0b2d3a-e61d-4b21-81be-9e4f6c894a43', N'2f0e5b08-7c01-4a3a-98db-cb039574be46', 0)
INSERT [dbo].[Carts] ([Id], [UserId], [IsActive]) VALUES (N'614ec768-77da-4a07-baf5-36e644a59fea', N'8d2a6587-6e7d-4595-a818-30cf52f69be9', 1)
INSERT [dbo].[Carts] ([Id], [UserId], [IsActive]) VALUES (N'7a1935e3-12fd-4450-9b95-fc38b3141ada', N'2f0e5b08-7c01-4a3a-98db-cb039574be46', 1)
INSERT [dbo].[Carts] ([Id], [UserId], [IsActive]) VALUES (N'a92b0c8d-4b19-42e6-9013-64768aa8e2ff', N'2f0e5b08-7c01-4a3a-98db-cb039574be46', 0)
GO
INSERT [dbo].[Categories] ([Id], [CategoryName], [CategoryDescription], [IsActive]) VALUES (N'0d14e660-dcb8-42fb-811c-cfa723eb3c79', N'Kid', N'Uniform for kid', 1)
INSERT [dbo].[Categories] ([Id], [CategoryName], [CategoryDescription], [IsActive]) VALUES (N'729f4772-a2c0-4b25-81ac-db1f7542b4c1', N'Men', N'Uniform for men', 1)
INSERT [dbo].[Categories] ([Id], [CategoryName], [CategoryDescription], [IsActive]) VALUES (N'e5cda419-38ea-4ee8-abd3-ff6dc718184a', N'Women', N'Uniform for women', 1)
GO
INSERT [dbo].[OrderDetails] ([Id], [ProductPrice], [Quantity], [ProductId], [OrderId]) VALUES (N'3cfe1712-ed53-460e-b709-b662c05abc5c', 40, 2, N'047b8ac4-4bfc-4498-8a57-56ffd472603b', N'15317eb8-7342-454a-b5df-47d2be82f74e')
INSERT [dbo].[OrderDetails] ([Id], [ProductPrice], [Quantity], [ProductId], [OrderId]) VALUES (N'e6d2d54b-afea-4947-a896-69adf9d334e5', 60, 3, N'08befcf8-188d-4f90-98db-bbf670e7c8cd', N'df21a7e9-a6a0-481c-a47e-6bc598debc2f')
GO
INSERT [dbo].[Orders] ([Id], [CouponId], [Total], [Status], [UserId], [DeliveryInformationId], [CreatedAt], [UpdatedAt]) VALUES (N'15317eb8-7342-454a-b5df-47d2be82f74e', NULL, CAST(80.00 AS Decimal(18, 2)), N'Succeed', N'2f0e5b08-7c01-4a3a-98db-cb039574be46', NULL, CAST(N'2024-12-05T11:38:27.3626085' AS DateTime2), CAST(N'2024-12-05T11:41:06.6241761' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [CouponId], [Total], [Status], [UserId], [DeliveryInformationId], [CreatedAt], [UpdatedAt]) VALUES (N'df21a7e9-a6a0-481c-a47e-6bc598debc2f', NULL, CAST(180.00 AS Decimal(18, 2)), N'Succeed', N'2f0e5b08-7c01-4a3a-98db-cb039574be46', NULL, CAST(N'2024-12-05T11:39:47.8883082' AS DateTime2), CAST(N'2024-12-05T11:40:37.2506536' AS DateTime2))
GO
INSERT [dbo].[PaymentProfiles] ([Id], [CardId], [Last4], [Brand], [UserId]) VALUES (N'00cc28a5-a2e1-4d77-baad-2d343fd031da', N'src_1QSWlL4gFB9qz1SHhhtAqWjV', N'', N'', N'2f0e5b08-7c01-4a3a-98db-cb039574be46')
INSERT [dbo].[PaymentProfiles] ([Id], [CardId], [Last4], [Brand], [UserId]) VALUES (N'236aa416-cf17-4b71-a520-46f991164e26', N'src_1QSKQe4gFB9qz1SHCIABzQBm', N'', N'', N'ef882ca4-e34c-4113-a6c2-d66fe11fc840')
INSERT [dbo].[PaymentProfiles] ([Id], [CardId], [Last4], [Brand], [UserId]) VALUES (N'37c6409f-4959-4162-bcd4-2a62cbdf455b', N'src_1QSUdX4gFB9qz1SHyZKRaKhC', N'', N'', N'2f0e5b08-7c01-4a3a-98db-cb039574be46')
INSERT [dbo].[PaymentProfiles] ([Id], [CardId], [Last4], [Brand], [UserId]) VALUES (N'493985ac-03f0-44c6-8177-75393c236105', N'src_1QSWgi4gFB9qz1SHR2qalFa7', N'', N'', N'2f0e5b08-7c01-4a3a-98db-cb039574be46')
INSERT [dbo].[PaymentProfiles] ([Id], [CardId], [Last4], [Brand], [UserId]) VALUES (N'56ae3e57-0896-4320-837d-19a307577626', N'src_1QSKja4gFB9qz1SHDcNWWnoq', N'', N'', N'ef882ca4-e34c-4113-a6c2-d66fe11fc840')
INSERT [dbo].[PaymentProfiles] ([Id], [CardId], [Last4], [Brand], [UserId]) VALUES (N'5fa4c564-d22b-4fdd-b024-9849b4d54ff5', N'src_1QSWpa4gFB9qz1SHKNIK4ZqQ', N'', N'', N'2f0e5b08-7c01-4a3a-98db-cb039574be46')
INSERT [dbo].[PaymentProfiles] ([Id], [CardId], [Last4], [Brand], [UserId]) VALUES (N'a7158877-61f6-474b-b316-25062327845b', N'src_1QSVkM4gFB9qz1SHBJn6tqIr', N'', N'', N'2f0e5b08-7c01-4a3a-98db-cb039574be46')
INSERT [dbo].[PaymentProfiles] ([Id], [CardId], [Last4], [Brand], [UserId]) VALUES (N'af7593c8-1810-4382-9ab8-a33f8a540bba', N'src_1QSWqs4gFB9qz1SH5F50jceF', N'', N'', N'2f0e5b08-7c01-4a3a-98db-cb039574be46')
INSERT [dbo].[PaymentProfiles] ([Id], [CardId], [Last4], [Brand], [UserId]) VALUES (N'b4d41b1a-ad6e-441f-ac4d-f4cd3ca5a6e8', N'src_1QSEmG4gFB9qz1SHncpxK4gY', N'', N'', N'ef882ca4-e34c-4113-a6c2-d66fe11fc840')
INSERT [dbo].[PaymentProfiles] ([Id], [CardId], [Last4], [Brand], [UserId]) VALUES (N'b7a32f64-1971-4f4a-a1fe-5c03181fdb8c', N'src_1QSVld4gFB9qz1SH0ExY6HMa', N'', N'', N'2f0e5b08-7c01-4a3a-98db-cb039574be46')
INSERT [dbo].[PaymentProfiles] ([Id], [CardId], [Last4], [Brand], [UserId]) VALUES (N'baf6d7da-bb55-4bd1-a31c-a7d9fa7084a1', N'src_1QSG5u4gFB9qz1SHxvgEbAo1', N'', N'', N'ef882ca4-e34c-4113-a6c2-d66fe11fc840')
INSERT [dbo].[PaymentProfiles] ([Id], [CardId], [Last4], [Brand], [UserId]) VALUES (N'c00d0c89-4cc0-4c01-bcd8-1fffdd2c8227', N'src_1QSEpE4gFB9qz1SHYxho4P8B', N'', N'', N'ef882ca4-e34c-4113-a6c2-d66fe11fc840')
INSERT [dbo].[PaymentProfiles] ([Id], [CardId], [Last4], [Brand], [UserId]) VALUES (N'e463d3f3-c9ba-4fb8-8b45-24d5f15ab9bc', N'src_1QSVjY4gFB9qz1SHC0BRrUbD', N'', N'', N'2f0e5b08-7c01-4a3a-98db-cb039574be46')
INSERT [dbo].[PaymentProfiles] ([Id], [CardId], [Last4], [Brand], [UserId]) VALUES (N'eeab1753-ad5e-4002-8602-4eda21585e58', N'src_1QSKSm4gFB9qz1SH4BOPJ3Z8', N'', N'', N'ef882ca4-e34c-4113-a6c2-d66fe11fc840')
GO
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'047b8ac4-4bfc-4498-8a57-56ffd472603b', N'Twinkle Toes Skirt', N'https://images.unsplash.com/photo-1542601524107-6a85034106d7?q=80&w=1332&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 1, N'0d14e660-dcb8-42fb-811c-cfa723eb3c79')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'08befcf8-188d-4f90-98db-bbf670e7c8cd', N'Blooming Skirt', N'https://plus.unsplash.com/premium_photo-1723914108893-ac3047a4f1df?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 1, N'e5cda419-38ea-4ee8-abd3-ff6dc718184a')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'0f6a0216-6ba6-49fb-bcea-392567f75b55', N'Twirl & Shine Skirt', N'https://plus.unsplash.com/premium_photo-1671379102281-7225f3d3d97d?q=80&w=1287&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 1, N'e5cda419-38ea-4ee8-abd3-ff6dc718184a')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'0face891-da76-4e16-8cad-1a920c6f9093', N'Fairy Tale Flare Skirt', N'https://media.istockphoto.com/id/637556930/vi/anh/v%C3%A1y-h%E1%BB%93ng-b%E1%BB%8B-c%C3%B4-l%E1%BA%ADp.jpg?s=1024x1024&w=is&k=20&c=0fTzebcK1BCTv-I0V6eaAIsMsKeIT6riq0q7V9ramdw=', 1, N'0d14e660-dcb8-42fb-811c-cfa723eb3c79')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'11c41dfb-35a8-49b6-b764-137af50b05eb', N'Chill Vibes Tee', N'https://m.media-amazon.com/images/I/B1pppR4gVKL._CLa%7C2140%2C2000%7C813dAju1jqL.png%7C0%2C0%2C2140%2C2000%2B0.0%2C0.0%2C2140.0%2C2000.0_AC_SX385_.png', 1, N'729f4772-a2c0-4b25-81ac-db1f7542b4c1')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'11e3ea57-9be0-4c5c-81c4-f64948e404f8', N'Denim Daisy Skirt', N'https://olliesplace.com.au/cdn/shop/files/IPJG7136-girls-daisy-denim-skirt-kids-shop-online.jpg?v=1723376963&width=600', 1, N'e5cda419-38ea-4ee8-abd3-ff6dc718184a')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'14281dc0-822e-489c-b381-9d8fe47b49e7', N'Ocean Wave Tee', N'https://m.media-amazon.com/images/I/81XnRm0kGbL._AC_SX425_.jpg', 1, N'729f4772-a2c0-4b25-81ac-db1f7542b4c1')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'45589bf7-7041-4d42-9685-d2316f9a5ba3', N'Rainbow Ruffle Skirt', N'https://m.media-amazon.com/images/I/51yb3YvsgZL._AC_SX385_.jpg', 1, N'0d14e660-dcb8-42fb-811c-cfa723eb3c79')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'4e379c7c-5017-4b3a-a695-a4bf825ed897', N'Lilac Breeze Skirt', N'https://m.media-amazon.com/images/I/51eqKEPDMGL._AC_SX342_.jpg', 1, N'e5cda419-38ea-4ee8-abd3-ff6dc718184a')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'4e6849db-a819-41d8-85de-a45e2a000935', N'Autumn Flare Skirt', N'https://m.media-amazon.com/images/I/71V3m0lRLUL._AC_SX342_.jpg', 1, N'e5cda419-38ea-4ee8-abd3-ff6dc718184a')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'4f52fbe2-c104-489b-8b86-cacef3612ecb', N'Sunny Stripes Skirt', N'https://m.media-amazon.com/images/I/619z5HteTRL._AC_SX342_.jpg', 1, N'e5cda419-38ea-4ee8-abd3-ff6dc718184a')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'5278d805-3897-46ef-a391-6dfc06676d75', N'Elegant Wrap Skirt', N'https://m.media-amazon.com/images/I/51WawM2kr4L._AC_SX342_.jpg', 1, N'e5cda419-38ea-4ee8-abd3-ff6dc718184a')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'57aa1533-274e-4ff2-b8f5-712e796bdf33', N'Daisy Meadow Skirt', N'https://m.media-amazon.com/images/I/81GkWj8ZuCL._AC_SX342_.jpg', 1, N'0d14e660-dcb8-42fb-811c-cfa723eb3c79')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'6789563f-e9a4-4cc0-a0ce-6cd43d391a2c', N'Urban Graphic Tee', N'https://m.media-amazon.com/images/I/71O8r617cKL._AC_SY445_.jpg', 1, N'729f4772-a2c0-4b25-81ac-db1f7542b4c1')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'6acc094d-ace0-4b9d-a1a2-8167e4f3bc9d', N'Petite Ruffle Skirt', N'https://m.media-amazon.com/images/I/512X3i5Tp1L._AC_SX342_.jpg', 1, N'e5cda419-38ea-4ee8-abd3-ff6dc718184a')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'6b968d85-8ef1-452c-b07c-227f7b9a0c59', N'Sparkle Princess Skirt', N'https://m.media-amazon.com/images/I/615QeAqQGKL._AC_SX425_.jpg', 1, N'0d14e660-dcb8-42fb-811c-cfa723eb3c79')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'6f3a6616-99a8-4ee9-bdb2-6d0c55dad4ab', N'Butterfly Breeze Skirt', N'https://m.media-amazon.com/images/I/717Q1-YdSjL._AC_SX342_.jpg', 1, N'0d14e660-dcb8-42fb-811c-cfa723eb3c79')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'84da11f2-3a44-45d7-8ed1-48d279668def', N'Classic Cotton Tee', N'https://m.media-amazon.com/images/I/71cy42IYYrL._AC_SX342_.jpg', 1, N'729f4772-a2c0-4b25-81ac-db1f7542b4c1')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'8c9b83ce-d7c9-47d9-b4d2-de7f42272a5b', N'Bold Stripe Tee', N'https://m.media-amazon.com/images/I/81p1BNHsG6L._AC_SX342_.jpg', 1, N'729f4772-a2c0-4b25-81ac-db1f7542b4c1')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'92894bbf-ffc9-4b04-9cc3-8b707c592339', N'Sunset Horizon Tee', N'https://m.media-amazon.com/images/I/71zYqqarJrL._AC_SX342_.jpg', 1, N'729f4772-a2c0-4b25-81ac-db1f7542b4c1')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'9519078f-cd3e-47bd-ae03-7e505fb44784', N'Golden Glow Skirt', N'https://m.media-amazon.com/images/I/71bt9whgxsL._AC_SX342_.jpg', 1, N'e5cda419-38ea-4ee8-abd3-ff6dc718184a')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'95ccce30-3724-4714-895c-ce6713bcec37', N'Minimalist Logo Tee', N'https://m.media-amazon.com/images/I/B1ieKaTDQdL._CLa%7C2140%2C2000%7C61N6fFJbUaL.png%7C0%2C0%2C2140%2C2000%2B0.0%2C0.0%2C2140.0%2C2000.0_AC_SX342_.png', 1, N'729f4772-a2c0-4b25-81ac-db1f7542b4c1')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'975a99bc-47bd-4d6d-9702-f96676dff30b', N'Vintage Wash Tee', N'https://m.media-amazon.com/images/I/71us0GKQQXL._AC_SX342_.jpg', 1, N'729f4772-a2c0-4b25-81ac-db1f7542b4c1')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'9931d466-467e-4cb1-aed3-08190680ba76', N'Sports Luxe Tee', N'https://m.media-amazon.com/images/I/71LPdu26vxL._AC_SX342_.jpg', 1, N'729f4772-a2c0-4b25-81ac-db1f7542b4c1')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'9a0fe57a-b94a-4936-921b-d6106d468177', N'Playful Plaid Skirt', N'https://m.media-amazon.com/images/I/71N41SfkHqL._AC_SX342_.jpg', 1, N'e5cda419-38ea-4ee8-abd3-ff6dc718184a')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'9b8c319a-d751-41b1-88fa-ba0850491f52', N'Midnight Glow Skirt', N'https://m.media-amazon.com/images/I/51PMs0Aqe5L._AC_SX342_.jpg', 1, N'e5cda419-38ea-4ee8-abd3-ff6dc718184a')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'a82028a6-12b6-46bc-bce2-7d3e10f7d212', N'Comfy Everyday Tee', N'https://m.media-amazon.com/images/I/71h0yd2XPML._AC_SX342_.jpg', 1, N'729f4772-a2c0-4b25-81ac-db1f7542b4c1')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'af08417d-356f-4349-bb73-b9983288fb83', N'Forest Path Tee', N'https://m.media-amazon.com/images/I/81dql97KbeL._AC_SX342_.jpg', 1, N'729f4772-a2c0-4b25-81ac-db1f7542b4c1')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'b098fa95-15f8-430e-949c-a767670f7070', N'Magic Carousel Skirt', N'https://m.media-amazon.com/images/I/819Hfs37C3L._AC_SX385_.jpg', 1, N'0d14e660-dcb8-42fb-811c-cfa723eb3c79')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'bb96ab79-337e-42c3-8e4f-65f62bd9e704', N'Rocket Blast Tee', N'https://m.media-amazon.com/images/I/71EE4TEXiDL._AC_SX342_.jpg', 1, N'0d14e660-dcb8-42fb-811c-cfa723eb3c79')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'bb98aaa6-2945-499c-83af-5c5835ed82aa', N'Dynamic Duo Tee', N'https://m.media-amazon.com/images/I/71-NIMulDnL._AC_SX342_.jpg', 1, N'729f4772-a2c0-4b25-81ac-db1f7542b4c1')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'bee623a8-5781-4ea7-98f6-75fd2e043bbc', N'Jungle Explorer Tee', N'https://m.media-amazon.com/images/I/B1pppR4gVKL._CLa%7C2140%2C2000%7C81Bba3vxfPL.png%7C0%2C0%2C2140%2C2000%2B0.0%2C0.0%2C2140.0%2C2000.0_AC_SX342_.png', 1, N'0d14e660-dcb8-42fb-811c-cfa723eb3c79')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'c2ca6d8b-46c1-4482-a309-ace47e99a238', N'Gentle Waves Skirt', N'https://m.media-amazon.com/images/I/61eaJhFX-SL._AC_SX342_.jpg', 1, N'e5cda419-38ea-4ee8-abd3-ff6dc718184a')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'd0172042-0c8d-459a-a72b-29b09e167eff', N'Rainbow Adventure Tee', N'https://m.media-amazon.com/images/I/61kXw8PvSDL._AC_SX342_.jpg', 1, N'0d14e660-dcb8-42fb-811c-cfa723eb3c79')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'd20dc7fe-c7da-4b6d-85ce-987bf079aad1', N'Dino Roar Tee', N'https://m.media-amazon.com/images/I/81KYTWXHucL._AC_SX342_.jpg', 1, N'0d14e660-dcb8-42fb-811c-cfa723eb3c79')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'd8fd266a-3795-4f9f-9e36-2471f15fde45', N'Festive Fringe Skirt', N'https://m.media-amazon.com/images/I/71oEVvj53xL._AC_SX385_.jpg', 1, N'e5cda419-38ea-4ee8-abd3-ff6dc718184a')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'ddd65800-bab4-4f15-b322-864bb1352639', N'Peaceful Plains Tee', N'https://m.media-amazon.com/images/I/B1pppR4gVKL._CLa%7C2140%2C2000%7C51a9rdBFuiL.png%7C0%2C0%2C2140%2C2000%2B0.0%2C0.0%2C2140.0%2C2000.0_AC_SX342_.png', 1, N'729f4772-a2c0-4b25-81ac-db1f7542b4c1')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'e4b6e6fd-ff6b-44ff-b02d-2afa60ac9ba8', N'Happy Camper Tee', N'https://m.media-amazon.com/images/I/71GWkwYX+mL._AC_SX385_.jpg', 1, N'0d14e660-dcb8-42fb-811c-cfa723eb3c79')
INSERT [dbo].[Products] ([Id], [ProductName], [URLImage], [IsActive], [CategoryId]) VALUES (N'f72c5066-ecfb-4a75-b20c-2df0f30131ff', N'Cuddly Bear Tee', N'https://m.media-amazon.com/images/I/71+wV3-BLWL._AC_SX425_.jpg', 1, N'0d14e660-dcb8-42fb-811c-cfa723eb3c79')
GO
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'00e0a7d1-d80b-4f3f-8148-9a3508f13b29', N'L', 60, 100, 3, N'975a99bc-47bd-4d6d-9702-f96676dff30b')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'0115d9df-c761-4c89-a827-68f6460461bf', N'L', 60, 100, 3, N'4e6849db-a819-41d8-85de-a45e2a000935')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'01dc335b-b061-4392-9556-b5ca21e6b820', N'L', 60, 100, 3, N'5278d805-3897-46ef-a391-6dfc06676d75')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'02d94d23-c8cc-4b4b-8040-a2da06c32cf7', N'S', 40, 100, 1, N'11c41dfb-35a8-49b6-b764-137af50b05eb')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'02f88ba0-5f67-4611-9526-173d16d032e0', N'S', 40, 100, 1, N'047b8ac4-4bfc-4498-8a57-56ffd472603b')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'032bea13-3caa-48e9-8a50-2913c7a0c5de', N'S', 40, 100, 1, N'ddd65800-bab4-4f15-b322-864bb1352639')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'06502f21-3651-497b-819e-1db05fdee9d3', N'L', 60, 100, 3, N'bee623a8-5781-4ea7-98f6-75fd2e043bbc')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'07349518-059a-40d3-a448-d8bd0761beff', N'S', 40, 100, 1, N'a82028a6-12b6-46bc-bce2-7d3e10f7d212')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'083e4523-41e3-4dda-b7ec-701084778f71', N'M', 55, 100, 2, N'9931d466-467e-4cb1-aed3-08190680ba76')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'0a7edf43-179c-4458-8615-49a5f7854f6d', N'M', 55, 100, 2, N'6b968d85-8ef1-452c-b07c-227f7b9a0c59')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'0b12066a-222e-4ff3-9198-28a6a0f83355', N'M', 55, 100, 2, N'92894bbf-ffc9-4b04-9cc3-8b707c592339')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'0c4e216a-4a05-47ec-9f42-65fce4483214', N'L', 60, 100, 3, N'9931d466-467e-4cb1-aed3-08190680ba76')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'116d6be9-1cc0-4b47-9625-cd3b069e86f1', N'M', 55, 100, 2, N'ddd65800-bab4-4f15-b322-864bb1352639')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'123430d8-d22c-4efb-8f0f-17e6963bbee8', N'S', 40, 100, 1, N'4e6849db-a819-41d8-85de-a45e2a000935')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'19a1add8-c5e0-4aee-bba8-b6ddba233b4b', N'L', 60, 100, 3, N'6b968d85-8ef1-452c-b07c-227f7b9a0c59')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'1a3a2fd1-9960-4d38-b36e-45a937882f45', N'M', 55, 100, 2, N'5278d805-3897-46ef-a391-6dfc06676d75')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'1aa4b83c-a667-4727-9737-411a642e36f4', N'L', 60, 100, 3, N'08befcf8-188d-4f90-98db-bbf670e7c8cd')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'1b0aab18-4bea-4aa8-a2a7-7d945c55fb93', N'S', 40, 100, 1, N'd0172042-0c8d-459a-a72b-29b09e167eff')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'1b0fa59f-e164-4c20-8095-7355afa8a61a', N'L', 60, 100, 3, N'0face891-da76-4e16-8cad-1a920c6f9093')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'1deabf25-543a-424c-8c80-7e994cd300eb', N'M', 55, 100, 2, N'af08417d-356f-4349-bb73-b9983288fb83')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'1fbea1d2-3213-4b2d-9fbe-ee3f9df701a2', N'L', 60, 100, 3, N'047b8ac4-4bfc-4498-8a57-56ffd472603b')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'228d97d9-588e-4185-98e9-e890f2b9fee2', N'S', 40, 100, 1, N'4f52fbe2-c104-489b-8b86-cacef3612ecb')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'257380c2-c83a-4ddf-b258-bb3bdb5ba2cb', N'S', 40, 100, 1, N'9a0fe57a-b94a-4936-921b-d6106d468177')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'25d96db2-c5b9-4256-a832-93c54be56aeb', N'S', 40, 100, 1, N'6789563f-e9a4-4cc0-a0ce-6cd43d391a2c')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'2b37251c-6f94-4574-b8a7-eef6ce909723', N'M', 55, 100, 2, N'8c9b83ce-d7c9-47d9-b4d2-de7f42272a5b')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'2c261722-46f6-4d21-84db-5292fcdbc0a0', N'M', 55, 100, 2, N'4e6849db-a819-41d8-85de-a45e2a000935')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'2f1c6142-2425-487d-87e2-d5023d035228', N'S', 40, 100, 1, N'e4b6e6fd-ff6b-44ff-b02d-2afa60ac9ba8')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'35210ccc-dc66-43d7-a852-edbcb98298b6', N'L', 60, 100, 3, N'14281dc0-822e-489c-b381-9d8fe47b49e7')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'3954ee68-896a-4bf8-ba90-bb4c52015e7e', N'S', 40, 100, 1, N'0face891-da76-4e16-8cad-1a920c6f9093')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'39a38cd7-2b75-4e94-bb24-c49b6ddba7e5', N'M', 55, 100, 2, N'a82028a6-12b6-46bc-bce2-7d3e10f7d212')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'3e5c0f93-473a-4588-b42c-8df968adb49b', N'M', 55, 100, 2, N'9519078f-cd3e-47bd-ae03-7e505fb44784')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'3eaff1f4-a9f9-40fd-93e1-a4ab123ad3e7', N'S', 50, 100, 1, N'11e3ea57-9be0-4c5c-81c4-f64948e404f8')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'403a2667-3fec-4ae0-af14-98122253d0f1', N'M', 55, 100, 2, N'57aa1533-274e-4ff2-b8f5-712e796bdf33')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'43401538-d75e-45d7-a166-c9e8e3738da5', N'M', 55, 100, 2, N'd20dc7fe-c7da-4b6d-85ce-987bf079aad1')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'45c8425d-e2e5-47c1-9fcb-446ecf75afe1', N'L', 60, 100, 3, N'9519078f-cd3e-47bd-ae03-7e505fb44784')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'4d67506b-3f8c-4c83-8a5a-b57a254f015f', N'S', 40, 100, 1, N'6acc094d-ace0-4b9d-a1a2-8167e4f3bc9d')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'4df34fc4-075d-4de1-b4ab-077d12af86a4', N'S', 40, 100, 1, N'bb96ab79-337e-42c3-8e4f-65f62bd9e704')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'4f26f83b-815b-4bf3-8f75-c30ac96867df', N'S', 40, 100, 1, N'5278d805-3897-46ef-a391-6dfc06676d75')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'521fe872-1e06-456a-abe5-144aa065efec', N'L', 60, 100, 3, N'95ccce30-3724-4714-895c-ce6713bcec37')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'594ad742-60a7-4bef-ae7f-b3cd1d94c635', N'L', 60, 100, 3, N'92894bbf-ffc9-4b04-9cc3-8b707c592339')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'5a1decc0-bfae-479e-a693-bc521689400d', N'M', 55, 100, 2, N'0f6a0216-6ba6-49fb-bcea-392567f75b55')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'5a9db1ed-64fe-4342-b751-0373c0d80912', N'L', 60, 100, 3, N'bb98aaa6-2945-499c-83af-5c5835ed82aa')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'5b2b9948-812f-411f-9ac2-9c7aa7beba35', N'M', 55, 100, 2, N'95ccce30-3724-4714-895c-ce6713bcec37')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'5b675e30-bd7e-4cf2-a138-56fdb3509b35', N'M', 55, 100, 2, N'14281dc0-822e-489c-b381-9d8fe47b49e7')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'5c8e07d0-fc7a-436f-ab1f-482a0d154892', N'S', 40, 100, 1, N'57aa1533-274e-4ff2-b8f5-712e796bdf33')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'5d7e8f4a-694b-4eb4-83c3-171c88137806', N'M', 55, 100, 2, N'bb96ab79-337e-42c3-8e4f-65f62bd9e704')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'5df7719d-84f8-41cc-bacc-7a65e6e14519', N'S', 40, 100, 1, N'af08417d-356f-4349-bb73-b9983288fb83')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'5fc73f1c-9657-40ca-908b-caaad74a8df8', N'L', 60, 100, 3, N'af08417d-356f-4349-bb73-b9983288fb83')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'6017ef54-b336-4431-834e-744d8d30ff98', N'S', 40, 100, 1, N'bb98aaa6-2945-499c-83af-5c5835ed82aa')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'634e4c9b-874d-4517-8c66-230a08fb22dc', N'S', 40, 100, 1, N'd8fd266a-3795-4f9f-9e36-2471f15fde45')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'670772fa-5259-4ed3-8476-494727c78caf', N'M', 55, 100, 2, N'11c41dfb-35a8-49b6-b764-137af50b05eb')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'6829f0e7-2a74-43c5-b0a6-f3407fd8c664', N'S', 40, 100, 1, N'9b8c319a-d751-41b1-88fa-ba0850491f52')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'689700ed-6c97-4590-a114-0720d933e29f', N'S', 40, 100, 1, N'08befcf8-188d-4f90-98db-bbf670e7c8cd')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'6ad60b4f-cacd-4e1d-9ac7-28281da95722', N'L', 60, 100, 3, N'e4b6e6fd-ff6b-44ff-b02d-2afa60ac9ba8')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'6bf87a19-95a1-4e82-bcf3-e87d9bd536a6', N'S', 40, 100, 1, N'92894bbf-ffc9-4b04-9cc3-8b707c592339')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'6dc53d2d-6f53-46c4-997f-854089ed7aae', N'L', 60, 100, 3, N'0f6a0216-6ba6-49fb-bcea-392567f75b55')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'6fefe9ba-078d-4cd4-b9a0-cb294335a7cc', N'S', 40, 100, 1, N'45589bf7-7041-4d42-9685-d2316f9a5ba3')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'76baf688-d509-4394-bd44-03cb3bf1a1f2', N'L', 60, 100, 3, N'd20dc7fe-c7da-4b6d-85ce-987bf079aad1')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'7b9ac9d9-0107-441c-8461-47917455b94f', N'M', 55, 100, 2, N'd0172042-0c8d-459a-a72b-29b09e167eff')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'7c418be5-d36f-4387-bc3e-436f79b74808', N'S', 40, 100, 1, N'975a99bc-47bd-4d6d-9702-f96676dff30b')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'7d77e947-536b-44bf-be1e-11f73225c412', N'M', 55, 100, 2, N'bb98aaa6-2945-499c-83af-5c5835ed82aa')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'8056ac6d-fd10-4263-ab19-765d368c6ec4', N'L', 60, 100, 3, N'b098fa95-15f8-430e-949c-a767670f7070')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'8081c81a-676c-4108-84e1-59715221e044', N'L', 60, 100, 3, N'6acc094d-ace0-4b9d-a1a2-8167e4f3bc9d')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'8180d4b2-847f-41ce-bbd5-3854a7b3e088', N'M', 55, 100, 2, N'b098fa95-15f8-430e-949c-a767670f7070')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'842e8c3c-1e93-4558-b517-484736f0cf38', N'M', 55, 100, 2, N'6acc094d-ace0-4b9d-a1a2-8167e4f3bc9d')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'874d6747-578f-4996-a989-b94e7b9dae08', N'L', 60, 100, 3, N'84da11f2-3a44-45d7-8ed1-48d279668def')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'89db453a-943e-4aa9-ab60-bcd857ec2517', N'L', 60, 100, 3, N'6f3a6616-99a8-4ee9-bdb2-6d0c55dad4ab')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'8b248d42-c220-4201-b1f0-81778826c6e3', N'M', 55, 100, 2, N'9a0fe57a-b94a-4936-921b-d6106d468177')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'8b427d0b-9c45-4cf6-b2bf-70f87b476a77', N'M', 55, 100, 2, N'f72c5066-ecfb-4a75-b20c-2df0f30131ff')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'91ba7b7c-2a36-4205-90d8-4f8dd38b6654', N'M', 55, 100, 2, N'd8fd266a-3795-4f9f-9e36-2471f15fde45')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'92772457-1ed5-478e-83ee-1c33103c1d4e', N'L', 60, 100, 3, N'4f52fbe2-c104-489b-8b86-cacef3612ecb')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'9416853c-a587-4d1d-93e5-f8a792752611', N'S', 50, 100, 1, N'84da11f2-3a44-45d7-8ed1-48d279668def')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'9688ff07-c8d0-4b0b-ba87-b71c805de452', N'M', 55, 100, 2, N'4e379c7c-5017-4b3a-a695-a4bf825ed897')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'9b5075f5-ed28-4a9f-b540-43bc513f26e4', N'M', 55, 100, 2, N'047b8ac4-4bfc-4498-8a57-56ffd472603b')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'9eb25acb-f878-4797-8408-217011ef1719', N'S', 40, 100, 1, N'b098fa95-15f8-430e-949c-a767670f7070')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'a1ee703a-368d-4697-9f95-b4e0beb218bd', N'M', 55, 100, 2, N'45589bf7-7041-4d42-9685-d2316f9a5ba3')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'a295fd39-47f0-48a9-b5d5-36bf89a693d8', N'M', 55, 100, 2, N'bee623a8-5781-4ea7-98f6-75fd2e043bbc')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'a2dcc95e-1bde-4050-94de-ece7d84fbd2a', N'S', 40, 100, 1, N'8c9b83ce-d7c9-47d9-b4d2-de7f42272a5b')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'a6f4bd54-f923-4b81-8191-47cce30fa33f', N'L', 60, 100, 3, N'9b8c319a-d751-41b1-88fa-ba0850491f52')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'a809c8cc-9da3-4666-a21b-599e33b82857', N'L', 60, 100, 3, N'11c41dfb-35a8-49b6-b764-137af50b05eb')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'a83bca0e-a59b-4d7b-af39-37375ba6c732', N'M', 55, 100, 2, N'84da11f2-3a44-45d7-8ed1-48d279668def')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'a88cea4d-d1f8-4872-8d45-c1a751c3e975', N'L', 60, 100, 3, N'd8fd266a-3795-4f9f-9e36-2471f15fde45')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'af1df257-2f49-454d-a5c6-4d1b6e62e811', N'L', 60, 100, 3, N'f72c5066-ecfb-4a75-b20c-2df0f30131ff')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'afe80385-7884-409a-a328-c20619a0a535', N'S', 40, 100, 1, N'bee623a8-5781-4ea7-98f6-75fd2e043bbc')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'b03d7ca7-c9ac-4b49-a540-49daee639414', N'S', 40, 100, 1, N'f72c5066-ecfb-4a75-b20c-2df0f30131ff')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'b0e236dc-761f-4da3-98a6-9e6abe3df711', N'L', 60, 100, 3, N'8c9b83ce-d7c9-47d9-b4d2-de7f42272a5b')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'b732e798-3ac2-4a7c-a3f7-fa16ed65763e', N'S', 40, 100, 1, N'c2ca6d8b-46c1-4482-a309-ace47e99a238')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'b9e2717d-6a13-429f-970e-7f0886480b1d', N'M', 55, 100, 2, N'c2ca6d8b-46c1-4482-a309-ace47e99a238')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'bbeba4d9-359d-43a4-a6f5-72d3ed0c0f5f', N'M', 55, 100, 2, N'6f3a6616-99a8-4ee9-bdb2-6d0c55dad4ab')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'bca3b805-94ae-462b-82bd-26187191491a', N'L', 60, 100, 3, N'ddd65800-bab4-4f15-b322-864bb1352639')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'c349dfbe-09bc-4185-96a2-d68f16f192f1', N'L', 60, 100, 3, N'a82028a6-12b6-46bc-bce2-7d3e10f7d212')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'c62c8a57-be1a-4446-95db-ade0902ff00d', N'S', 40, 100, 1, N'd20dc7fe-c7da-4b6d-85ce-987bf079aad1')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'c71de178-0a0b-4a7f-aa08-bb97c87e971f', N'M', 55, 100, 2, N'e4b6e6fd-ff6b-44ff-b02d-2afa60ac9ba8')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'cece5fa8-4532-4027-acfe-feff839e0bca', N'L', 60, 100, 3, N'45589bf7-7041-4d42-9685-d2316f9a5ba3')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'd3cfacc7-8ffb-4200-842b-f2d1ad0cbf4a', N'L', 60, 100, 3, N'c2ca6d8b-46c1-4482-a309-ace47e99a238')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'd6c67149-7d6c-40fa-8485-4b46de6865ff', N'L', 60, 100, 3, N'd0172042-0c8d-459a-a72b-29b09e167eff')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'd9e8da4a-ce30-41c0-9f20-528aa9f1522a', N'L', 60, 100, 3, N'9a0fe57a-b94a-4936-921b-d6106d468177')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'd9f68a39-6e9d-412b-a207-7efe64173fb2', N'M', 55, 100, 2, N'0face891-da76-4e16-8cad-1a920c6f9093')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'db8f7cd9-a987-4a8c-9452-846e8ea22484', N'L', 60, 100, 3, N'4e379c7c-5017-4b3a-a695-a4bf825ed897')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'ddc4501f-bf43-4447-9f8e-8d5cafce21fe', N'S', 40, 100, 1, N'95ccce30-3724-4714-895c-ce6713bcec37')
GO
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'ddfd6de2-6f1f-438f-ba73-e96d67159182', N'S', 40, 100, 1, N'9931d466-467e-4cb1-aed3-08190680ba76')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'de64a12b-cd05-4271-af2d-7437a40c3770', N'S', 40, 100, 1, N'4e379c7c-5017-4b3a-a695-a4bf825ed897')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'e0411f3a-02bb-4730-a1ef-ce8f50fdaeec', N'M', 55, 100, 2, N'975a99bc-47bd-4d6d-9702-f96676dff30b')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'e0a194a5-58f6-40f4-a748-3c5821bdd269', N'M', 55, 100, 2, N'9b8c319a-d751-41b1-88fa-ba0850491f52')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'e0fbed24-5e71-4c87-ad6e-e9a0e2b079c1', N'L', 60, 100, 3, N'57aa1533-274e-4ff2-b8f5-712e796bdf33')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'e61e25a2-1e33-427c-a8e9-c37e49c71fca', N'M', 55, 100, 2, N'08befcf8-188d-4f90-98db-bbf670e7c8cd')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'e6224dc5-30b7-40db-82cc-b851fa7999a4', N'S', 40, 100, 1, N'0f6a0216-6ba6-49fb-bcea-392567f75b55')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'e9ae23f1-a5d6-4af8-a976-bd89b23360f0', N'S', 40, 100, 1, N'14281dc0-822e-489c-b381-9d8fe47b49e7')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'eac1562f-9a7d-4fdf-ba2b-043f3ae13934', N'M', 55, 100, 2, N'11e3ea57-9be0-4c5c-81c4-f64948e404f8')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'ebc6ffb2-cfcf-4570-be5f-634bc33af3b0', N'L', 60, 100, 3, N'11e3ea57-9be0-4c5c-81c4-f64948e404f8')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'ee164000-afd6-45c1-9c8d-3b1eeab7ebfa', N'L', 60, 100, 3, N'bb96ab79-337e-42c3-8e4f-65f62bd9e704')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'efe7f883-57fa-4e0f-ba3e-c537db1ee9a3', N'S', 40, 100, 1, N'6b968d85-8ef1-452c-b07c-227f7b9a0c59')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'f16aab13-73f5-4038-8060-4d3f57ac7a90', N'S', 40, 100, 1, N'9519078f-cd3e-47bd-ae03-7e505fb44784')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'f610b10c-8967-4cac-ae8e-57c5aeb2e334', N'M', 55, 100, 2, N'4f52fbe2-c104-489b-8b86-cacef3612ecb')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'fa0a7870-4ead-46c7-9abe-19fd637d1ddd', N'S', 40, 100, 1, N'6f3a6616-99a8-4ee9-bdb2-6d0c55dad4ab')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'fba7bf82-fad8-4dc3-97c2-1f4c4994e918', N'L', 60, 100, 3, N'6789563f-e9a4-4cc0-a0ce-6cd43d391a2c')
INSERT [dbo].[Sizes] ([Id], [SizeName], [Price], [Quantity], [Order], [ProductId]) VALUES (N'fcab9003-6155-48bf-a061-f450dbfbe2ea', N'M', 55, 100, 2, N'6789563f-e9a4-4cc0-a0ce-6cd43d391a2c')
GO
INSERT [dbo].[Transactions] ([Id], [PaymentId], [Status], [OrderId]) VALUES (N'2eeb6f12-473d-4f9f-93f6-15c390d79f4a', N'pi_3QSWqu4gFB9qz1SH0adhUrTE', N'requires_payment_method', N'df21a7e9-a6a0-481c-a47e-6bc598debc2f')
INSERT [dbo].[Transactions] ([Id], [PaymentId], [Status], [OrderId]) VALUES (N'c9ff3a6a-cb45-47a0-b863-a5d90b812c6c', N'pi_3QSWpb4gFB9qz1SH1OsADutC', N'requires_payment_method', N'15317eb8-7342-454a-b5df-47d2be82f74e')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CartDetails_CartId]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_CartDetails_CartId] ON [dbo].[CartDetails]
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CartDetails_ProductId]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_CartDetails_ProductId] ON [dbo].[CartDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CartDetails_SizeId]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_CartDetails_SizeId] ON [dbo].[CartDetails]
(
	[SizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_OrderDetails_OrderId]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderId] ON [dbo].[OrderDetails]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_OrderDetails_ProductId]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductId] ON [dbo].[OrderDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Orders_CouponId]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_CouponId] ON [dbo].[Orders]
(
	[CouponId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Orders_DeliveryInformationId]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_DeliveryInformationId] ON [dbo].[Orders]
(
	[DeliveryInformationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Orders_UserId]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_UserId] ON [dbo].[Orders]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Sizes_ProductId]    Script Date: 12/6/2024 9:13:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Sizes_ProductId] ON [dbo].[Sizes]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DeliveryInformations] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDefault]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CartDetails]  WITH CHECK ADD  CONSTRAINT [FK_CartDetails_Carts_CartId] FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartDetails] CHECK CONSTRAINT [FK_CartDetails_Carts_CartId]
GO
ALTER TABLE [dbo].[CartDetails]  WITH CHECK ADD  CONSTRAINT [FK_CartDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartDetails] CHECK CONSTRAINT [FK_CartDetails_Products_ProductId]
GO
ALTER TABLE [dbo].[CartDetails]  WITH CHECK ADD  CONSTRAINT [FK_CartDetails_Sizes_SizeId] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Sizes] ([Id])
GO
ALTER TABLE [dbo].[CartDetails] CHECK CONSTRAINT [FK_CartDetails_Sizes_SizeId]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Coupons_CouponId] FOREIGN KEY([CouponId])
REFERENCES [dbo].[Coupons] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Coupons_CouponId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_DeliveryInformations_DeliveryInformationId] FOREIGN KEY([DeliveryInformationId])
REFERENCES [dbo].[DeliveryInformations] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_DeliveryInformations_DeliveryInformationId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Sizes]  WITH CHECK ADD  CONSTRAINT [FK_Sizes_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sizes] CHECK CONSTRAINT [FK_Sizes_Products_ProductId]
GO
USE [master]
GO
ALTER DATABASE [fashion-store] SET  READ_WRITE 
GO
