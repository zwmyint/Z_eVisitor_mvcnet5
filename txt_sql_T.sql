ALTER PROCEDURE [dbo].[sp_Teacher]
	 @TeacherId int
	,@FullName nvarchar(100)	
	,@SubjectName nvarchar(150)

AS
BEGIN TRAN
	
	IF(@TeacherId = 0) --Insert
	BEGIN
		
		--SET @TeacherId = (SELECT COUNT(*) FROM tbl_Teacher_D) + 1

		--INSERT INTO tbl_Teacher_D  (TeacherId, FullName, SubjectName)
		--	           VALUES(@TeacherId, @FullName, @SubjectName)


		SET @TeacherId = (SELECT MAX(TeacherId) FROM tbl_Teacher_D)

		INSERT INTO tbl_Teacher_D  (FullName, SubjectName)
			           VALUES( @FullName, @SubjectName)


		SELECT * FROM tbl_Teacher_D WHERE TeacherId=@TeacherId

	END
	ELSE IF(@TeacherId > 0) --Update
	BEGIN
		IF (@TeacherId = 0)
		BEGIN
			RollBACK
				RAISERROR (N'Invalid Teacher !!!~',16,1);	
			RETURN
		END

		UPDATE tbl_Teacher_D SET FullName=@FullName
						   ,SubjectName=@SubjectName
						WHERE TeacherId=@TeacherId

		SELECT * FROM tbl_Teacher_D WHERE TeacherId=@TeacherId
	END
COMMIT TRAN