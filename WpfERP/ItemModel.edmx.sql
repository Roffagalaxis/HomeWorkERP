
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/30/2019 15:19:58
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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