USE [master]
GO
/****** Object:  Database [ContratorBookingSystem]    Script Date: 5/1/2016 6:19:10 PM ******/
CREATE DATABASE [ContratorBookingSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ContratorBookingSystem', FILENAME = N'D:\SqlserverInstallation\MSSQL12.MSSQLSERVER\MSSQL\DATA\ContratorBookingSystem.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ContratorBookingSystem_log', FILENAME = N'D:\SqlserverInstallation\MSSQL12.MSSQLSERVER\MSSQL\DATA\ContratorBookingSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ContratorBookingSystem] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContratorBookingSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ContratorBookingSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ContratorBookingSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ContratorBookingSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ContratorBookingSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ContratorBookingSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [ContratorBookingSystem] SET  MULTI_USER 
GO
ALTER DATABASE [ContratorBookingSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ContratorBookingSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ContratorBookingSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ContratorBookingSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ContratorBookingSystem] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ContratorBookingSystem', N'ON'
GO
USE [ContratorBookingSystem]
GO
/****** Object:  User [excel_user]    Script Date: 5/1/2016 6:19:10 PM ******/
CREATE USER [excel_user] FOR LOGIN [excel_user] WITH DEFAULT_SCHEMA=[dbo04]
GO
/****** Object:  User [admin]    Script Date: 5/1/2016 6:19:10 PM ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [excel_users]    Script Date: 5/1/2016 6:19:10 PM ******/
CREATE ROLE [excel_users]
GO
ALTER ROLE [excel_users] ADD MEMBER [excel_user]
GO
ALTER ROLE [db_owner] ADD MEMBER [admin]
GO
/****** Object:  Schema [dbo04]    Script Date: 5/1/2016 6:19:10 PM ******/
CREATE SCHEMA [dbo04]
GO
/****** Object:  UserDefinedFunction [dbo].[UDF_GetContractSpaceUnits]    Script Date: 5/1/2016 6:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[UDF_GetContractSpaceUnits] (@GroupId uniqueidentifier)
RETURNS NVARCHAR(1000) 
AS
BEGIN
  
DECLARE @Names NVARCHAR(1000) 
SELECT  @Names = COALESCE(@Names + ' & ', '') + SpaceUnit.Name from CustomerSpaceUnit 
inner join SpaceUnit on SpaceUnit.Id = CustomerSpaceUnit.SpaceUnitId
where groupId = @GroupId --'74DB0374-6014-49EB-A7A9-06FFB4A4A415'
RETURN @Names
END

GO
/****** Object:  Table [dbo].[Building]    Script Date: 5/1/2016 6:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Building](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[ArabicName] [nvarchar](500) NULL,
 CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contract]    Script Date: 5/1/2016 6:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpaceUnitCombinedName]  AS ([dbo].[UDF_GetContractSpaceUnits]([GroupId])),
	[GroupId] [uniqueidentifier] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Amount] [numeric](18, 0) NULL,
	[Status] [nvarchar](50) NOT NULL,
	[NoOfInstallments] [numeric](18, 0) NOT NULL,
	[cr_by] [nvarchar](50) NULL,
	[cr_at] [date] NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContractPayment]    Script Date: 5/1/2016 6:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractPayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractId] [int] NOT NULL,
	[PaymentNo] [int] NOT NULL,
	[PaymentMethod] [nvarchar](50) NULL,
	[Amount] [numeric](18, 0) NULL,
	[DueDate] [date] NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Note] [nvarchar](500) NULL,
	[cr_by] [nvarchar](50) NULL,
	[cr_at] [date] NULL,
 CONSTRAINT [PK_ContractPayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/1/2016 6:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[ContactPerson] [nvarchar](50) NULL,
	[AnyDescription] [nvarchar](500) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerSpaceUnit]    Script Date: 5/1/2016 6:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerSpaceUnit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[SpaceUnitId] [int] NOT NULL,
	[GroupId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_CustomerSpaceId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SpaceUnit]    Script Date: 5/1/2016 6:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpaceUnit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuildingId] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsAvailable] [bit] NULL,
 CONSTRAINT [PK_SpaceUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Building] ON 

INSERT [dbo].[Building] ([Id], [Name], [ArabicName]) VALUES (33, N'Khamis Mugir Jabir Al Khali ( LuLu )', N'خميس مغير جابر    (لولو)')
INSERT [dbo].[Building] ([Id], [Name], [ArabicName]) VALUES (34, N'Juma Saeed Al Shamsi ( Al Sharig)', N'جمعة سعيد الشامسى')
INSERT [dbo].[Building] ([Id], [Name], [ArabicName]) VALUES (35, N'Dubai Flates And Shopes ', N'دبئىى  العقار')
SET IDENTITY_INSERT [dbo].[Building] OFF
SET IDENTITY_INSERT [dbo].[Contract] ON 

INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (97, N'780b8b5f-1831-4a6f-94a6-16559998bb04', CAST(N'2015-08-20' AS Date), CAST(N'2016-08-19' AS Date), CAST(16500 AS Numeric(18, 0)), N'Complete', CAST(2 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (98, N'dcdf65ff-dba6-4c31-ac32-ae3b45ea1c70', CAST(N'2016-02-26' AS Date), CAST(N'2017-04-20' AS Date), CAST(16000 AS Numeric(18, 0)), N'Due', CAST(3 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (99, N'044a55b3-4b9c-4997-ab63-34f48ea52207', CAST(N'2016-04-21' AS Date), CAST(N'2017-04-20' AS Date), CAST(16000 AS Numeric(18, 0)), N'Due', CAST(2 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (100, N'9f6ca843-5e6f-41d6-b6dd-f7aa9e3bbeb4', CAST(N'2016-04-21' AS Date), CAST(N'2017-04-20' AS Date), CAST(78000 AS Numeric(18, 0)), N'Due', CAST(2 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (101, N'aea8fab8-69d6-432e-bb78-e1dc59c1dc04', CAST(N'2016-04-21' AS Date), CAST(N'2017-04-20' AS Date), CAST(38000 AS Numeric(18, 0)), N'Due', CAST(2 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (102, N'840ec023-5e4f-4533-bc1d-e6589783ee5a', CAST(N'2016-04-21' AS Date), CAST(N'2017-04-20' AS Date), CAST(46000 AS Numeric(18, 0)), N'Due', CAST(4 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (103, N'95559788-0208-4c3c-a59a-a0f5295756cb', CAST(N'2016-04-21' AS Date), CAST(N'2017-04-20' AS Date), CAST(55000 AS Numeric(18, 0)), N'Complete', CAST(4 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (104, N'f13a7b15-e5a9-4af4-a388-e42b9d5368fe', CAST(N'2016-04-21' AS Date), CAST(N'2017-04-20' AS Date), CAST(46000 AS Numeric(18, 0)), N'Due', CAST(4 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (105, N'e6100d2a-d7d8-4361-a50f-6a110b723618', CAST(N'2016-04-21' AS Date), CAST(N'2017-04-20' AS Date), CAST(35000 AS Numeric(18, 0)), N'Due', CAST(4 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (106, N'26ae9e4e-7acb-487b-9f2b-70a9dd006a41', CAST(N'2016-04-22' AS Date), CAST(N'2017-04-21' AS Date), CAST(78000 AS Numeric(18, 0)), N'Due', CAST(1 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (107, N'74324986-0e7d-4134-8e1e-aa843f794249', CAST(N'2016-08-19' AS Date), CAST(N'2017-08-19' AS Date), CAST(20500 AS Numeric(18, 0)), N'Due', CAST(6 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (108, N'a24807c6-1574-417e-8040-ba9e4b02dfa6', CAST(N'2016-08-19' AS Date), CAST(N'2017-08-19' AS Date), CAST(16600 AS Numeric(18, 0)), N'Due', CAST(5 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (109, N'2f0b9a32-4404-445e-b2b8-436df95917b2', CAST(N'2016-08-19' AS Date), CAST(N'2017-08-19' AS Date), CAST(16500 AS Numeric(18, 0)), N'Due', CAST(3 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (110, N'05a639c1-a8bb-4b05-92d6-86ea69f6d4d4', CAST(N'2016-08-20' AS Date), CAST(N'2017-08-19' AS Date), CAST(16500 AS Numeric(18, 0)), N'Due', CAST(2 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (111, N'4dffd761-a292-4651-aa88-b1eaf6899c08', CAST(N'2017-08-20' AS Date), CAST(N'2018-08-19' AS Date), CAST(16500 AS Numeric(18, 0)), N'Due', CAST(2 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (112, N'780b8b5f-1831-4a6f-94a6-16559998bb04', CAST(N'2016-08-20' AS Date), CAST(N'2017-08-19' AS Date), CAST(16500 AS Numeric(18, 0)), N'Due', CAST(2 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (113, N'17f88452-eb21-4ec6-af2a-9310a8046aaa', CAST(N'2016-08-20' AS Date), CAST(N'2017-08-19' AS Date), CAST(16500 AS Numeric(18, 0)), N'Complete', CAST(4 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (114, N'31ea14e1-a60b-4f8b-8c43-0b7ad2b91dfa', CAST(N'2017-04-21' AS Date), CAST(N'2018-04-20' AS Date), CAST(55000 AS Numeric(18, 0)), N'Due', CAST(4 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (115, N'45241a50-9d10-4fe8-82d9-f06167142ae0', CAST(N'2017-08-20' AS Date), CAST(N'2018-08-19' AS Date), CAST(16500 AS Numeric(18, 0)), N'Due', CAST(4 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (116, N'1b628ece-9739-41f2-bade-fc491552346a', CAST(N'2017-08-20' AS Date), CAST(N'2018-08-19' AS Date), CAST(16500 AS Numeric(18, 0)), N'Due', CAST(4 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[Contract] ([Id], [GroupId], [StartDate], [EndDate], [Amount], [Status], [NoOfInstallments], [cr_by], [cr_at]) VALUES (117, N'942d6e00-b0bf-475a-ada1-b2b441a2be94', CAST(N'2017-08-20' AS Date), CAST(N'2018-08-19' AS Date), CAST(16500 AS Numeric(18, 0)), N'Due', CAST(10 AS Numeric(18, 0)), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Contract] OFF
SET IDENTITY_INSERT [dbo].[ContractPayment] ON 

INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (419, 97, 1, N'Cheque', CAST(16000 AS Numeric(18, 0)), CAST(N'2015-08-20' AS Date), N'Complete', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (420, 97, 2, N'Cheque', CAST(500 AS Numeric(18, 0)), CAST(N'2016-08-19' AS Date), N'Complete', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (421, 98, 1, N'Cheque', CAST(8000 AS Numeric(18, 0)), CAST(N'2016-02-26' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (422, 98, 2, N'Cheque', CAST(8000 AS Numeric(18, 0)), CAST(N'2017-04-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (423, 99, 1, N'Cheque', CAST(8000 AS Numeric(18, 0)), CAST(N'2016-04-21' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (424, 99, 2, N'Cheque', CAST(8000 AS Numeric(18, 0)), CAST(N'2017-04-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (425, 100, 1, N'Cheque', CAST(39000 AS Numeric(18, 0)), CAST(N'2016-04-21' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (426, 100, 2, N'Cheque', CAST(39000 AS Numeric(18, 0)), CAST(N'2017-04-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (427, 101, 1, N'Cheque', CAST(19000 AS Numeric(18, 0)), CAST(N'2016-04-21' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (428, 101, 2, N'Cheque', CAST(19000 AS Numeric(18, 0)), CAST(N'2017-04-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (429, 102, 1, N'Cheque', CAST(11500 AS Numeric(18, 0)), CAST(N'2016-04-21' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (430, 102, 2, N'Cheque', CAST(11500 AS Numeric(18, 0)), CAST(N'2016-07-21' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (431, 102, 3, N'Cheque', CAST(11500 AS Numeric(18, 0)), CAST(N'2016-10-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (432, 102, 4, N'Cheque', CAST(11500 AS Numeric(18, 0)), CAST(N'2017-04-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (433, 103, 1, N'Cheque', CAST(13750 AS Numeric(18, 0)), CAST(N'2016-04-21' AS Date), N'Complete', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (434, 103, 2, N'Cheque', CAST(13750 AS Numeric(18, 0)), CAST(N'2016-07-21' AS Date), N'Complete', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (435, 103, 3, N'Cheque', CAST(13750 AS Numeric(18, 0)), CAST(N'2016-10-20' AS Date), N'Complete', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (436, 103, 4, N'Cheque', CAST(13750 AS Numeric(18, 0)), CAST(N'2017-04-20' AS Date), N'Complete', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (437, 104, 1, N'Cheque', CAST(11500 AS Numeric(18, 0)), CAST(N'2016-04-21' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (438, 104, 2, N'Cheque', CAST(11500 AS Numeric(18, 0)), CAST(N'2016-07-21' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (439, 104, 3, N'Cheque', CAST(11500 AS Numeric(18, 0)), CAST(N'2016-10-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (440, 104, 4, N'Cheque', CAST(11500 AS Numeric(18, 0)), CAST(N'2017-04-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (441, 105, 1, N'Cheque', CAST(8750 AS Numeric(18, 0)), CAST(N'2016-04-21' AS Date), N'Complete', N's\cxsa
c
zsc
zxcxczxcascscas', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (442, 105, 2, N'Cheque', CAST(8750 AS Numeric(18, 0)), CAST(N'2016-07-21' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (443, 105, 3, N'Cheque', CAST(8750 AS Numeric(18, 0)), CAST(N'2016-10-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (444, 105, 4, N'Cheque', CAST(8750 AS Numeric(18, 0)), CAST(N'2017-04-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (445, 106, 1, N'Cheque', CAST(78000 AS Numeric(18, 0)), CAST(N'2017-04-21' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (446, 107, 1, N'Cash', CAST(8250 AS Numeric(18, 0)), CAST(N'2016-08-19' AS Date), N'Due', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (447, 107, 2, N'Cheque', CAST(8250 AS Numeric(18, 0)), CAST(N'2017-08-19' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (448, 107, 3, N'Cheque', CAST(1000 AS Numeric(18, 0)), CAST(N'2016-04-22' AS Date), N'Complete', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (449, 98, 3, N'Cheque', CAST(1000 AS Numeric(18, 0)), CAST(N'2016-04-22' AS Date), N'Due', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (450, 107, 4, N'Cheque', CAST(400 AS Numeric(18, 0)), CAST(N'2016-04-23' AS Date), N'Due', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (451, 108, 1, N'Cheque', CAST(8250 AS Numeric(18, 0)), CAST(N'2016-08-19' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (452, 108, 2, N'Cheque', CAST(8250 AS Numeric(18, 0)), CAST(N'2017-08-19' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (453, 108, 3, N'Cheque', CAST(20 AS Numeric(18, 0)), CAST(N'2016-04-23' AS Date), N'Due', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (454, 108, 4, N'Cheque', CAST(5555 AS Numeric(18, 0)), CAST(N'2016-04-23' AS Date), N'Due', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (455, 107, 5, N'Cheque', CAST(2 AS Numeric(18, 0)), CAST(N'2016-04-23' AS Date), N'Due', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (456, 109, 1, N'Cheque', CAST(8250 AS Numeric(18, 0)), CAST(N'2016-08-19' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (457, 109, 2, N'Cheque', CAST(8250 AS Numeric(18, 0)), CAST(N'2017-08-19' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (458, 109, 3, N'Cheque', CAST(3 AS Numeric(18, 0)), CAST(N'2016-04-23' AS Date), N'Due', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (459, 110, 1, N'Cheque', CAST(8250 AS Numeric(18, 0)), CAST(N'2016-08-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (460, 110, 2, N'Cheque', CAST(8250 AS Numeric(18, 0)), CAST(N'2017-08-19' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (461, 111, 1, N'Cheque', CAST(8250 AS Numeric(18, 0)), CAST(N'2017-08-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (462, 111, 2, N'Cheque', CAST(8250 AS Numeric(18, 0)), CAST(N'2018-08-19' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (463, 112, 1, N'Cheque', CAST(8250 AS Numeric(18, 0)), CAST(N'2016-08-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (464, 112, 2, N'Cheque', CAST(8250 AS Numeric(18, 0)), CAST(N'2017-08-19' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (465, 113, 1, N'Cheque', CAST(0 AS Numeric(18, 0)), CAST(N'2016-08-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (466, 113, 2, N'Cheque', CAST(0 AS Numeric(18, 0)), CAST(N'2017-08-19' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (467, 113, 3, N'Cheque', CAST(0 AS Numeric(18, 0)), CAST(N'2016-04-23' AS Date), N'Due', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (468, 113, 4, N'Cheque', CAST(58888 AS Numeric(18, 0)), CAST(N'2016-04-23' AS Date), N'Complete', N'', NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (469, 114, 1, N'Cheque', CAST(13750 AS Numeric(18, 0)), CAST(N'2017-04-21' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (470, 114, 2, N'Cheque', CAST(13750 AS Numeric(18, 0)), CAST(N'2017-07-21' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (471, 114, 3, N'Cheque', CAST(13750 AS Numeric(18, 0)), CAST(N'2017-10-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (472, 114, 4, N'Cheque', CAST(13750 AS Numeric(18, 0)), CAST(N'2018-04-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (473, 115, 1, N'Cheque', CAST(4125 AS Numeric(18, 0)), CAST(N'2017-08-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (474, 115, 2, N'Cheque', CAST(4125 AS Numeric(18, 0)), CAST(N'2017-11-19' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (475, 115, 3, N'Cheque', CAST(4125 AS Numeric(18, 0)), CAST(N'2018-02-18' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (476, 115, 4, N'Cheque', CAST(4125 AS Numeric(18, 0)), CAST(N'2018-08-19' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (477, 116, 1, N'Cheque', CAST(4125 AS Numeric(18, 0)), CAST(N'2017-08-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (478, 116, 2, N'Cheque', CAST(4125 AS Numeric(18, 0)), CAST(N'2017-11-19' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (479, 116, 3, N'Cheque', CAST(4125 AS Numeric(18, 0)), CAST(N'2018-02-18' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (480, 116, 4, N'Cheque', CAST(4125 AS Numeric(18, 0)), CAST(N'2018-08-19' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (481, 117, 1, N'Cheque', CAST(1650 AS Numeric(18, 0)), CAST(N'2017-08-20' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (482, 117, 2, N'Cheque', CAST(1650 AS Numeric(18, 0)), CAST(N'2017-09-25' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (483, 117, 3, N'Cheque', CAST(1650 AS Numeric(18, 0)), CAST(N'2017-10-31' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (484, 117, 4, N'Cheque', CAST(1650 AS Numeric(18, 0)), CAST(N'2017-12-06' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (485, 117, 5, N'Cheque', CAST(1650 AS Numeric(18, 0)), CAST(N'2018-01-11' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (486, 117, 6, N'Cheque', CAST(1650 AS Numeric(18, 0)), CAST(N'2018-02-16' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (487, 117, 7, N'Cheque', CAST(1650 AS Numeric(18, 0)), CAST(N'2018-03-24' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (488, 117, 8, N'Cheque', CAST(1650 AS Numeric(18, 0)), CAST(N'2018-04-29' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (489, 117, 9, N'Cheque', CAST(1650 AS Numeric(18, 0)), CAST(N'2018-06-04' AS Date), N'Due', NULL, NULL, NULL)
INSERT [dbo].[ContractPayment] ([Id], [ContractId], [PaymentNo], [PaymentMethod], [Amount], [DueDate], [Status], [Note], [cr_by], [cr_at]) VALUES (490, 117, 10, N'Cheque', CAST(1650 AS Numeric(18, 0)), CAST(N'2018-08-19' AS Date), N'Due', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ContractPayment] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name], [ContactNumber], [ContactPerson], [AnyDescription]) VALUES (26, N'Al Raha & Al Taqwa', N'055-8409821', N'', N'')
INSERT [dbo].[Customer] ([Id], [Name], [ContactNumber], [ContactPerson], [AnyDescription]) VALUES (27, N'Sama Mazed Plaster', N'055-5106283', N'', N'')
INSERT [dbo].[Customer] ([Id], [Name], [ContactNumber], [ContactPerson], [AnyDescription]) VALUES (28, N'Najam Al Sama Plaster', N'055-5106283', N'', N'')
INSERT [dbo].[Customer] ([Id], [Name], [ContactNumber], [ContactPerson], [AnyDescription]) VALUES (29, N'Ahmed (Twam Hospital )', N'050-4928521', N'', N'')
INSERT [dbo].[Customer] ([Id], [Name], [ContactNumber], [ContactPerson], [AnyDescription]) VALUES (30, N'Ibrahim Hassan', N'050-9700350', N'', N'')
INSERT [dbo].[Customer] ([Id], [Name], [ContactNumber], [ContactPerson], [AnyDescription]) VALUES (31, N'Ekaterina Tishchenko', N'6666666666666', N'', N'')
INSERT [dbo].[Customer] ([Id], [Name], [ContactNumber], [ContactPerson], [AnyDescription]) VALUES (32, N'Pakistan Consulate', N'6666666666', N'', N'')
INSERT [dbo].[Customer] ([Id], [Name], [ContactNumber], [ContactPerson], [AnyDescription]) VALUES (33, N'Sundar ', N'666666666666', N'', N'')
INSERT [dbo].[Customer] ([Id], [Name], [ContactNumber], [ContactPerson], [AnyDescription]) VALUES (34, N'Ghani Bashir', N'', N'', N'')
INSERT [dbo].[Customer] ([Id], [Name], [ContactNumber], [ContactPerson], [AnyDescription]) VALUES (35, N'Institude Of Applied Technology', N'123456', N'', N'')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[CustomerSpaceUnit] ON 

INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (260, 26, 45, N'780b8b5f-1831-4a6f-94a6-16559998bb04')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (261, 27, 46, N'dcdf65ff-dba6-4c31-ac32-ae3b45ea1c70')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (262, 28, 47, N'044a55b3-4b9c-4997-ab63-34f48ea52207')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (263, 29, 52, N'9f6ca843-5e6f-41d6-b6dd-f7aa9e3bbeb4')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (264, 29, 53, N'9f6ca843-5e6f-41d6-b6dd-f7aa9e3bbeb4')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (265, 30, 54, N'aea8fab8-69d6-432e-bb78-e1dc59c1dc04')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (266, 31, 55, N'840ec023-5e4f-4533-bc1d-e6589783ee5a')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (267, 32, 55, N'95559788-0208-4c3c-a59a-a0f5295756cb')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (268, 33, 55, N'f13a7b15-e5a9-4af4-a388-e42b9d5368fe')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (269, 34, 57, N'e6100d2a-d7d8-4361-a50f-6a110b723618')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (270, 35, 54, N'26ae9e4e-7acb-487b-9f2b-70a9dd006a41')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (273, 26, 45, N'74324986-0e7d-4134-8e1e-aa843f794249')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (277, 26, 45, N'2f0b9a32-4404-445e-b2b8-436df95917b2')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (278, 26, 45, N'05a639c1-a8bb-4b05-92d6-86ea69f6d4d4')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (279, 26, 45, N'4dffd761-a292-4651-aa88-b1eaf6899c08')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (281, 26, 45, N'a24807c6-1574-417e-8040-ba9e4b02dfa6')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (282, 26, 45, N'780b8b5f-1831-4a6f-94a6-16559998bb04')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (283, 26, 45, N'17f88452-eb21-4ec6-af2a-9310a8046aaa')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (284, 32, 55, N'31ea14e1-a60b-4f8b-8c43-0b7ad2b91dfa')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (285, 26, 45, N'45241a50-9d10-4fe8-82d9-f06167142ae0')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (286, 26, 45, N'1b628ece-9739-41f2-bade-fc491552346a')
INSERT [dbo].[CustomerSpaceUnit] ([Id], [CustomerId], [SpaceUnitId], [GroupId]) VALUES (287, 26, 45, N'942d6e00-b0bf-475a-ada1-b2b441a2be94')
SET IDENTITY_INSERT [dbo].[CustomerSpaceUnit] OFF
SET IDENTITY_INSERT [dbo].[SpaceUnit] ON 

INSERT [dbo].[SpaceUnit] ([Id], [BuildingId], [Name], [IsAvailable]) VALUES (45, 33, N'Office N0 4', NULL)
INSERT [dbo].[SpaceUnit] ([Id], [BuildingId], [Name], [IsAvailable]) VALUES (46, 33, N'Office N0 5', NULL)
INSERT [dbo].[SpaceUnit] ([Id], [BuildingId], [Name], [IsAvailable]) VALUES (47, 33, N'Office N0 6', NULL)
INSERT [dbo].[SpaceUnit] ([Id], [BuildingId], [Name], [IsAvailable]) VALUES (48, 33, N'Shop No 1', NULL)
INSERT [dbo].[SpaceUnit] ([Id], [BuildingId], [Name], [IsAvailable]) VALUES (49, 33, N'Shop No 2', NULL)
INSERT [dbo].[SpaceUnit] ([Id], [BuildingId], [Name], [IsAvailable]) VALUES (50, 33, N'Shop No 3', NULL)
INSERT [dbo].[SpaceUnit] ([Id], [BuildingId], [Name], [IsAvailable]) VALUES (51, 33, N'Grague No 1', NULL)
INSERT [dbo].[SpaceUnit] ([Id], [BuildingId], [Name], [IsAvailable]) VALUES (52, 34, N'Flat 1', NULL)
INSERT [dbo].[SpaceUnit] ([Id], [BuildingId], [Name], [IsAvailable]) VALUES (53, 34, N'Flat 2', NULL)
INSERT [dbo].[SpaceUnit] ([Id], [BuildingId], [Name], [IsAvailable]) VALUES (54, 34, N'Flat 3', NULL)
INSERT [dbo].[SpaceUnit] ([Id], [BuildingId], [Name], [IsAvailable]) VALUES (55, 35, N'Flate Dubai', NULL)
INSERT [dbo].[SpaceUnit] ([Id], [BuildingId], [Name], [IsAvailable]) VALUES (57, 35, N'Shop Dubai', NULL)
SET IDENTITY_INSERT [dbo].[SpaceUnit] OFF
ALTER TABLE [dbo].[ContractPayment]  WITH CHECK ADD  CONSTRAINT [FK_ContractPayment_Contract] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contract] ([Id])
GO
ALTER TABLE [dbo].[ContractPayment] CHECK CONSTRAINT [FK_ContractPayment_Contract]
GO
ALTER TABLE [dbo].[CustomerSpaceUnit]  WITH CHECK ADD  CONSTRAINT [FK_CustomerSpaceUnit_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[CustomerSpaceUnit] CHECK CONSTRAINT [FK_CustomerSpaceUnit_Customer]
GO
ALTER TABLE [dbo].[CustomerSpaceUnit]  WITH CHECK ADD  CONSTRAINT [FK_CustomerSpaceUnit_SpaceUnit] FOREIGN KEY([SpaceUnitId])
REFERENCES [dbo].[SpaceUnit] ([Id])
GO
ALTER TABLE [dbo].[CustomerSpaceUnit] CHECK CONSTRAINT [FK_CustomerSpaceUnit_SpaceUnit]
GO
ALTER TABLE [dbo].[SpaceUnit]  WITH CHECK ADD  CONSTRAINT [FK_SpaceUnit_Building] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Building] ([Id])
GO
ALTER TABLE [dbo].[SpaceUnit] CHECK CONSTRAINT [FK_SpaceUnit_Building]
GO
/****** Object:  StoredProcedure [dbo04].[uspExcelTest]    Script Date: 5/1/2016 6:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      Sergey Vaselenko
-- Create date: 2011-06-07
-- Description: Select from ExcelTest table as procedure
-- =============================================

CREATE PROCEDURE [dbo04].[uspExcelTest]
AS
BEGIN
    
    SET NOCOUNT ON

    SELECT
        [ID]
        , [Float]
        , [Datetime]
        , [Nvarchar]
    FROM
        [dbo04].[ExcelTest]

END

SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo04].[uspExportExcelTestCSV]    Script Date: 5/1/2016 6:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      Sergey Vaselenko
-- Create date: 2011-06-02
-- Description: Export CSV file example
-- =============================================

CREATE PROCEDURE [dbo04].[uspExportExcelTestCSV]
AS
BEGIN
    
    SET NOCOUNT ON

    SELECT
        [ID] AS [Id]
        , ISNULL([Float], '') AS [Float]
        , ISNULL(CONVERT(varchar(19), [Datetime], 120), '') AS [Datetime]
        , ISNULL(QUOTENAME([Nvarchar], '"'), '') AS [Nvarchar]
    FROM
        [dbo04].[ExcelTest]

END

SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo04].[uspImportExcel_After]    Script Date: 5/1/2016 6:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      Sergey Vaselenko
-- Create date: 2011-06-07
-- Description: Excel Import Finalization
--
-- Import table contains additional ImportID identity field.
-- So, ID in data imported from Excel can be duplicated.
-- Second and higher duplicated IDs get new values.
-- =============================================

CREATE PROCEDURE [dbo04].[uspImportExcel_After]
    WITH EXECUTE AS SELF
AS
BEGIN
    
    SET NOCOUNT ON

    -- Delete source rows if ID not found in import data

    DELETE dbo04.ExcelTest
    FROM
        dbo04.ExcelTest et
        LEFT OUTER JOIN dbo04.ExcelTestImport i ON et.ID = i.ID
    WHERE
        i.ID IS NULL

    -- Set ID = 0 to NULL to get a regular ID

    UPDATE dbo04.ExcelTestImport
    SET
        ID = NULL
    WHERE
        ID = 0
    
    -- Set non-first IDs in import data to NULL

    UPDATE dbo04.ExcelTestImport
    SET
        ID = NULL
    FROM
        dbo04.ExcelTestImport i
        INNER JOIN (
            SELECT ImportID, ID, ROW_NUMBER() OVER(PARTITION BY ID ORDER BY ImportID) AS Row
            FROM dbo04.ExcelTestImport
        ) r ON r.ImportID = i.ImportID
    WHERE
        r.Row > 1
        AND i.ID IS NOT NULL

    -- Update source data from import data

    UPDATE dbo04.ExcelTest
    SET
        [Float] = i.[Float]
        , [Datetime] = i.[Datetime]
        , [Nvarchar] = i.[Nvarchar]
    FROM
        dbo04.ExcelTest et
        INNER JOIN dbo04.ExcelTestImport i ON et.ID = i.ID


    -- Insert new data with filled ID

    SET IDENTITY_INSERT dbo04.ExcelTest ON

    INSERT dbo04.ExcelTest
        ([ID], [Float], [Datetime], [Nvarchar])
    SELECT
        i.[ID], i.[Float], i.[Datetime], i.[Nvarchar]
    FROM
        dbo04.ExcelTest et
        RIGHT OUTER JOIN dbo04.ExcelTestImport i ON et.ID = i.ID
    WHERE
        et.ID IS NULL
        AND i.ID IS NOT NULL

    SET IDENTITY_INSERT dbo04.ExcelTest OFF

    -- Insert new data with empty ID (as in import or as duplicated ID)

    INSERT dbo04.ExcelTest
        ([Float], [Datetime], [Nvarchar])
    SELECT
        i.[Float], i.[Datetime], i.[Nvarchar]
    FROM
        dbo04.ExcelTestImport i
    WHERE
        i.ID IS NULL

END


GO
/****** Object:  StoredProcedure [dbo04].[uspImportExcel_Before]    Script Date: 5/1/2016 6:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      Sergey Vaselenko
-- Create date: 2011-06-07
-- Description: Excel Import Initialization
-- =============================================

CREATE PROCEDURE [dbo04].[uspImportExcel_Before]
    WITH EXECUTE AS SELF
AS
BEGIN
    
    SET NOCOUNT ON

    DELETE dbo04.ExcelTestImport

    -- The command is not available in SQL Azure
    -- DBCC CHECKIDENT ("dbo04.ExcelTestImport", RESEED, 0)

END

GO
USE [master]
GO
ALTER DATABASE [ContratorBookingSystem] SET  READ_WRITE 
GO
