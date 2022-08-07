
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/16/2022 23:40:12
-- Generated from EDMX file: D:\Учеба\диплом\ProductEvolutionV1.3\ProductEvolutionV1.3\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MainBd];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserUserProfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_UserUserProfil];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProfilHistorySearch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HistorySearchSet] DROP CONSTRAINT [FK_UserProfilHistorySearch];
GO
IF OBJECT_ID(N'[dbo].[FK_RateItemsHistorySearch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RateItemsSet] DROP CONSTRAINT [FK_RateItemsHistorySearch];
GO
IF OBJECT_ID(N'[dbo].[FK_RateItemsCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RateItemsSet] DROP CONSTRAINT [FK_RateItemsCategory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[UserProfilSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserProfilSet];
GO
IF OBJECT_ID(N'[dbo].[HistorySearchSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HistorySearchSet];
GO
IF OBJECT_ID(N'[dbo].[RateItemsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RateItemsSet];
GO
IF OBJECT_ID(N'[dbo].[CategorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategorySet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [UserStatus] nvarchar(max)  NOT NULL,
    [UserProfil_UserProfilId] int  NOT NULL
);
GO

-- Creating table 'UserProfilSet'
CREATE TABLE [dbo].[UserProfilSet] (
    [UserProfilId] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [StatusWork] nvarchar(max)  NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Age] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'HistorySearchSet'
CREATE TABLE [dbo].[HistorySearchSet] (
    [SearchId] int IDENTITY(1,1) NOT NULL,
    [NameSearch] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL,
    [UserProfil_UserProfilId] int  NOT NULL,
    [RateItems_RateItemsId] int  NOT NULL
);
GO

-- Creating table 'RateItemsSet'
CREATE TABLE [dbo].[RateItemsSet] (
    [RateItemsId] int IDENTITY(1,1) NOT NULL,
    [Rate] nvarchar(max)  NOT NULL,
    [Category_CategoryId] int  NOT NULL
);
GO

-- Creating table 'CategorySet'
CREATE TABLE [dbo].[CategorySet] (
    [CategoryId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [UserProfilId] in table 'UserProfilSet'
ALTER TABLE [dbo].[UserProfilSet]
ADD CONSTRAINT [PK_UserProfilSet]
    PRIMARY KEY CLUSTERED ([UserProfilId] ASC);
GO

-- Creating primary key on [SearchId] in table 'HistorySearchSet'
ALTER TABLE [dbo].[HistorySearchSet]
ADD CONSTRAINT [PK_HistorySearchSet]
    PRIMARY KEY CLUSTERED ([SearchId] ASC);
GO

-- Creating primary key on [RateItemsId] in table 'RateItemsSet'
ALTER TABLE [dbo].[RateItemsSet]
ADD CONSTRAINT [PK_RateItemsSet]
    PRIMARY KEY CLUSTERED ([RateItemsId] ASC);
GO

-- Creating primary key on [CategoryId] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [PK_CategorySet]
    PRIMARY KEY CLUSTERED ([CategoryId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserProfil_UserProfilId] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_UserUserProfil]
    FOREIGN KEY ([UserProfil_UserProfilId])
    REFERENCES [dbo].[UserProfilSet]
        ([UserProfilId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserProfil'
CREATE INDEX [IX_FK_UserUserProfil]
ON [dbo].[UserSet]
    ([UserProfil_UserProfilId]);
GO

-- Creating foreign key on [UserProfil_UserProfilId] in table 'HistorySearchSet'
ALTER TABLE [dbo].[HistorySearchSet]
ADD CONSTRAINT [FK_UserProfilHistorySearch]
    FOREIGN KEY ([UserProfil_UserProfilId])
    REFERENCES [dbo].[UserProfilSet]
        ([UserProfilId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProfilHistorySearch'
CREATE INDEX [IX_FK_UserProfilHistorySearch]
ON [dbo].[HistorySearchSet]
    ([UserProfil_UserProfilId]);
GO

-- Creating foreign key on [RateItems_RateItemsId] in table 'HistorySearchSet'
ALTER TABLE [dbo].[HistorySearchSet]
ADD CONSTRAINT [FK_RateItemsHistorySearch]
    FOREIGN KEY ([RateItems_RateItemsId])
    REFERENCES [dbo].[RateItemsSet]
        ([RateItemsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RateItemsHistorySearch'
CREATE INDEX [IX_FK_RateItemsHistorySearch]
ON [dbo].[HistorySearchSet]
    ([RateItems_RateItemsId]);
GO

-- Creating foreign key on [Category_CategoryId] in table 'RateItemsSet'
ALTER TABLE [dbo].[RateItemsSet]
ADD CONSTRAINT [FK_RateItemsCategory]
    FOREIGN KEY ([Category_CategoryId])
    REFERENCES [dbo].[CategorySet]
        ([CategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RateItemsCategory'
CREATE INDEX [IX_FK_RateItemsCategory]
ON [dbo].[RateItemsSet]
    ([Category_CategoryId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------