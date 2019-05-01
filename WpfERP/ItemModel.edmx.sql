
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/01/2019 13:55:03
-- Generated from EDMX file: C:\Users\tamalik\OneDrive - National Instruments\personal\UNI_Hajni\2018_19_2\Vizualis_prog_RH\WpfERP\WpfERP\ItemModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ERPDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TermekekSzeriaszamok]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SzeriaszamokSet] DROP CONSTRAINT [FK_TermekekSzeriaszamok];
GO
IF OBJECT_ID(N'[dbo].[FK_SzeriaszamokKeszlet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KeszletSet] DROP CONSTRAINT [FK_SzeriaszamokKeszlet];
GO
IF OBJECT_ID(N'[dbo].[FK_TermekekKeszlet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KeszletSet] DROP CONSTRAINT [FK_TermekekKeszlet];
GO
IF OBJECT_ID(N'[dbo].[FK_PolcokKeszlet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KeszletSet] DROP CONSTRAINT [FK_PolcokKeszlet];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[KeszletSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KeszletSet];
GO
IF OBJECT_ID(N'[dbo].[TermekekSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TermekekSet];
GO
IF OBJECT_ID(N'[dbo].[SzeriaszamokSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SzeriaszamokSet];
GO
IF OBJECT_ID(N'[dbo].[PolcokSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PolcokSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'KeszletSet'
CREATE TABLE [dbo].[KeszletSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Mennyiseg] int  NOT NULL,
    [Szeriaszamok_Id] int  NOT NULL,
    [Termekek_Id] int  NOT NULL,
    [Polcok_Id] int  NOT NULL
);
GO

-- Creating table 'TermekekSet'
CREATE TABLE [dbo].[TermekekSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Neve] nvarchar(max)  NOT NULL,
    [Leiras] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SzeriaszamokSet'
CREATE TABLE [dbo].[SzeriaszamokSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Szeriaszam] nvarchar(max)  NOT NULL,
    [Statusz] nvarchar(max)  NOT NULL,
    [Termekek_Id] int  NOT NULL
);
GO

-- Creating table 'PolcokSet'
CREATE TABLE [dbo].[PolcokSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nev] nvarchar(max)  NOT NULL,
    [Szint] nvarchar(max)  NOT NULL,
    [Doboz] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsersSet'
CREATE TABLE [dbo].[UsersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'KeszletSet'
ALTER TABLE [dbo].[KeszletSet]
ADD CONSTRAINT [PK_KeszletSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TermekekSet'
ALTER TABLE [dbo].[TermekekSet]
ADD CONSTRAINT [PK_TermekekSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SzeriaszamokSet'
ALTER TABLE [dbo].[SzeriaszamokSet]
ADD CONSTRAINT [PK_SzeriaszamokSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PolcokSet'
ALTER TABLE [dbo].[PolcokSet]
ADD CONSTRAINT [PK_PolcokSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersSet'
ALTER TABLE [dbo].[UsersSet]
ADD CONSTRAINT [PK_UsersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Termekek_Id] in table 'SzeriaszamokSet'
ALTER TABLE [dbo].[SzeriaszamokSet]
ADD CONSTRAINT [FK_TermekekSzeriaszamok]
    FOREIGN KEY ([Termekek_Id])
    REFERENCES [dbo].[TermekekSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TermekekSzeriaszamok'
CREATE INDEX [IX_FK_TermekekSzeriaszamok]
ON [dbo].[SzeriaszamokSet]
    ([Termekek_Id]);
GO

-- Creating foreign key on [Szeriaszamok_Id] in table 'KeszletSet'
ALTER TABLE [dbo].[KeszletSet]
ADD CONSTRAINT [FK_SzeriaszamokKeszlet]
    FOREIGN KEY ([Szeriaszamok_Id])
    REFERENCES [dbo].[SzeriaszamokSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SzeriaszamokKeszlet'
CREATE INDEX [IX_FK_SzeriaszamokKeszlet]
ON [dbo].[KeszletSet]
    ([Szeriaszamok_Id]);
GO

-- Creating foreign key on [Termekek_Id] in table 'KeszletSet'
ALTER TABLE [dbo].[KeszletSet]
ADD CONSTRAINT [FK_TermekekKeszlet]
    FOREIGN KEY ([Termekek_Id])
    REFERENCES [dbo].[TermekekSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TermekekKeszlet'
CREATE INDEX [IX_FK_TermekekKeszlet]
ON [dbo].[KeszletSet]
    ([Termekek_Id]);
GO

-- Creating foreign key on [Polcok_Id] in table 'KeszletSet'
ALTER TABLE [dbo].[KeszletSet]
ADD CONSTRAINT [FK_PolcokKeszlet]
    FOREIGN KEY ([Polcok_Id])
    REFERENCES [dbo].[PolcokSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PolcokKeszlet'
CREATE INDEX [IX_FK_PolcokKeszlet]
ON [dbo].[KeszletSet]
    ([Polcok_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------