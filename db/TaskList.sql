USE [TasksList]
GO
/****** Object:  Table [dbo].[TaskList]    Script Date: 11/2/2021 4:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](100) NULL,
	[Day] [datetime] NULL,
	[Reminder] [bit] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_TaskList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TaskList] ON 

INSERT [dbo].[TaskList] ([Id], [Text], [Day], [Reminder], [IsRemoved]) VALUES (1, N'Doctors Appointment', CAST(N'2021-10-08T12:00:00.000' AS DateTime), 1, 0)
INSERT [dbo].[TaskList] ([Id], [Text], [Day], [Reminder], [IsRemoved]) VALUES (2, N'Meeting at School', CAST(N'2021-09-15T10:15:00.000' AS DateTime), 1, 0)
INSERT [dbo].[TaskList] ([Id], [Text], [Day], [Reminder], [IsRemoved]) VALUES (3, N'Food Shopping', CAST(N'2021-08-07T18:30:00.000' AS DateTime), 0, 1)
INSERT [dbo].[TaskList] ([Id], [Text], [Day], [Reminder], [IsRemoved]) VALUES (4, N'Golden Fish', CAST(N'2021-10-23T00:00:00.000' AS DateTime), 0, 1)
INSERT [dbo].[TaskList] ([Id], [Text], [Day], [Reminder], [IsRemoved]) VALUES (5, N'Golden Fish', CAST(N'2021-10-23T00:00:00.000' AS DateTime), 0, 1)
INSERT [dbo].[TaskList] ([Id], [Text], [Day], [Reminder], [IsRemoved]) VALUES (6, N'fsdfsdf', CAST(N'2020-10-10T00:00:00.000' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[TaskList] OFF
GO
