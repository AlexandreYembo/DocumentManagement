/* Using connection string Data Source=.\SQLEXPRESS;Initial Catalog=DocumentManagement;Integrated Security=True;Pooling=False */
/* VersionMigration migrating ================================================ */

/* Beginning Transaction */
BEGIN TRANSACTION
GO
/* CreateTable VersionInfo */
CREATE TABLE [dbo].[VersionInfo] ([Version] BIGINT NOT NULL)
GO
/* Committing Transaction */
COMMIT TRANSACTION
GO
/* VersionMigration migrated */
/* VersionUniqueMigration migrating ========================================== */

/* Beginning Transaction */
BEGIN TRANSACTION
GO
/* CreateIndex VersionInfo (Version) */
CREATE UNIQUE CLUSTERED INDEX [UC_Version] ON [dbo].[VersionInfo] ([Version] ASC)
GO
/* AlterTable VersionInfo */
/* No SQL statement executed. */
/* CreateColumn VersionInfo AppliedOn DateTime */
ALTER TABLE [dbo].[VersionInfo] ADD [AppliedOn] DATETIME
GO
/* Committing Transaction */
COMMIT TRANSACTION
GO
/* VersionUniqueMigration migrated */
/* VersionDescriptionMigration migrating ===================================== */

/* Beginning Transaction */
BEGIN TRANSACTION
GO
/* AlterTable VersionInfo */
/* No SQL statement executed. */
/* CreateColumn VersionInfo Description String */
ALTER TABLE [dbo].[VersionInfo] ADD [Description] NVARCHAR(1024)
GO
/* Committing Transaction */
COMMIT TRANSACTION
GO
/* VersionDescriptionMigration migrated */
/* 2018091607230000: _2018091607230000_CreateTableUser migrating ============= */

/* Beginning Transaction */
BEGIN TRANSACTION
GO
/* CreateTable USERAPP */
CREATE TABLE [dbo].[USERAPP] ([IDUSERAPP] BIGINT NOT NULL IDENTITY(1,1), [DSLOGIN] NVARCHAR(100) NOT NULL, CONSTRAINT [PK_USERAPP] PRIMARY KEY ([IDUSERAPP]))
GO
INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (2018091607230000, '2018-09-17T23:07:20', N'_2018091607230000_CreateTableUser')
GO
/* Committing Transaction */
COMMIT TRANSACTION
GO
/* 2018091607230000: _2018091607230000_CreateTableUser migrated */
/* 2018091607250000: _2018091607250000_CreateTableDocument migrating ========= */

/* Beginning Transaction */
BEGIN TRANSACTION
GO
/* CreateTable DOCUMENT */
CREATE TABLE [dbo].[DOCUMENT] ([IDDOCUMENT] BIGINT NOT NULL IDENTITY(1,1), [IDUSERAPP] BIGINT NOT NULL, [FILENAME] NVARCHAR(100), [FILESIZE] BIGINT NOT NULL, [FILEFORMAT] NVARCHAR(50), [UPLOADDATE] DATETIME NOT NULL CONSTRAINT [DF_DOCUMENT_UPLOADDATE] DEFAULT '2018-09-17T20:07:20', [UPDATEDATE] DATETIME, [LASTACCESSDATE] DATETIME, [FILENAMESTORAGE] NVARCHAR(100), CONSTRAINT [PK_DOCUMENT] PRIMARY KEY ([IDDOCUMENT]))
GO
/* CreateForeignKey FK_DOCUMENT_IDUSERAPP_USERAPP_IDUSERAPP DOCUMENT(IDUSERAPP) USERAPP(IDUSERAPP) */
ALTER TABLE [dbo].[DOCUMENT] ADD CONSTRAINT [FK_DOCUMENT_IDUSERAPP_USERAPP_IDUSERAPP] FOREIGN KEY ([IDUSERAPP]) REFERENCES [dbo].[USERAPP] ([IDUSERAPP])
GO
INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (2018091607250000, '2018-09-17T23:07:20', N'_2018091607250000_CreateTableDocument')
GO
/* Committing Transaction */
COMMIT TRANSACTION
GO
/* 2018091607250000: _2018091607250000_CreateTableDocument migrated */
/* Task completed. */
