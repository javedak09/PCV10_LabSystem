USE [pcv13_lab]
GO
/****** Object:  Table [dbo].[audittrials]    Script Date: 12/1/2022 1:01:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[audittrials](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studyid] [int] NULL,
	[formname] [varchar](45) NULL,
	[actionperformed] [varchar](10) NULL,
	[entrydate] [date] NULL,
	[entrytime] [time](7) NULL,
	[loginusername] [varchar](15) NULL,
	[fieldname] [varchar](15) NULL,
	[oldvalue] [varchar](200) NULL,
	[newvalue] [varchar](200) NULL,
 CONSTRAINT [PK_audittrials] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dict]    Script Date: 12/1/2022 1:01:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dict](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tabname] [varchar](45) NULL,
	[var_id] [varchar](45) NULL,
	[var_seq] [int] NULL,
	[minval] [varchar](10) NULL,
	[maxval] [varchar](10) NULL,
	[value1] [varchar](4) NULL,
	[value2] [varchar](4) NULL,
	[fielddesc] [varchar](max) NULL,
 CONSTRAINT [PK_dict] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[login]    Script Date: 12/1/2022 1:01:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[login](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [varchar](15) NULL,
	[passwd] [varchar](15) NULL,
	[userstatus] [int] NULL,
	[IsUserOrAdmin] [int] NULL,
	[role] [varchar](15) NULL,
 CONSTRAINT [PK_login] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sample_entry]    Script Date: 12/1/2022 1:01:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sample_entry](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studyid] [int] NULL,
	[q1] [int] NULL,
	[q2] [varchar](45) NULL,
	[q3] [varchar](45) NULL,
	[q3a] [varchar](45) NULL,
	[q4] [int] NULL,
	[q4a] [int] NULL,
	[q5] [int] NULL,
	[q6dt] [date] NULL,
	[q6t] [time](7) NULL,
	[q7] [int] NULL,
	[q8] [int] NULL,
	[q9] [int] NULL,
	[q10dt] [date] NULL,
	[q10t] [time](7) NULL,
	[q11] [varchar](45) NULL,
	[q12] [int] NULL,
	[q13] [int] NULL,
	[q14] [int] NULL,
	[q15a1] [varchar](5) NULL,
	[q15b1] [varchar](5) NULL,
	[q15c1] [int] NULL,
	[q15a2] [varchar](5) NULL,
	[q15b2] [varchar](5) NULL,
	[q15c2] [int] NULL,
	[q15a3] [varchar](5) NULL,
	[q15b3] [varchar](5) NULL,
	[q15c3] [int] NULL,
	[q15a4] [varchar](5) NULL,
	[q15b4] [varchar](5) NULL,
	[q15c4] [int] NULL,
	[q15a5] [varchar](5) NULL,
	[q15b5] [varchar](5) NULL,
	[q15c5] [int] NULL,
	[q15a6] [varchar](5) NULL,
	[q15b6] [varchar](5) NULL,
	[q15c6] [int] NULL,
	[q15a7] [varchar](5) NULL,
	[q15b7] [varchar](5) NULL,
	[q15c7] [int] NULL,
	[q16signa1] [varchar](1) NULL,
	[q16a1] [varchar](5) NULL,
	[q16b1] [varchar](5) NULL,
	[q16c1] [int] NULL,
	[q16signa2] [varchar](1) NULL,
	[q16a2] [varchar](5) NULL,
	[q16b2] [varchar](5) NULL,
	[q16c2] [int] NULL,
	[q16signa3] [varchar](1) NULL,
	[q16a3] [varchar](5) NULL,
	[q16b3] [varchar](5) NULL,
	[q16c3] [int] NULL,
	[q16c] [int] NULL,
	[q17a1] [int] NULL,
	[q17b1] [int] NULL,
	[q17c1] [int] NULL,
	[q17a2] [int] NULL,
	[q17b2] [int] NULL,
	[q17c2] [int] NULL,
	[q17a99] [int] NULL,
	[q17b99] [int] NULL,
	[q17c3] [int] NULL,
	[q17a3] [int] NULL,
	[q17b3] [int] NULL,
	[q17c4] [int] NULL,
	[q17a4] [int] NULL,
	[q17b4] [int] NULL,
	[q17c5] [int] NULL,
	[q17a5] [int] NULL,
	[q17b5] [int] NULL,
	[q17c6] [int] NULL,
	[q17a6] [int] NULL,
	[q17b6] [int] NULL,
	[q17c7] [int] NULL,
	[q17a7] [int] NULL,
	[q17b7] [int] NULL,
	[q17c8] [int] NULL,
	[q17a8] [int] NULL,
	[q17b8] [int] NULL,
	[q17c9] [int] NULL,
	[q17a9] [int] NULL,
	[q17b9] [int] NULL,
	[q17c10] [int] NULL,
	[q17a10] [int] NULL,
	[q17b10] [int] NULL,
	[q17c11] [int] NULL,
	[q18signa1] [varchar](1) NULL,
	[q18a1] [varchar](5) NULL,
	[q18b1] [varchar](5) NULL,
	[q18c1] [int] NULL,
	[q19] [int] NULL,
	[q20] [varchar](25) NULL,
	[q21] [int] NULL,
	[q22] [int] NULL,
	[q23] [varchar](25) NULL,
	[comments] [varchar](max) NULL,
	[userid] [int] NULL,
	[entrydate] [date] NULL,
 CONSTRAINT [PK_sample_entry] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sample_recv]    Script Date: 12/1/2022 1:01:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sample_recv](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studyid] [varchar](10) NULL,
	[childid] [varchar](10) NULL,
	[dssid] [varchar](16) NULL,
	[q1] [int] NULL,
	[q2] [varchar](45) NULL,
	[q3] [varchar](45) NULL,
	[q3a] [varchar](45) NULL,
	[q4] [int] NULL,
	[q5dt] [datetime] NULL,
	[q5t] [datetime] NULL,
	[q6] [int] NULL,
	[q7] [int] NULL,
	[q8] [varchar](4) NULL,
	[q9dt] [datetime] NULL,
	[q9t] [datetime] NULL,
	[q10] [varchar](45) NULL,
	[q10a] [int] NULL,
	[q8a] [varchar](4) NULL,
	[q9dt1] [datetime] NULL,
	[q9ta] [datetime] NULL,
	[q10a1] [varchar](45) NULL,
	[q10a2] [int] NULL,
	[userid] [int] NULL,
	[entrydate] [datetime] NULL,
 CONSTRAINT [PK_sample_recv] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[login] ON 
GO
INSERT [dbo].[login] ([id], [userid], [passwd], [userstatus], [IsUserOrAdmin], [role]) VALUES (1, N'admin', N'admin123', 1, 1, N'admin')
GO
INSERT [dbo].[login] ([id], [userid], [passwd], [userstatus], [IsUserOrAdmin], [role]) VALUES (2, N'aneeta_hotwani', N'aneeta_4760', 1, 2, N'idrl')
GO
INSERT [dbo].[login] ([id], [userid], [passwd], [userstatus], [IsUserOrAdmin], [role]) VALUES (3, N'user1', N'user1', 1, 2, N'receiving')
GO
SET IDENTITY_INSERT [dbo].[login] OFF
GO
SET IDENTITY_INSERT [dbo].[sample_entry] ON 
GO
INSERT [dbo].[sample_entry] ([id], [studyid], [q1], [q2], [q3], [q3a], [q4], [q4a], [q5], [q6dt], [q6t], [q7], [q8], [q9], [q10dt], [q10t], [q11], [q12], [q13], [q14], [q15a1], [q15b1], [q15c1], [q15a2], [q15b2], [q15c2], [q15a3], [q15b3], [q15c3], [q15a4], [q15b4], [q15c4], [q15a5], [q15b5], [q15c5], [q15a6], [q15b6], [q15c6], [q15a7], [q15b7], [q15c7], [q16signa1], [q16a1], [q16b1], [q16c1], [q16signa2], [q16a2], [q16b2], [q16c2], [q16signa3], [q16a3], [q16b3], [q16c3], [q16c], [q17a1], [q17b1], [q17c1], [q17a2], [q17b2], [q17c2], [q17a99], [q17b99], [q17c3], [q17a3], [q17b3], [q17c4], [q17a4], [q17b4], [q17c5], [q17a5], [q17b5], [q17c6], [q17a6], [q17b6], [q17c7], [q17a7], [q17b7], [q17c8], [q17a8], [q17b8], [q17c9], [q17a9], [q17b9], [q17c10], [q17a10], [q17b10], [q17c11], [q18signa1], [q18a1], [q18b1], [q18c1], [q19], [q20], [q21], [q22], [q23], [comments], [userid], [entrydate]) VALUES (1, 1, 0, N'', N'', N'', 1, 1, 0, CAST(N'1900-01-01' AS Date), CAST(N'00:00:00' AS Time), 0, 0, 0, CAST(N'1900-01-01' AS Date), CAST(N'00:00:00' AS Time), N'', 1, 1, 1, N'1', N'', 2, N'2', N'', 2, N'3', N'', 2, N'4', N'', 2, N'5', N'', 2, N'6', N'', 2, N'7', N'', 2, N'1', N'1', N'', 2, N'1', N'5', N'', 2, N'3', N'8', N'', 2, 1, 1, 0, 2, 2, 0, 2, 3, 0, 2, 4, 0, 2, 5, 0, 2, 6, 0, 2, 7, 0, 2, 8, 0, 2, 9, 0, 2, 10, 0, 2, 11, 0, 2, N'3', N'3', N'', 2, 1, N'10A', 1, 1, N'10F/10C/33C', N'', 2, CAST(N'2022-12-01' AS Date))
GO
SET IDENTITY_INSERT [dbo].[sample_entry] OFF
GO
SET IDENTITY_INSERT [dbo].[sample_recv] ON 
GO
INSERT [dbo].[sample_recv] ([id], [studyid], [childid], [dssid], [q1], [q2], [q3], [q3a], [q4], [q5dt], [q5t], [q6], [q7], [q8], [q9dt], [q9t], [q10], [q10a], [q8a], [q9dt1], [q9ta], [q10a1], [q10a2], [userid], [entrydate]) VALUES (1, N'10', N'101', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[sample_recv] ([id], [studyid], [childid], [dssid], [q1], [q2], [q3], [q3a], [q4], [q5dt], [q5t], [q6], [q7], [q8], [q9dt], [q9t], [q10], [q10a], [q8a], [q9dt1], [q9ta], [q10a1], [q10a2], [userid], [entrydate]) VALUES (8, N'1', N'1', N'dss11223232', 1, N'physician name', N'mother name sadf', N'child name sadf', 1, CAST(N'2022-11-30T00:00:00.000' AS DateTime), CAST(N'1900-01-01T15:12:00.000' AS DateTime), 1, 2, N'7', CAST(N'2022-11-30T00:00:00.000' AS DateTime), CAST(N'1900-01-01T15:12:00.000' AS DateTime), N'lab mat sdfds', 1, N'6', CAST(N'2022-11-30T00:00:00.000' AS DateTime), CAST(N'1900-01-01T15:12:00.000' AS DateTime), N'khi lab sdf', 3, 3, CAST(N'2022-11-30T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[sample_recv] OFF
GO
