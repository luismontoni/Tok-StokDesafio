CREATE PROCEDURE spVerificaId
	@Id uniqueidentifier
AS
	SELECT CASE WHEN EXISTS (
		SELECT [Id]
		FROM [Especificadores]
		WHERE [Id] = @Id
	)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT) END

