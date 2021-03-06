USE [labtest]
GO
/****** Object:  StoredProcedure [dbo].[uspPersonSearch]    Script Date: 04-01-2019 19:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE [dbo].[uspPersonSearch]
(

@person_name varchar(100) = null    --input parameter person first or last name     
)
AS 
BEGIN
if(@person_name IS null OR @person_name='')


SELECT person_id,first_name,last_name,(select state_code from states where state_id=person.state_id) as state_code,gender,dob FROM person;
else
SELECT person_id,first_name,last_name,(select state_code from states where state_id=person.state_id) as state_code,gender,dob
 FROM person where first_name like '%'+@person_name+'%' or  last_name like '%'+@person_name+'%' ;

END
