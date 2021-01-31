-- Old
ALTER PROCEDURE [dbo].[SP_Student]
	 @StudentId varchar(50)
	,@Name varchar(MAX)	
	,@Roll varchar(6)

AS
BEGIN TRAN
	
	IF(@StudentId = 0) --Insert
	BEGIN
		
		SET @StudentId = (SELECT COUNT(*) FROM Student) + 1

		INSERT INTO Student  (StudentId,	[Name],		Roll)
			           VALUES(@StudentId,	@Name,		@Roll)

		SELECT * FROM Student WHERE StudentId=@StudentId

	END
	ELSE IF(@StudentId > 0) --Update
	BEGIN
		IF (@StudentId = 0)
		BEGIN
			ROLLBACK
				RAISERROR (N'Invalid Student !!!~',16,1);	
			RETURN
		END

		UPDATE Student SET [Name]=@Name
						   ,Roll=@Roll
						WHERE StudentId=@StudentId

		SELECT * FROM Student WHERE StudentId=@StudentId
	END
COMMIT TRAN