USE [labtest]
GO
/****** Object:  StoredProcedure [dbo].[uspPersonUpsert]    Script Date: 04-01-2019 19:33:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER  PROCEDURE [dbo].[uspPersonUpsert]
(
@person_id int = null, -- input person id default value null when inserting.
@first_name VARCHAR (50),   
@last_name VARCHAR (50),
@state_id int,    
@gender char (1),
@dob datetime   
)
AS
BEGIN
IF(@person_id is null)
-- insert person record if no id sent by user 
insert into person values (@first_name,@last_name,@state_id,@gender,@dob);
--update record if there is a person id
else

update person set first_name=@first_name,last_name=@last_name,state_id=@state_id,gender=@gender,dob=@dob where person_id=@person_id

END

