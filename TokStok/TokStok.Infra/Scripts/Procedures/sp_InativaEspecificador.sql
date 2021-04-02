CREATE PROCEDURE spInativaEspecificador
    @Id UNIQUEIDENTIFIER
AS
	UPDATE 
		[dbo].[Especificadores]
	SET
		[EspecificadorAtivo] = 0
	WHERE
		[Id] = @Id