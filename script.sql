USE [WebAPP]
GO
/****** Object:  Table [dbo].[BookingEnquiry]    Script Date: 1/6/2016 10:13:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingEnquiry](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](250) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[City] [nvarchar](250) NULL,
	[Country] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Phone] [nvarchar](250) NOT NULL,
	[PackageTourId] [int] NULL,
	[PackageTourName] [nvarchar](250) NULL,
	[DepartureDate] [datetime] NULL,
	[TourClass] [int] NULL,
	[TourClassName] [nvarchar](50) NULL,
	[Adults] [int] NULL,
	[Baby0_2] [nchar](10) NULL,
	[Child2_11] [int] NULL,
	[Seniors] [int] NULL,
	[BillingOptions] [nvarchar](250) NULL,
	[AdditionalPlans] [ntext] NULL,
	[WhereHear] [nvarchar](250) NULL,
	[Remove] [bit] NULL,
 CONSTRAINT [PK_BookingEnquiry] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contact]    Script Date: 1/6/2016 10:13:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[Email] [nvarchar](250) NULL,
	[Title] [nvarchar](250) NULL,
	[Content] [nvarchar](max) NULL,
	[Remove] [bit] NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomizedTour]    Script Date: 1/6/2016 10:13:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomizedTour](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](250) NULL,
	[Gender] [nvarchar](50) NULL,
	[Email] [nvarchar](250) NULL,
	[Address] [nvarchar](max) NULL,
	[Nationality] [nvarchar](250) NULL,
	[Phone] [nvarchar](50) NULL,
	[ArrivalDate] [datetime] NULL,
	[DepartureDate] [datetime] NULL,
	[Adults] [int] NULL,
	[Child] [int] NULL,
	[Baby] [int] NULL,
	[Seniors] [int] NULL,
	[AccommodationStyle] [nvarchar](250) NULL,
	[ModesOfTransportation] [nvarchar](250) NULL,
	[PreferredType] [nvarchar](250) NULL,
	[MealsIncluded] [nvarchar](250) NULL,
	[WhereVisit] [nvarchar](250) NULL,
	[MoreMessages] [ntext] NULL,
	[Payment] [nvarchar](250) NULL,
	[WhereHear] [nvarchar](250) NULL,
	[Remove] [bit] NULL,
	[Sort] [int] NULL,
 CONSTRAINT [PK_CustomizedTour] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Label]    Script Date: 1/6/2016 10:13:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Label](
	[Label_ID] [int] IDENTITY(1,1) NOT NULL,
	[LabelKey] [nvarchar](250) NOT NULL,
	[LabelName] [nvarchar](500) NOT NULL,
	[Language_ID] [int] NOT NULL,
	[Page_ID] [int] NOT NULL,
 CONSTRAINT [PK_Label] PRIMARY KEY CLUSTERED 
(
	[Label_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Language]    Script Date: 1/6/2016 10:13:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[Language_ID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageName] [nvarchar](250) NULL,
	[LanguageCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[Language_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PackageTour]    Script Date: 1/6/2016 10:13:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageTour](
	[TourId] [int] IDENTITY(1,1) NOT NULL,
	[TourName] [nvarchar](250) NULL,
	[Duration] [nvarchar](250) NULL,
	[TourRoute] [nvarchar](250) NULL,
	[TourStyle] [int] NULL,
	[ActivityLevel] [nvarchar](250) NULL,
	[Date] [datetime] NULL,
	[SortDescription] [nvarchar](max) NULL,
	[Detail] [ntext] NULL,
	[Remove] [bit] NULL,
	[Special] [bit] NULL,
	[Image] [nvarchar](1000) NULL,
	[AgencyStandard2] [float] NULL,
	[AgencyStandard35] [float] NULL,
	[AgencyStandard69] [float] NULL,
	[AgencySuperior2] [float] NULL,
	[AgencySuperior35] [float] NULL,
	[AgencySuperior69] [float] NULL,
	[AgencyDeluxe2] [float] NULL,
	[AgencyDeluxe35] [float] NULL,
	[AgencyDeluxe69] [float] NULL,
	[Agency2Standard2] [float] NULL,
	[Agency2Standard35] [float] NULL,
	[Agency2Standard69] [float] NULL,
	[Agency2Superior2] [float] NULL,
	[Agency2Superior35] [float] NULL,
	[Agency2Superior69] [float] NULL,
	[Agency2Deluxe2] [float] NULL,
	[Agency2Deluxe35] [float] NULL,
	[Agency2Deluxe69] [float] NULL,
	[GuestStandard2] [float] NULL,
	[GuestStandard35] [float] NULL,
	[GuestStandard69] [float] NULL,
	[GuestSuperior2] [float] NULL,
	[GuestSuperior35] [float] NULL,
	[GuestSuperior69] [float] NULL,
	[GuestDeluxe2] [float] NULL,
	[GuestDeluxe35] [float] NULL,
	[GuestDeluxe69] [float] NULL,
	[Agency1SingleSupplementStandard] [float] NULL,
	[Agency1SingleSupplementSuperior] [float] NULL,
	[Agency1SingleSupplementDeluxe] [float] NULL,
	[Agency2SingleSupplementStandard] [float] NULL,
	[Agency2SingleSupplementSuperior] [float] NULL,
	[Agency2SingleSupplementDeluxe] [float] NULL,
	[GuestSingleSupplementStandard] [float] NULL,
	[GuestSingleSupplementSuperior] [float] NULL,
	[GuestSingleSupplementDeluxe] [float] NULL,
	[Sort] [int] NULL,
	[Areas] [int] NULL,
	[TitleUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_TourInfor] PRIMARY KEY CLUSTERED 
(
	[TourId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Page]    Script Date: 1/6/2016 10:13:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Page](
	[Page_ID] [int] NOT NULL,
	[PageName] [nvarchar](250) NULL,
 CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED 
(
	[Page_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reference]    Script Date: 1/6/2016 10:13:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reference](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Reference] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReferenceValue]    Script Date: 1/6/2016 10:13:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReferenceValue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceId] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ReferenceValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SelectTour]    Script Date: 1/6/2016 10:13:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SelectTour](
	[SelectTourId] [int] IDENTITY(1,1) NOT NULL,
	[TourName] [nvarchar](250) NOT NULL,
	[Style] [int] NULL,
	[Duration] [nvarchar](250) NULL,
	[TourRoute] [nvarchar](500) NULL,
	[Detail] [ntext] NULL,
	[AgencyStandard2] [float] NULL,
	[AgencyStandard35] [float] NULL,
	[AgencyStandard69] [float] NULL,
	[AgencySuperior2] [float] NULL,
	[AgencySuperior35] [float] NULL,
	[AgencySuperior69] [float] NULL,
	[AgencyDeluxe2] [float] NULL,
	[AgencyDeluxe35] [float] NULL,
	[AgencyDeluxe69] [float] NULL,
	[Agency2Standard2] [float] NULL,
	[Agency2Standard35] [float] NULL,
	[Agency2Standard69] [float] NULL,
	[Agency2Superior2] [float] NULL,
	[Agency2Superior35] [float] NULL,
	[Agency2Superior69] [float] NULL,
	[Agency2Deluxe2] [float] NULL,
	[Agency2Deluxe35] [float] NULL,
	[Agency2Deluxe69] [float] NULL,
	[GuestStandard2] [float] NULL,
	[GuestStandard35] [float] NULL,
	[GuestStandard69] [float] NULL,
	[GuestSuperior2] [float] NULL,
	[GuestSuperior35] [float] NULL,
	[GuestSuperior69] [float] NULL,
	[GuestDeluxe2] [float] NULL,
	[GuestDeluxe35] [float] NULL,
	[GuestDeluxe69] [float] NULL,
	[Remove] [bit] NULL,
	[Special] [bit] NULL,
	[Image] [nvarchar](1000) NULL,
	[SortDescription] [nvarchar](max) NULL,
	[Agency1SingleSupplementStandard] [float] NULL,
	[Agency1SingleSupplementSuperior] [float] NULL,
	[Agency1SingleSupplementDeluxe] [float] NULL,
	[Agency2SingleSupplementStandard] [float] NULL,
	[Agency2SingleSupplementSuperior] [float] NULL,
	[Agency2SingleSupplementDeluxe] [float] NULL,
	[GuestSingleSupplementStandard] [float] NULL,
	[GuestSingleSupplementSuperior] [float] NULL,
	[GuestSingleSupplementDeluxe] [float] NULL,
	[Sort] [int] NULL,
	[Areas] [int] NULL,
	[TitleUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_SelectTour] PRIMARY KEY CLUSTERED 
(
	[SelectTourId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SelectTourBooked]    Script Date: 1/6/2016 10:13:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SelectTourBooked](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Gender] [nvarchar](50) NULL,
	[Nationality] [nvarchar](250) NULL,
	[Address] [nvarchar](1000) NULL,
	[Phone] [nvarchar](50) NULL,
	[Json] [ntext] NULL,
	[Remove] [bit] NULL,
 CONSTRAINT [PK_SelectTourBooked] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slide]    Script Date: 1/6/2016 10:13:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Link] [nvarchar](max) NULL,
	[Text] [nvarchar](500) NULL,
	[Category] [int] NULL,
 CONSTRAINT [PK_Slide] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 1/6/2016 10:13:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[PassWord] [nvarchar](250) NOT NULL,
	[Lock] [bit] NULL,
	[Roles] [nvarchar](500) NULL,
	[Email] [nvarchar](250) NULL,
	[FirstName] [nvarchar](250) NULL,
	[FamilyName] [nvarchar](250) NULL,
	[CompanyName] [nvarchar](250) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Remove] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
