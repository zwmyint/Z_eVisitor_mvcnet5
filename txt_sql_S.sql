USE [StudentDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_Student]    Script Date: 5/17/2020 8:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Student]
	 @StudentId int
	,@StudentName nvarchar(100)	
	,@Roll nvarchar(50)
	,@OperationType int

AS
BEGIN TRAN
	
	IF(@OperationType = 1) --Insert
		BEGIN
			
			--SET @StudentId = (SELECT COUNT(*) FROM tbl_Student_D) + 1

			--INSERT INTO tbl_Student_D (StudentId, StudentName, Roll)
			--			   VALUES(@StudentId, @StudentName, @Roll)
			
			INSERT INTO tbl_Student_D (StudentName, Roll, [Message])
						   VALUES(@StudentName, @Roll, 'New')

			SET @StudentId = (SELECT COUNT(*) FROM tbl_Student_D) 

			SELECT * FROM tbl_Student_D WHERE StudentId=@StudentId


		END
	ELSE IF(@OperationType = 2) --Update
		BEGIN
			IF (@StudentId = 0)
			BEGIN
				ROLLBACK
					RAISERROR (N'Invalid Student !!!~',16,1);	
				RETURN
			END

			UPDATE tbl_Student_D SET StudentName=@StudentName ,Roll=@Roll
							WHERE StudentId=@StudentId

			SELECT * FROM tbl_Student_D WHERE StudentId=@StudentId
		END
	ELSE IF(@OperationType = 3) --Delete
		BEGIN
			IF (@StudentId = 0)
			BEGIN
				ROLLBACK
					RAISERROR (N'Invalid Student !!!~',16,1);	
				RETURN
			END

			DELETE FROM tbl_Student_D WHERE StudentId=@StudentId
		END
COMMIT TRAN






