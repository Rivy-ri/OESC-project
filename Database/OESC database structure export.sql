/****** Cannot script Unresolved Entities : Server[@Name='DESKTOP-MDFHE25\SQLEXPRESS']/Database[@Name='OESC']/UnresolvedEntity[@Name='inserted'] ******/
GO
USE [OESC]
GO
/****** Object:  Table [dbo].[Coach]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coach](
	[Coach_ID] [numeric](28, 0) IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Surname] [varchar](30) NOT NULL,
	[E-mail] [varchar](50) NOT NULL,
	[Phone] [varchar](30) NULL,
 CONSTRAINT [Omega_Coach_PK] PRIMARY KEY CLUSTERED 
(
	[Coach_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uniquecombinationCoach] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[Surname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainingGroup]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainingGroup](
	[TrainingGroup_ID] [numeric](28, 0) IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Coach_Coach_ID] [numeric](28, 0) NOT NULL,
	[Type_of_group_Type_of_group_ID] [numeric](28, 0) NOT NULL,
	[Name] [varchar](30) NULL,
 CONSTRAINT [Omega_Training_group_PK] PRIMARY KEY CLUSTERED 
(
	[TrainingGroup_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Coach_Coach_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfGroup]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfGroup](
	[TypeOfGroup_ID] [numeric](28, 0) IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[NameOfType] [varchar](20) NULL,
 CONSTRAINT [Omega_Type_of_group_PK] PRIMARY KEY CLUSTERED 
(
	[TypeOfGroup_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[OV_Joined_TG]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[OV_Joined_TG] as Select Coach.Name as coach_name,Coach.Surname,[TypeOfGroup].[NameOfType], [TrainingGroup].Name From [TrainingGroup] 
INNER JOIN Coach on [TrainingGroup].Coach_Coach_ID=Coach.Coach_ID
INNER JOIN [TypeOfGroup] on [TrainingGroup].Type_of_group_Type_of_group_ID=[TypeOfGroup].[TypeOfGroup_ID];
GO
/****** Object:  View [dbo].[CoachView]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create VIEW [dbo].[CoachView] as SELECT Coach.Name,Coach.Surname,Coach.[E-mail],Coach.Phone FROM Coach order by Coach.Name offset 0 rows;
GO
/****** Object:  Table [dbo].[Player]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[Player_ID] [numeric](28, 0) IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Tg_TrainingGroup_ID] [numeric](28, 0) NOT NULL,
	[Card_Card_Id] [int] NULL,
	[Name] [varchar](30) NOT NULL,
	[Surname] [varchar](30) NOT NULL,
	[Majority_ID] [int] NOT NULL,
	[Age] [int] NULL,
	[Phone] [varchar](50) NULL,
	[FK_parent] [numeric](28, 0) NULL,
	[BirthDate] [date] NULL,
	[E-mail] [varchar](30) NULL,
 CONSTRAINT [Omega_Players_PK] PRIMARY KEY CLUSTERED 
(
	[Player_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uniquecombination] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[Surname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GroupView]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[GroupView] as
SELECT [TrainingGroup].[Name], [NameOfType], [Coach].[Name]+' '+[Coach].[Surname] as Coach, COUNT([Player_ID]) as [number of players in group]
FROM [TrainingGroup]
INNER JOIN [dbo].[TypeOfGroup] ON [TypeOfGroup].TypeOfGroup_ID=[dbo].[TrainingGroup].[Type_of_group_Type_of_group_ID]
INNER JOIN [dbo].[Coach] ON [dbo].[TrainingGroup].[Coach_Coach_ID]= [dbo].[Coach].Coach_ID
LEFT JOIN [dbo].[Player] ON [TrainingGroup].TrainingGroup_ID =Player.[Tg_TrainingGroup_ID]
GROUP BY [TrainingGroup].[Name], [TypeOfGroup].NameOfType, [Coach].[Name], [Coach].[Surname];
GO
/****** Object:  Table [dbo].[AplicationUser]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AplicationUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NULL,
	[verification_code] [varchar](6) NULL,
	[email] [varchar](100) NULL,
	[salt] [varchar](60) NULL,
	[hash] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Card](
	[CardNumber] [int] NULL,
	[ExpirationDate] [date] NOT NULL,
	[Card_ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Card_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CardNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Majority]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Majority](
	[Majority_ID] [int] NOT NULL,
	[Name] [varchar](20) NULL,
 CONSTRAINT [Majority_PK] PRIMARY KEY CLUSTERED 
(
	[Majority_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Match_stat]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match_stat](
	[Team_Team_ID] [numeric](28, 0) NOT NULL,
	[Oponent] [varchar](50) NULL,
	[Match_stat_ID] [int] IDENTITY(1,1) NOT NULL,
	[Notes] [varchar](150) NULL,
	[VictoryOfOurTeam] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Match_stat_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parent]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parent](
	[Parent_ID] [numeric](28, 0) IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Surname] [varchar](30) NOT NULL,
	[PhoneNumber] [varchar](16) NOT NULL,
	[E-mail] [varchar](30) NULL,
 CONSTRAINT [Omega_Parent_PK] PRIMARY KEY CLUSTERED 
(
	[Parent_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uniquecombinationparent] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[Surname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player/Team]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player/Team](
	[Player_Player_ID] [numeric](28, 0) NOT NULL,
	[Team_Team_ID] [numeric](28, 0) NOT NULL,
	[Player/Team_ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Player/Team_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[Team_ID] [numeric](28, 0) IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [Omega_Team_PK] PRIMARY KEY CLUSTERED 
(
	[Team_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Match_stat]  WITH CHECK ADD  CONSTRAINT [Match_stat_Team_FK] FOREIGN KEY([Team_Team_ID])
REFERENCES [dbo].[Team] ([Team_ID])
GO
ALTER TABLE [dbo].[Match_stat] CHECK CONSTRAINT [Match_stat_Team_FK]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD FOREIGN KEY([Card_Card_Id])
REFERENCES [dbo].[Card] ([Card_ID])
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Parent] FOREIGN KEY([Tg_TrainingGroup_ID])
REFERENCES [dbo].[TrainingGroup] ([TrainingGroup_ID])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Parent]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [Parent_parent] FOREIGN KEY([FK_parent])
REFERENCES [dbo].[Parent] ([Parent_ID])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [Parent_parent]
GO
ALTER TABLE [dbo].[Player/Team]  WITH CHECK ADD  CONSTRAINT [Relation_4_Players_FK] FOREIGN KEY([Player_Player_ID])
REFERENCES [dbo].[Player] ([Player_ID])
GO
ALTER TABLE [dbo].[Player/Team] CHECK CONSTRAINT [Relation_4_Players_FK]
GO
ALTER TABLE [dbo].[Player/Team]  WITH CHECK ADD  CONSTRAINT [Relation_4_Team_FK] FOREIGN KEY([Team_Team_ID])
REFERENCES [dbo].[Team] ([Team_ID])
GO
ALTER TABLE [dbo].[Player/Team] CHECK CONSTRAINT [Relation_4_Team_FK]
GO
ALTER TABLE [dbo].[TrainingGroup]  WITH CHECK ADD  CONSTRAINT [FK_TG] FOREIGN KEY([Type_of_group_Type_of_group_ID])
REFERENCES [dbo].[TypeOfGroup] ([TypeOfGroup_ID])
GO
ALTER TABLE [dbo].[TrainingGroup] CHECK CONSTRAINT [FK_TG]
GO
ALTER TABLE [dbo].[TrainingGroup]  WITH NOCHECK ADD  CONSTRAINT [Training_group_Coach_FK] FOREIGN KEY([Coach_Coach_ID])
REFERENCES [dbo].[Coach] ([Coach_ID])
GO
ALTER TABLE [dbo].[TrainingGroup] NOCHECK CONSTRAINT [Training_group_Coach_FK]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [check_date] CHECK  (([BirthDate]>='1900-01-01'))
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [check_date]
GO
/****** Object:  StoredProcedure [dbo].[GroupsPlayers]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GroupsPlayers] @trainingGroupName varchar(40)
as
Select 
Concat(Player.Name,' ',Player.Surname) as [full name],Majority.Name as [Majority],Player.Age,Player.Phone,Player.[E-mail]
From Player
inner join [dbo].[TrainingGroup] 
on [dbo].[TrainingGroup].TrainingGroup_ID=Player.Tg_TrainingGroup_ID
left join Majority
on Majority.Majority_ID=Player.Majority_ID
where [TrainingGroup].Name=@trainingGroupName;
GO
/****** Object:  StoredProcedure [dbo].[PlayerProfileSelection]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[PlayerProfileSelection] @name varchar(40), @surname varchar(40)
as
Select 
Player.Name as [Player name],Player.Surname [Player surname], Player.Age as [Player age],Player.BirthDate as [Player birdthdate],Player.[E-mail] as [Player email], Player.Phone as [Player phone], 
TrainingGroup.Name as [player group], Majority.Name as [Majority name],
Card.CardNumber as [Card number], Card.ExpirationDate as [Card expiration date],
Parent.Name as [Parent name], Parent.Surname as [Parent surname],Parent.[E-mail] as [Parent email],Parent.PhoneNumber as [Parent phone]
From
Player
inner join TrainingGroup on TrainingGroup.TrainingGroup_ID=Player.Tg_TrainingGroup_ID
left join Majority on Majority.Majority_ID=Player.Majority_ID
left join Card on Card.Card_ID=Player.Card_Card_Id
left join Parent on Parent.Parent_ID=Player.FK_parent
where Player.Name=@name and Player.Surname=@surname;
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTeam]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteTeam]
    @teamName nvarchar(20)
AS
BEGIN
    -- Get the Team_ID for the given team name
    DECLARE @teamID int;
    SELECT @teamID = Team_ID FROM dbo.Team WHERE Name = @teamName;

    -- Delete all records from the Player/Team table where Team_Team_ID = @teamID
    DELETE FROM dbo.[Player/Team] WHERE Team_Team_ID = @teamID;
	Delete From [dbo].[Match_stat] where [Team_Team_ID]=@teamID;

    -- Delete the team from the Team table
    DELETE FROM dbo.Team WHERE Name = @teamName;
END
GO
/****** Object:  StoredProcedure [dbo].[TeamMatchStatistic]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[TeamMatchStatistic]
as
SELECT Team.Name, 
       SUM(CASE WHEN Match_Stat.VictoryOfOurTeam = 1 THEN 1 ELSE 0 END) AS Wins, 
       SUM(CASE WHEN Match_Stat.VictoryOfOurTeam = 0 THEN 1 ELSE 0 END) AS Losses
FROM Team
INNER JOIN Match_Stat ON Team.Team_ID = Match_Stat.Team_Team_ID
GROUP BY Team.Name
GO
/****** Object:  StoredProcedure [dbo].[TeamsMatchHistory]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[TeamsMatchHistory] @teamName varchar(20)
as
SELECT 
  Match_stat.Oponent, 
  Match_stat.Notes, 
  Match_stat.VictoryOfOurTeam
FROM Match_stat
INNER JOIN Team ON Team.Team_ID = Match_stat.Team_Team_ID
WHERE Team.Name = @teamName;
GO
/****** Object:  StoredProcedure [dbo].[TeamsPlayers]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[TeamsPlayers] @teamName varchar(20)
as 
Select Player.Name+' '+Player.Surname as [Full name], Majority.Name as [Player posistion]
From team
inner join [dbo].[Player/Team] on [dbo].[Player/Team].Team_Team_ID=team.Team_ID
left join Player on Player.Player_ID=[Player/Team].Player_Player_ID
left join Majority on Majority.Majority_ID=Player.Majority_ID
where Team.Name=@teamName;
GO
/****** Object:  StoredProcedure [dbo].[TrainingGroupAmountOfPlayersStatistic]    Script Date: 22.04.2023 20:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[TrainingGroupAmountOfPlayersStatistic] 
as 
Select 
TrainingGroup.Name,
Count(Player.Player_ID) as [amount of players]
From TrainingGroup
inner join Player on Player.Tg_TrainingGroup_ID=TrainingGroup.TrainingGroup_ID
Group by TrainingGroup.Name;
GO
