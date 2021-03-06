USE [ConstructionManager]
GO
/****** Object:  User [conmgt]    Script Date: 8/13/2017 12:18:19 PM ******/
CREATE USER [conmgt] FOR LOGIN [conmgt] WITH DEFAULT_SCHEMA=[db_datawriter]
GO
/****** Object:  Table [dbo].[GeneralMaterials]    Script Date: 8/13/2017 12:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralMaterials](
	[MaterialID] [int] IDENTITY(1,1) NOT NULL,
	[VendorID] [int] NOT NULL,
	[MaterialProduct] [varchar](100) NOT NULL,
	[ColorLookupID] [int] NULL,
	[MaterialTypeLookupID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UomLookupID] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
(
	[MaterialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralPlans]    Script Date: 8/13/2017 12:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralPlans](
	[GenPlanID] [int] IDENTITY(1,1) NOT NULL,
	[PlanName] [varchar](50) NOT NULL,
	[ElevationLookupID] [int] NOT NULL,
	[GarageTypeLookupID] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
 CONSTRAINT [PK_GeneralPlans] PRIMARY KEY CLUSTERED 
(
	[GenPlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralPlanTasks]    Script Date: 8/13/2017 12:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralPlanTasks](
	[GenPlanTaskID] [int] IDENTITY(1,1) NOT NULL,
	[GenPlanID] [int] NOT NULL,
	[GenTaskID] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
 CONSTRAINT [PK_GeneralPlanTasks] PRIMARY KEY CLUSTERED 
(
	[GenPlanTaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralSubTasks]    Script Date: 8/13/2017 12:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralSubTasks](
	[GenSubTaskID] [int] IDENTITY(1,1) NOT NULL,
	[SubTaskName] [varchar](100) NOT NULL,
	[SubTaskDescription] [varchar](250) NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
 CONSTRAINT [PK_SubTaskTemplate] PRIMARY KEY CLUSTERED 
(
	[GenSubTaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralTaskMaterials]    Script Date: 8/13/2017 12:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralTaskMaterials](
	[GenTaskMaterialID] [int] IDENTITY(1,1) NOT NULL,
	[GenTaskID] [int] NOT NULL,
	[GenMaterialID] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
 CONSTRAINT [PK_GeneralTaskMaterials] PRIMARY KEY CLUSTERED 
(
	[GenTaskMaterialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralTaskOptions]    Script Date: 8/13/2017 12:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralTaskOptions](
	[GenTaskOptionID] [int] IDENTITY(1,1) NOT NULL,
	[GenTaskID] [int] NOT NULL,
	[GenOptionLookupID] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
 CONSTRAINT [PK_GeneralTaskOptions] PRIMARY KEY CLUSTERED 
(
	[GenTaskOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralTasks]    Script Date: 8/13/2017 12:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralTasks](
	[GenTaskID] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [varchar](100) NOT NULL,
	[TaskDescription] [varchar](250) NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TaskTemplate] PRIMARY KEY CLUSTERED 
(
	[GenTaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralTaskSubTasks]    Script Date: 8/13/2017 12:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralTaskSubTasks](
	[GenTaskSubTaskID] [int] IDENTITY(1,1) NOT NULL,
	[GenTaskID] [int] NOT NULL,
	[GenSubTaskID] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
 CONSTRAINT [PK_GeneralTaskSubTasks] PRIMARY KEY CLUSTERED 
(
	[GenTaskSubTaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lookups]    Script Date: 8/13/2017 12:18:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lookups](
	[LookupID] [int] IDENTITY(1,1) NOT NULL,
	[LookupTypeID] [int] NOT NULL,
	[LookupValue] [varchar](50) NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[LastUpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_Lookups] PRIMARY KEY CLUSTERED 
(
	[LookupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LookupTypes]    Script Date: 8/13/2017 12:18:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookupTypes](
	[LookupTypeID] [int] IDENTITY(1,1) NOT NULL,
	[LookupType] [varchar](50) NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
 CONSTRAINT [PK_LookupTypes] PRIMARY KEY CLUSTERED 
(
	[LookupTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 8/13/2017 12:18:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendors](
	[VendorID] [int] IDENTITY(1,1) NOT NULL,
	[VendorName] [varchar](50) NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED 
(
	[VendorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GeneralMaterials]  WITH CHECK ADD  CONSTRAINT [FK_GeneralMaterials_MaterialType] FOREIGN KEY([MaterialTypeLookupID])
REFERENCES [dbo].[Lookups] ([LookupID])
GO
ALTER TABLE [dbo].[GeneralMaterials] CHECK CONSTRAINT [FK_GeneralMaterials_MaterialType]
GO
ALTER TABLE [dbo].[GeneralMaterials]  WITH CHECK ADD  CONSTRAINT [FK_GeneralMaterials_UOM] FOREIGN KEY([UomLookupID])
REFERENCES [dbo].[Lookups] ([LookupID])
GO
ALTER TABLE [dbo].[GeneralMaterials] CHECK CONSTRAINT [FK_GeneralMaterials_UOM]
GO
ALTER TABLE [dbo].[GeneralMaterials]  WITH CHECK ADD  CONSTRAINT [FK_GeneralMaterials_Vendor] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendors] ([VendorID])
GO
ALTER TABLE [dbo].[GeneralMaterials] CHECK CONSTRAINT [FK_GeneralMaterials_Vendor]
GO
ALTER TABLE [dbo].[GeneralMaterials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_Colors] FOREIGN KEY([ColorLookupID])
REFERENCES [dbo].[Lookups] ([LookupID])
GO
ALTER TABLE [dbo].[GeneralMaterials] CHECK CONSTRAINT [FK_Materials_Colors]
GO
ALTER TABLE [dbo].[GeneralPlanTasks]  WITH CHECK ADD  CONSTRAINT [FK_GeneralPlanTasks_GeneralPlans] FOREIGN KEY([GenPlanID])
REFERENCES [dbo].[GeneralPlans] ([GenPlanID])
GO
ALTER TABLE [dbo].[GeneralPlanTasks] CHECK CONSTRAINT [FK_GeneralPlanTasks_GeneralPlans]
GO
ALTER TABLE [dbo].[GeneralPlanTasks]  WITH CHECK ADD  CONSTRAINT [FK_GeneralPlanTasks_GeneralTasks] FOREIGN KEY([GenTaskID])
REFERENCES [dbo].[GeneralTasks] ([GenTaskID])
GO
ALTER TABLE [dbo].[GeneralPlanTasks] CHECK CONSTRAINT [FK_GeneralPlanTasks_GeneralTasks]
GO
ALTER TABLE [dbo].[GeneralTaskMaterials]  WITH CHECK ADD  CONSTRAINT [FK_GeneralTaskMaterials_GeneralMaterials] FOREIGN KEY([GenMaterialID])
REFERENCES [dbo].[GeneralMaterials] ([MaterialID])
GO
ALTER TABLE [dbo].[GeneralTaskMaterials] CHECK CONSTRAINT [FK_GeneralTaskMaterials_GeneralMaterials]
GO
ALTER TABLE [dbo].[GeneralTaskMaterials]  WITH CHECK ADD  CONSTRAINT [FK_GeneralTaskMaterials_GeneralTasks] FOREIGN KEY([GenTaskID])
REFERENCES [dbo].[GeneralTasks] ([GenTaskID])
GO
ALTER TABLE [dbo].[GeneralTaskMaterials] CHECK CONSTRAINT [FK_GeneralTaskMaterials_GeneralTasks]
GO
ALTER TABLE [dbo].[GeneralTaskOptions]  WITH CHECK ADD  CONSTRAINT [FK_GeneralTaskOptions_GeneralTasks] FOREIGN KEY([GenTaskID])
REFERENCES [dbo].[GeneralTasks] ([GenTaskID])
GO
ALTER TABLE [dbo].[GeneralTaskOptions] CHECK CONSTRAINT [FK_GeneralTaskOptions_GeneralTasks]
GO
ALTER TABLE [dbo].[GeneralTaskOptions]  WITH CHECK ADD  CONSTRAINT [FK_GeneralTaskOptions_Options] FOREIGN KEY([GenOptionLookupID])
REFERENCES [dbo].[Lookups] ([LookupID])
GO
ALTER TABLE [dbo].[GeneralTaskOptions] CHECK CONSTRAINT [FK_GeneralTaskOptions_Options]
GO
ALTER TABLE [dbo].[GeneralTaskSubTasks]  WITH CHECK ADD  CONSTRAINT [FK_GeneralTaskSubTasks_GeneralSubTasks] FOREIGN KEY([GenSubTaskID])
REFERENCES [dbo].[GeneralSubTasks] ([GenSubTaskID])
GO
ALTER TABLE [dbo].[GeneralTaskSubTasks] CHECK CONSTRAINT [FK_GeneralTaskSubTasks_GeneralSubTasks]
GO
ALTER TABLE [dbo].[GeneralTaskSubTasks]  WITH CHECK ADD  CONSTRAINT [FK_GeneralTaskSubTasks_GeneralTasks] FOREIGN KEY([GenTaskID])
REFERENCES [dbo].[GeneralTasks] ([GenTaskID])
GO
ALTER TABLE [dbo].[GeneralTaskSubTasks] CHECK CONSTRAINT [FK_GeneralTaskSubTasks_GeneralTasks]
GO
ALTER TABLE [dbo].[Lookups]  WITH CHECK ADD  CONSTRAINT [FK_Lookups_LookupTypes] FOREIGN KEY([LookupTypeID])
REFERENCES [dbo].[LookupTypes] ([LookupTypeID])
GO
ALTER TABLE [dbo].[Lookups] CHECK CONSTRAINT [FK_Lookups_LookupTypes]
GO
