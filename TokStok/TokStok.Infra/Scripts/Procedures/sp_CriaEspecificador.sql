CREATE PROCEDURE spCriaEspecificador
    @Id UNIQUEIDENTIFIER,
    @Nome VARCHAR(255),
    @CPF CHAR(11),
    @TipoDocumentoClasse varchar(10),
    @NumeroDocumentoClasse varchar(15),
    @EspecificadorAtivo BIT
AS
 INSERT INTO [dbo].[Especificadores]
           ([Id]
           ,[Nome]
           ,[CPF]
           ,[TipoDocumentoClasse]
           ,[NumeroDocumentoClasse]
           ,[EspecificadorAtivo])
     VALUES
           (@Id 
           ,@Nome
           ,@CPF
           ,@TipoDocumentoClasse
           ,@NumeroDocumentoClasse
           ,@EspecificadorAtivo
		   )
	
