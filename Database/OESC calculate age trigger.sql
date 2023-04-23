USE [OESC]
GO

/****** Object:  Trigger [dbo].[trg_calculate_player_age]    Script Date: 22.04.2023 20:12:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_calculate_player_age]
ON [dbo].[Player]
AFTER INSERT
AS
BEGIN
    UPDATE dbo.Player
    SET Age = DATEDIFF(year, inserted.BirthDate, GETDATE())
    FROM inserted
    WHERE dbo.Player.Player_ID = inserted.Player_ID
END
GO

ALTER TABLE [dbo].[Player] ENABLE TRIGGER [trg_calculate_player_age]
GO


