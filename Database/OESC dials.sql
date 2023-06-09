USE [Omega]
GO
INSERT [dbo].[Majority] ([Majority_ID], [Name]) VALUES (1, N'outside hitter')
INSERT [dbo].[Majority] ([Majority_ID], [Name]) VALUES (2, N'opposite')
INSERT [dbo].[Majority] ([Majority_ID], [Name]) VALUES (3, N'setter')
INSERT [dbo].[Majority] ([Majority_ID], [Name]) VALUES (4, N'middle blocker')
INSERT [dbo].[Majority] ([Majority_ID], [Name]) VALUES (5, N'libero')
INSERT [dbo].[Majority] ([Majority_ID], [Name]) VALUES (6, N'defensive specialist')
INSERT [dbo].[Majority] ([Majority_ID], [Name]) VALUES (7, N'serving specialist')
INSERT [dbo].[Majority] ([Majority_ID], [Name]) VALUES (8, N'not assigned')
GO
SET IDENTITY_INSERT [dbo].[TypeOfGroup] ON 

INSERT [dbo].[TypeOfGroup] ([TypeOfGroup_ID], [NameOfType]) VALUES (CAST(1 AS Numeric(28, 0)), N'prep')
INSERT [dbo].[TypeOfGroup] ([TypeOfGroup_ID], [NameOfType]) VALUES (CAST(2 AS Numeric(28, 0)), N'younger pupils')
INSERT [dbo].[TypeOfGroup] ([TypeOfGroup_ID], [NameOfType]) VALUES (CAST(3 AS Numeric(28, 0)), N'older pupils')
INSERT [dbo].[TypeOfGroup] ([TypeOfGroup_ID], [NameOfType]) VALUES (CAST(4 AS Numeric(28, 0)), N'cadets')
INSERT [dbo].[TypeOfGroup] ([TypeOfGroup_ID], [NameOfType]) VALUES (CAST(5 AS Numeric(28, 0)), N'adults')
SET IDENTITY_INSERT [dbo].[TypeOfGroup] OFF
GO
