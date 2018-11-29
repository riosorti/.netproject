
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/27/2018 14:14:30
-- Generated from EDMX file: C:\Users\luisr\OneDrive\Desktop\Capstone\Capstone\DBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Capstone];
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

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Programs'
CREATE TABLE [dbo].[Programs] (
    [pId] int IDENTITY(1,1) NOT NULL,
    [ProgranName] nvarchar(max)  NOT NULL,
    [Prerequisites] nvarchar(max)  NOT NULL,
    [Ouac] nvarchar(max)  NOT NULL,
    [MinGrade] nvarchar(max)  NOT NULL,
    [School] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Favourite'
CREATE TABLE [dbo].[Favourite] (
    [Students_Id] int  NOT NULL,
    [Programs_pId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [pId] in table 'Programs'
ALTER TABLE [dbo].[Programs]
ADD CONSTRAINT [PK_Programs]
    PRIMARY KEY CLUSTERED ([pId] ASC);
GO

-- Creating primary key on [Students_Id], [Programs_pId] in table 'Favourite'
ALTER TABLE [dbo].[Favourite]
ADD CONSTRAINT [PK_Favourite]
    PRIMARY KEY CLUSTERED ([Students_Id], [Programs_pId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Students_Id] in table 'Favourite'
ALTER TABLE [dbo].[Favourite]
ADD CONSTRAINT [FK_Favourite_Student]
    FOREIGN KEY ([Students_Id])
    REFERENCES [dbo].[Students]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Programs_pId] in table 'Favourite'
ALTER TABLE [dbo].[Favourite]
ADD CONSTRAINT [FK_Favourite_Program]
    FOREIGN KEY ([Programs_pId])
    REFERENCES [dbo].[Programs]
        ([pId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Favourite_Program'
CREATE INDEX [IX_FK_Favourite_Program]
ON [dbo].[Favourite]
    ([Programs_pId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------