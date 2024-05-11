USE [TeknorixMockup]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11-05-2024 15:21:57 ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 11-05-2024 15:21:57 ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11-05-2024 15:21:57 ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11-05-2024 15:21:57 ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11-05-2024 15:21:57 ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11-05-2024 15:21:57 ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11-05-2024 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
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
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 11-05-2024 15:21:57 ******/
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
/****** Object:  Table [dbo].[Departments]    Script Date: 11-05-2024 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jobs]    Script Date: 11-05-2024 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jobs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code]  AS ('JOB-'+right('00'+CONVERT([varchar](2),[Id]),(2))) PERSISTED,
	[Title] [varchar](255) NULL,
	[PostedDate] [date] NULL,
	[DepartmentId] [int] NULL,
	[LocationId] [int] NULL,
	[ClosingDate] [date] NULL,
	[Description] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 11-05-2024 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[State] [varchar](255) NULL,
	[Country] [varchar](255) NULL,
	[Zip] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240511092711_initial', N'8.0.4')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5ce6f3ae-838c-46d1-b095-a10d5ddafad0', N'jovitadias09@gmail.com', N'JOVITADIAS09@GMAIL.COM', N'jovitadias09@gmail.com', N'JOVITADIAS09@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEAtv+ay5R4yqYpI3YZWlbZfq5daupT0tdWhPhIgSCYud6C5hN7z5yn3U0870FBOnWg==', N'YGKCQLQATJWON35GZJ2GF6KD2GNNXPMD', N'68cd0132-5535-4317-a6cf-d04700195d29', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 
GO
INSERT [dbo].[Departments] ([Id], [Title]) VALUES (1, N'Software Development')
GO
INSERT [dbo].[Departments] ([Id], [Title]) VALUES (2, N'Project Management')
GO
INSERT [dbo].[Departments] ([Id], [Title]) VALUES (3, N'Accounting Department')
GO
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Jobs] ON 
GO
INSERT [dbo].[Jobs] ([Id], [Title], [PostedDate], [DepartmentId], [LocationId], [ClosingDate], [Description]) VALUES (1, N'Software Development', CAST(N'2024-05-11' AS Date), 1, 2, CAST(N'2024-05-20' AS Date), N'Job Description Here')
GO
INSERT [dbo].[Jobs] ([Id], [Title], [PostedDate], [DepartmentId], [LocationId], [ClosingDate], [Description]) VALUES (2, N'Project Manager', CAST(N'2024-05-11' AS Date), 2, 1, CAST(N'2024-05-20' AS Date), N'PM Job Description Here')
GO
SET IDENTITY_INSERT [dbo].[Jobs] OFF
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 
GO
INSERT [dbo].[Locations] ([Id], [Title], [City], [State], [Country], [Zip]) VALUES (1, N'US Head Office', N'Baltimore', N'MD', N'United States', N'21202')
GO
INSERT [dbo].[Locations] ([Id], [Title], [City], [State], [Country], [Zip]) VALUES (2, N'India Office', N'Verna', N'Goa', N'India', N'403710')
GO
SET IDENTITY_INSERT [dbo].[Locations] OFF
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
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_Jobs_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [FK_Jobs_Department]
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_Jobs_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [FK_Jobs_Location]
GO
/****** Object:  StoredProcedure [dbo].[SPI_InsertDepartment]    Script Date: 11-05-2024 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPI_InsertDepartment]
    @Title NVARCHAR(255),
    @InsertedId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Departments(Title)
    VALUES (@Title);

    SET @InsertedId = SCOPE_IDENTITY();
END;
GO
/****** Object:  StoredProcedure [dbo].[SPI_InsertJob]    Script Date: 11-05-2024 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPI_InsertJob]
    @Title VARCHAR(255),
    @DepartmentId INT,
    @LocationId INT,
    @ClosingDate DATE,
	@Description VARCHAR(255),
    @InsertedId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @PostedDate DATETIME = GETDATE();

    INSERT INTO Jobs ( Title, PostedDate, DepartmentId, LocationId, ClosingDate,Description)
    VALUES ( @Title, @PostedDate, @DepartmentId, @LocationId, @ClosingDate,@Description);

    SET @InsertedId = SCOPE_IDENTITY();
END;
GO
/****** Object:  StoredProcedure [dbo].[SPI_InsertLocation]    Script Date: 11-05-2024 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPI_InsertLocation]
    @Title NVARCHAR(255),
    @City NVARCHAR(255),
    @State NVARCHAR(255),
    @Country NVARCHAR(255),
    @Zip NVARCHAR(20),
    @InsertedId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Locations (Title, City, State, Country, Zip)
    VALUES (@Title, @City, @State, @Country, @Zip);

    SET @InsertedId = SCOPE_IDENTITY();
END;
GO
/****** Object:  StoredProcedure [dbo].[SPS_GetDepartments]    Script Date: 11-05-2024 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPS_GetDepartments]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Title FROM Departments;
END;
GO
/****** Object:  StoredProcedure [dbo].[SPS_GetJobDetails]    Script Date: 11-05-2024 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPS_GetJobDetails]
    @JobId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        j.id AS JobId,
        j.code AS JobCode,
        j.title AS JobTitle,
        j.Description AS JobDescription,
        l.id AS LocationId,
        l.title AS LocationTitle,
        l.city AS LocationCity,
        l.state AS LocationState,
        l.country AS LocationCountry,
        l.zip AS LocationZip,
        d.id AS DepartmentId,
        d.title AS DepartmentTitle,
        j.postedDate AS PostedDate,
        j.closingDate AS ClosingDate
    FROM 
        jobs j
    INNER JOIN 
        locations l ON j.LocationId = l.id
    INNER JOIN 
        departments d ON j.DepartmentId = d.id
    WHERE 
        j.id = @JobId;
END;
GO
/****** Object:  StoredProcedure [dbo].[SPS_GetLocations]    Script Date: 11-05-2024 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPS_GetLocations]
AS
BEGIN
    SELECT * FROM Locations;
END;
GO
/****** Object:  StoredProcedure [dbo].[SPS_SearchJobs]    Script Date: 11-05-2024 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPS_SearchJobs]
    @SearchText VARCHAR(100),
    @LocationId INT = NULL,
    @DepartmentId INT = NULL,
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

    -- Variable to store total rows
    DECLARE @TotalRows INT;

    -- Query to get total rows
    SELECT @TotalRows = COUNT(*)
    FROM jobs j
    INNER JOIN locations l ON j.LocationId = l.id
    INNER JOIN departments d ON j.DepartmentId = d.id
    WHERE 
        (j.title LIKE '%' + @SearchText + '%' OR
         j.description LIKE '%' + @SearchText + '%' OR
         l.title LIKE '%' + @SearchText + '%' OR
         d.title LIKE '%' + @SearchText + '%')
        AND (@LocationId IS NULL OR l.id = @LocationId)
        AND (@DepartmentId IS NULL OR d.id = @DepartmentId);

    -- Query to fetch paginated results
    SELECT 
        j.id AS JobId,
        j.code AS JobCode,
        j.title AS JobTitle,
        j.description AS JobDescription,
        l.title AS LocationTitle,
        d.title AS DepartmentTitle,
        j.postedDate AS PostedDate,
        j.closingDate AS ClosingDate,
        @TotalRows AS TotalRows -- Include TotalRows in the result set
    FROM 
        jobs j
    INNER JOIN 
        locations l ON j.LocationId = l.id
    INNER JOIN 
        departments d ON j.DepartmentId = d.id
    WHERE 
        (j.title LIKE '%' + @SearchText + '%' OR
         j.description LIKE '%' + @SearchText + '%' OR
         l.title LIKE '%' + @SearchText + '%' OR
         d.title LIKE '%' + @SearchText + '%')
        AND (@LocationId IS NULL OR l.id = @LocationId)
        AND (@DepartmentId IS NULL OR d.id = @DepartmentId)
    ORDER BY
        j.id
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
END;
GO
/****** Object:  StoredProcedure [dbo].[SPU_UpdateDepartment]    Script Date: 11-05-2024 16:32:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPU_UpdateDepartment]
    @Id INT,
    @Title NVARCHAR(255) NULL,
    @RowsAffected INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Departments
    SET Title = ISNULL(@Title, Title)
    WHERE Id = @Id;

    -- Get the number of rows affected and assign it to the output parameter
    SET @RowsAffected = @@ROWCOUNT;
END;
GO
/****** Object:  StoredProcedure [dbo].[SPU_UpdateJob]    Script Date: 11-05-2024 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPU_UpdateJob]
    @Id INT,
    @Title VARCHAR(20) NULL,
    @DepartmentId INT NULL,
    @LocationId INT NULL,
    @ClosingDate DATE NULL,
	@Description VARCHAR(255) NULL,
	@RowsAffected INT OUTPUT

AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Jobs
    SET  Title = ISNULL(@Title, Title),
         DepartmentId = ISNULL(@DepartmentId, DepartmentId),
        LocationId = ISNULL(@LocationId, LocationId),
        ClosingDate = ISNULL(@ClosingDate, ClosingDate),
        Description = ISNULL(@Description, Description) 
    WHERE Id = @Id;

	-- Get the number of rows affected and assign it to the output parameter
    SET @RowsAffected = @@ROWCOUNT;
END;
GO
/****** Object:  StoredProcedure [dbo].[SPU_UpdateLocation]    Script Date: 11-05-2024 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPU_UpdateLocation]
    @Id INT,
    @Title VARCHAR(255) NULL,
    @City VARCHAR(255) NULL,
    @State VARCHAR(255) NULL,
    @Country VARCHAR(255) NULL,
    @Zip VARCHAR(20) NULL,
	@RowsAffected INT OUTPUT
AS
BEGIN
    UPDATE Locations
    SET 
        Title = ISNULL(@Title, Title),
        City = ISNULL(@City, City),
        State = ISNULL(@State, State),
        Country = ISNULL(@Country, Country),
        Zip = ISNULL(@Zip, Zip)
    WHERE Id = @Id;
	-- Get the number of rows affected and assign it to the output parameter
    SET @RowsAffected = @@ROWCOUNT;
END;
GO
