USE [labtest]
GO
/****** Object:  StoredProcedure [dbo].[uspStatesList]    Script Date: 04-01-2019 19:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[uspStatesList]
AS
SELECT * FROM states
GO;