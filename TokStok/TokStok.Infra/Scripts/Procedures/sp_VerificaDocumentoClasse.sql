CREATE PROCEDURE spVerificaDocumentoClasse
	@NumeroDocumentoClasse CHAR(15)
AS
	SELECT CASE WHEN EXISTS (
		SELECT [Id]
		FROM [Especificadores]
		WHERE [NumeroDocumentoClasse] = @NumeroDocumentoClasse
	)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT) END