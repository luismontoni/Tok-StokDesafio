CREATE PROCEDURE spAtualizaEspecificador
    @Id UNIQUEIDENTIFIER,
    @Nome VARCHAR(255)
AS
	UPDATE 
		[dbo].[Especificadores]
	SET
		[Nome] = @Nome
	WHERE
		[Id] = @Id
	