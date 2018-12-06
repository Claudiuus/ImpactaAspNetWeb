CREATE TABLE [dbo].[Contato] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [Nome]     NVARCHAR (200)  NOT NULL,
    [Email]    NVARCHAR (100)  NOT NULL,
    [Mensagem] NVARCHAR (1000) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

