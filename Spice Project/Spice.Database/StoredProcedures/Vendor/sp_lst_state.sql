CREATE PROC sp_lst_state
AS
BEGIN
SELECT StateId,StateName,StateCode FROM StateMaster 
END

-----------------------------------------------------------------------

