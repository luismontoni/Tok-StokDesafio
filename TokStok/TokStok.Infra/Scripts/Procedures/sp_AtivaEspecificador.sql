CREATE PROCEDURE spAtivaEspecificador
    @Id UNIQUEIDENTIFIER
AS
	UPDATE 
		[dbo].[Especificadores]
	SET
		[EspecificadorAtivo] = 1
	WHERE
		[Id] = @Id