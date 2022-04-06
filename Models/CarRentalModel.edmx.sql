
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/04/2022 11:59:15
-- Generated from EDMX file: D:\MODULE ISTA\M13 PROJET FIN FORMATION\CarRental\Models\CarRentalModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [carrental];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__contrat__idCar__14270015]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[contrat] DROP CONSTRAINT [FK__contrat__idCar__14270015];
GO
IF OBJECT_ID(N'[dbo].[FK__contrat__idclien__2E1BDC42]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[contrat] DROP CONSTRAINT [FK__contrat__idclien__2E1BDC42];
GO
IF OBJECT_ID(N'[dbo].[FK__contrat__idreser__160F4887]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[contrat] DROP CONSTRAINT [FK__contrat__idreser__160F4887];
GO
IF OBJECT_ID(N'[dbo].[FK__modele__idmarque__3F466844]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[modele] DROP CONSTRAINT [FK__modele__idmarque__3F466844];
GO
IF OBJECT_ID(N'[dbo].[FK__reservati__idcar__31EC6D26]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[reservation] DROP CONSTRAINT [FK__reservati__idcar__31EC6D26];
GO
IF OBJECT_ID(N'[dbo].[FK__reservati__idcli__30F848ED]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[reservation] DROP CONSTRAINT [FK__reservati__idcli__30F848ED];
GO
IF OBJECT_ID(N'[dbo].[FK__voiture__idcat__286302EC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[voiture] DROP CONSTRAINT [FK__voiture__idcat__286302EC];
GO
IF OBJECT_ID(N'[dbo].[FK__voiture__idmodel__29572725]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[voiture] DROP CONSTRAINT [FK__voiture__idmodel__29572725];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[category];
GO
IF OBJECT_ID(N'[dbo].[client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[client];
GO
IF OBJECT_ID(N'[dbo].[contrat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[contrat];
GO
IF OBJECT_ID(N'[dbo].[marque]', 'U') IS NOT NULL
    DROP TABLE [dbo].[marque];
GO
IF OBJECT_ID(N'[dbo].[modele]', 'U') IS NOT NULL
    DROP TABLE [dbo].[modele];
GO
IF OBJECT_ID(N'[dbo].[Photo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Photo];
GO
IF OBJECT_ID(N'[dbo].[reservation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[reservation];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[voiture]', 'U') IS NOT NULL
    DROP TABLE [dbo].[voiture];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'categories'
CREATE TABLE [dbo].[categories] (
    [idcat] int IDENTITY(1,1) NOT NULL,
    [libelle_cat] nvarchar(50)  NULL
);
GO

-- Creating table 'clients'
CREATE TABLE [dbo].[clients] (
    [idclient] int IDENTITY(1,1) NOT NULL,
    [nom_cl] varchar(30)  NULL,
    [prenom_cl] varchar(30)  NULL,
    [tel_cl] nvarchar(12)  NULL,
    [adresse_cl] nvarchar(50)  NULL,
    [CIN_cl] nvarchar(9)  NULL,
    [email] nvarchar(50)  NULL
);
GO

-- Creating table 'contrats'
CREATE TABLE [dbo].[contrats] (
    [idcontrat] int IDENTITY(1,1) NOT NULL,
    [idclient] int  NULL,
    [date_debut] datetime  NULL,
    [date_fin] datetime  NULL,
    [montant_contrat] decimal(19,4)  NULL,
    [idCar] int  NULL,
    [idreserv] int  NULL
);
GO

-- Creating table 'marques'
CREATE TABLE [dbo].[marques] (
    [idmarque] int IDENTITY(1,1) NOT NULL,
    [nom_marque] varchar(50)  NULL,
    [logo] nvarchar(100)  NULL,
    [pays] varchar(20)  NULL
);
GO

-- Creating table 'modeles'
CREATE TABLE [dbo].[modeles] (
    [idmodele] int IDENTITY(1,1) NOT NULL,
    [nom_modele] nvarchar(50)  NULL,
    [idmarque] int  NULL,
    [datesortie] datetime  NULL
);
GO

-- Creating table 'Photos'
CREATE TABLE [dbo].[Photos] (
    [idImage] int IDENTITY(1,1) NOT NULL,
    [title] int  NULL,
    [ImagePath] varchar(80)  NULL,
    [idCar] int  NULL
);
GO

-- Creating table 'reservations'
CREATE TABLE [dbo].[reservations] (
    [idreserv] int IDENTITY(1,1) NOT NULL,
    [idclient] int  NULL,
    [idcar] int  NULL,
    [objectif_reserv] nvarchar(100)  NULL,
    [kilometrage] float  NULL,
    [date_debut] datetime  NULL,
    [date_fin] datetime  NULL,
    [valide] bit  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'voitures'
CREATE TABLE [dbo].[voitures] (
    [idcar] int IDENTITY(1,1) NOT NULL,
    [idcat] int  NULL,
    [idmodele] int  NULL,
    [immat] nvarchar(20)  NULL,
    [carte_grise] nvarchar(30)  NULL,
    [nbporte] int  NULL,
    [nbplace] int  NULL,
    [puissance] int  NULL,
    [date_aquis] datetime  NULL,
    [datedebut_assurance] datetime  NULL,
    [datefin_assurance] datetime  NULL,
    [cout_assurance] decimal(19,4)  NULL,
    [typecarburant] varchar(30)  NULL,
    [prixJour] decimal(19,4)  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [idcat] in table 'categories'
ALTER TABLE [dbo].[categories]
ADD CONSTRAINT [PK_categories]
    PRIMARY KEY CLUSTERED ([idcat] ASC);
GO

-- Creating primary key on [idclient] in table 'clients'
ALTER TABLE [dbo].[clients]
ADD CONSTRAINT [PK_clients]
    PRIMARY KEY CLUSTERED ([idclient] ASC);
GO

-- Creating primary key on [idcontrat] in table 'contrats'
ALTER TABLE [dbo].[contrats]
ADD CONSTRAINT [PK_contrats]
    PRIMARY KEY CLUSTERED ([idcontrat] ASC);
GO

-- Creating primary key on [idmarque] in table 'marques'
ALTER TABLE [dbo].[marques]
ADD CONSTRAINT [PK_marques]
    PRIMARY KEY CLUSTERED ([idmarque] ASC);
GO

-- Creating primary key on [idmodele] in table 'modeles'
ALTER TABLE [dbo].[modeles]
ADD CONSTRAINT [PK_modeles]
    PRIMARY KEY CLUSTERED ([idmodele] ASC);
GO

-- Creating primary key on [idImage] in table 'Photos'
ALTER TABLE [dbo].[Photos]
ADD CONSTRAINT [PK_Photos]
    PRIMARY KEY CLUSTERED ([idImage] ASC);
GO

-- Creating primary key on [idreserv] in table 'reservations'
ALTER TABLE [dbo].[reservations]
ADD CONSTRAINT [PK_reservations]
    PRIMARY KEY CLUSTERED ([idreserv] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [idcar] in table 'voitures'
ALTER TABLE [dbo].[voitures]
ADD CONSTRAINT [PK_voitures]
    PRIMARY KEY CLUSTERED ([idcar] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [idcat] in table 'voitures'
ALTER TABLE [dbo].[voitures]
ADD CONSTRAINT [FK__voiture__idcat__286302EC]
    FOREIGN KEY ([idcat])
    REFERENCES [dbo].[categories]
        ([idcat])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__voiture__idcat__286302EC'
CREATE INDEX [IX_FK__voiture__idcat__286302EC]
ON [dbo].[voitures]
    ([idcat]);
GO

-- Creating foreign key on [idclient] in table 'contrats'
ALTER TABLE [dbo].[contrats]
ADD CONSTRAINT [FK__contrat__idclien__2E1BDC42]
    FOREIGN KEY ([idclient])
    REFERENCES [dbo].[clients]
        ([idclient])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__contrat__idclien__2E1BDC42'
CREATE INDEX [IX_FK__contrat__idclien__2E1BDC42]
ON [dbo].[contrats]
    ([idclient]);
GO

-- Creating foreign key on [idclient] in table 'reservations'
ALTER TABLE [dbo].[reservations]
ADD CONSTRAINT [FK__reservati__idcli__30F848ED]
    FOREIGN KEY ([idclient])
    REFERENCES [dbo].[clients]
        ([idclient])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__reservati__idcli__30F848ED'
CREATE INDEX [IX_FK__reservati__idcli__30F848ED]
ON [dbo].[reservations]
    ([idclient]);
GO

-- Creating foreign key on [idmarque] in table 'modeles'
ALTER TABLE [dbo].[modeles]
ADD CONSTRAINT [FK__modele__idmarque__3F466844]
    FOREIGN KEY ([idmarque])
    REFERENCES [dbo].[marques]
        ([idmarque])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__modele__idmarque__3F466844'
CREATE INDEX [IX_FK__modele__idmarque__3F466844]
ON [dbo].[modeles]
    ([idmarque]);
GO

-- Creating foreign key on [idmodele] in table 'voitures'
ALTER TABLE [dbo].[voitures]
ADD CONSTRAINT [FK__voiture__idmodel__29572725]
    FOREIGN KEY ([idmodele])
    REFERENCES [dbo].[modeles]
        ([idmodele])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__voiture__idmodel__29572725'
CREATE INDEX [IX_FK__voiture__idmodel__29572725]
ON [dbo].[voitures]
    ([idmodele]);
GO

-- Creating foreign key on [idcar] in table 'reservations'
ALTER TABLE [dbo].[reservations]
ADD CONSTRAINT [FK__reservati__idcar__31EC6D26]
    FOREIGN KEY ([idcar])
    REFERENCES [dbo].[voitures]
        ([idcar])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__reservati__idcar__31EC6D26'
CREATE INDEX [IX_FK__reservati__idcar__31EC6D26]
ON [dbo].[reservations]
    ([idcar]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [idCar] in table 'contrats'
ALTER TABLE [dbo].[contrats]
ADD CONSTRAINT [FK__contrat__idCar__14270015]
    FOREIGN KEY ([idCar])
    REFERENCES [dbo].[voitures]
        ([idcar])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__contrat__idCar__14270015'
CREATE INDEX [IX_FK__contrat__idCar__14270015]
ON [dbo].[contrats]
    ([idCar]);
GO

-- Creating foreign key on [idreserv] in table 'contrats'
ALTER TABLE [dbo].[contrats]
ADD CONSTRAINT [FK__contrat__idreser__160F4887]
    FOREIGN KEY ([idreserv])
    REFERENCES [dbo].[reservations]
        ([idreserv])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__contrat__idreser__160F4887'
CREATE INDEX [IX_FK__contrat__idreser__160F4887]
ON [dbo].[contrats]
    ([idreserv]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------