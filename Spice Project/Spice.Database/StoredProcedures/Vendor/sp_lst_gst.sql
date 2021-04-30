CREATE PROC sp_lst_gst
AS
BEGIN
SELECT GstId,GstValue FROM GSTMaster WHERE IsActive=1
END

------------------------------------------------------

INSERT INTO GSTMaster VALUES('CGST',1,GETDATE(),NULL)
INSERT INTO GSTMaster VALUES('SGST',1,GETDATE(),NULL)