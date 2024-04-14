IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240327110535_InitialCreate')
BEGIN
    CREATE TABLE [Categorien] (
        [CategoryID] int NOT NULL IDENTITY,
        [CategorieNaam] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Categorien] PRIMARY KEY ([CategoryID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240327110535_InitialCreate')
BEGIN
    CREATE TABLE [Produkten] (
        [ProductID] int NOT NULL IDENTITY,
        [ProduktNaam] nvarchar(max) NOT NULL,
        [Prijs] decimal(20,2) NOT NULL,
        [Omschrijving] nvarchar(max) NULL,
        [Allergieën] nvarchar(max) NOT NULL,
        [Extra] nvarchar(max) NOT NULL,
        [CategoryID] int NOT NULL,
        [CategorieCategoryID] int NULL,
        CONSTRAINT [PK_Produkten] PRIMARY KEY ([ProductID]),
        CONSTRAINT [FK_Produkten_Categorien_CategorieCategoryID] FOREIGN KEY ([CategorieCategoryID]) REFERENCES [Categorien] ([CategoryID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240327110535_InitialCreate')
BEGIN
    CREATE TABLE [WinkelmandjeItems] (
        [WinkelmandjeItemID] int NOT NULL IDENTITY,
        [ProduktProductID] int NOT NULL,
        [Aantal] int NOT NULL,
        [SessieId] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_WinkelmandjeItems] PRIMARY KEY ([WinkelmandjeItemID]),
        CONSTRAINT [FK_WinkelmandjeItems_Produkten_ProduktProductID] FOREIGN KEY ([ProduktProductID]) REFERENCES [Produkten] ([ProductID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240327110535_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryID', N'CategorieNaam') AND [object_id] = OBJECT_ID(N'[Categorien]'))
        SET IDENTITY_INSERT [Categorien] ON;
    EXEC(N'INSERT INTO [Categorien] ([CategoryID], [CategorieNaam])
    VALUES (1, N''Soep''),
    (2, N''Salades''),
    (3, N''Pasta''),
    (4, N''Snack''),
    (5, N''Belegde broodjes''),
    (6, N''Zoet / Fruit''),
    (7, N''Andere''),
    (8, N''Dranken'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryID', N'CategorieNaam') AND [object_id] = OBJECT_ID(N'[Categorien]'))
        SET IDENTITY_INSERT [Categorien] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240327110535_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductID', N'Allergieën', N'CategorieCategoryID', N'CategoryID', N'Extra', N'Omschrijving', N'Prijs', N'ProduktNaam') AND [object_id] = OBJECT_ID(N'[Produkten]'))
        SET IDENTITY_INSERT [Produkten] ON;
    EXEC(N'INSERT INTO [Produkten] ([ProductID], [Allergieën], [CategorieCategoryID], [CategoryID], [Extra], [Omschrijving], [Prijs], [ProduktNaam])
    VALUES (1, N''Contacteer on hierover!'', NULL, 1, N''Geen extra info meer beschikbaar'', N''Soep van de dag'', 1.1, N''Soep''),
    (2, N''Gluten, Lactose, Soja, Selderij'', NULL, 7, N''Kan sporen van noten bevatten'', N''Stuk stokbrood'', 0.55, N''Stokbrood''),
    (3, N''Contacteer on hierover!'', NULL, 7, N''Geen extra info'', N''Blokje melkerij boter'', 0.55, N''Boter''),
    (4, N''Contacteer on hierover!'', NULL, 2, N''Geen extra info'', N''Sla met stukjes Kip'', 5.0, N''Ceasar Salad''),
    (5, N''Contacteer on hierover!'', NULL, 3, N''Geen extra info'', N''Pasta Klein'', 5.5, N''Pasta 4 Kazen''),
    (6, N''Contacteer ons hierover!'', NULL, 3, N''Geen extra info'', N''Pasta Groot'', 7.0, N''Pasta 4 kazen''),
    (7, N''Contacteer ons hierover!'', NULL, 5, N''Geen extra info'', N''Panini'', 4.0, N''Panini met ham en kaas''),
    (8, N''Contacteer ons hierover!'', NULL, 5, N''Geen extra info'', N''Kaas'', 2.85, N''Belegd Broodje met kaas''),
    (9, N''Contacteer ons hierover!'', NULL, 5, N''Geen extra info'', N''Ham'', 2.85, N''Belegd Broodje met ham''),
    (10, N''Contacteer ons hierover!'', NULL, 5, N''Geen extra info'', N''Kaas/Ham'', 3.0, N''Belegd Broodje met kaas/ham''),
    (11, N''Contacteer ons hierover!'', NULL, 5, N''Geen extra info'', N''Prepare'', 3.0, N''Belegd Broodje met prepare''),
    (12, N''Contacteer ons hierover!'', NULL, 5, N''Geen extra info'', N''Smos'', 3.1, N''Belegd Broodje met smos''),
    (13, N''Contacteer ons hierover!'', NULL, 5, N''Geen extra info'', N''Kip curry'', 3.1, N''Belegd Broodje met kip curry''),
    (14, N''Contacteer ons hierover!'', NULL, 5, N''Geen extra info'', N''Surimi'', 3.5, N''Belegd Broodje met surimi''),
    (15, N''Contacteer ons hierover!'', NULL, 5, N''Geen extra info'', N''Gerookte ham'', 4.0, N''Belegd Broodje met gerookte ham''),
    (16, N''Contacteer ons hierover!'', NULL, 5, N''Geen extra info'', N''Gerookte zalm'', 4.0, N''Belegd Broodje met gerookte zalm''),
    (17, N''Contacteer ons hierover!'', NULL, 6, N''Geen extra info'', N''Stuk fruit'', 0.35, N''Stukje fruit''),
    (18, N''Contacteer ons hierover!'', NULL, 6, N''Geen extra info'', N''Yogurt'', 1.3, N''Potje yogurt''),
    (19, N''Contacteer ons hierover!'', NULL, 6, N''Geen extra info'', N''Home-made dessert'', 2.2, N''Dessert''),
    (20, N''Contacteer ons hierover!'', NULL, 6, N''Geen extra info'', N''Crazy Berry'', 2.75, N''Foodbar''),
    (21, N''Contacteer ons hierover!'', NULL, 6, N''Geen extra info'', N''Good Food'', 2.75, N''Foodbar''),
    (22, N''Contacteer ons hierover!'', NULL, 6, N''Geen extra info'', N''Muffin / Donut'', 1.45, N''Dessert''),
    (23, N''Contacteer ons hierover!'', NULL, 6, N''Geen extra info'', N''Gebak'', 1.65, N''Dessert''),
    (24, N''Contacteer ons hierover!'', NULL, 6, N''Geen extra info'', N''Dessert voorverpakt'', 1.3, N''Dessert''),
    (25, N''Contacteer ons hierover!'', NULL, 6, N''Geen extra info'', N''Snoep'', 1.3, N''Snoep''),
    (26, N''Contacteer ons hierover!'', NULL, 6, N''Geen extra info'', N''Kinder Bueno'', 1.45, N''Snoep''),
    (27, N''Contacteer ons hierover!'', NULL, 6, N''Geen extra info'', N''Chips'', 1.65, N''Snoep''),
    (28, N''Contacteer ons hierover!'', NULL, 6, N''Geen extra info'', N''Chocolade'', 1.65, N''Snoep''),
    (29, N''Contacteer ons hierover!'', NULL, 6, N''Geen extra info'', N''Innocent smoothie'', 3.1, N''Smoothie''),
    (30, N''Contacteer ons hierover!'', NULL, 8, N''Geen extra info'', N''Plat water (0.5L)'', 1.3, N''Chaudefontaine''),
    (31, N''Contacteer ons hierover!'', NULL, 8, N''Geen extra info'', N''Bruis water (0.5L)'', 1.3, N''Chaudefontaine''),
    (32, N''Contacteer ons hierover!'', NULL, 8, N''Geen extra info'', N''Cola (0.5L)'', 1.75, N''Flesje frisdrank''),
    (33, N''Contacteer ons hierover!'', NULL, 8, N''Geen extra info'', N''Fanta (0.5L)'', 1.75, N''Flesje frisdrank''),
    (34, N''Contacteer ons hierover!'', NULL, 8, N''Geen extra info'', N''Sprite (0.5L)'', 1.75, N''Flesje frisdrank'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductID', N'Allergieën', N'CategorieCategoryID', N'CategoryID', N'Extra', N'Omschrijving', N'Prijs', N'ProduktNaam') AND [object_id] = OBJECT_ID(N'[Produkten]'))
        SET IDENTITY_INSERT [Produkten] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240327110535_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductID', N'Allergieën', N'CategorieCategoryID', N'CategoryID', N'Extra', N'Omschrijving', N'Prijs', N'ProduktNaam') AND [object_id] = OBJECT_ID(N'[Produkten]'))
        SET IDENTITY_INSERT [Produkten] ON;
    EXEC(N'INSERT INTO [Produkten] ([ProductID], [Allergieën], [CategorieCategoryID], [CategoryID], [Extra], [Omschrijving], [Prijs], [ProduktNaam])
    VALUES (35, N''Contacteer ons hierover!'', NULL, 8, N''Geen extra info'', N''Lipton Ice-Tea (0.5L)'', 1.9, N''Flesje frisdrank''),
    (36, N''Contacteer ons hierover!'', NULL, 8, N''Geen extra info'', N''Appelsiensap (0.33L)'', 1.75, N''Flesje fruitsap''),
    (37, N''Contacteer ons hierover!'', NULL, 8, N''Geen extra info'', N''Appelsap (0.33L)'', 1.75, N''Flesje fruitsap''),
    (38, N''Contacteer ons hierover!'', NULL, 8, N''Geen extra info'', N''Cécémel (0.33L)'', 1.75, N''Flesje Cécémel''),
    (39, N''Contacteer ons hierover!'', NULL, 8, N''Geen extra info'', N''Blikje Nalu (0.25L)'', 2.2, N''Energiedrank''),
    (40, N''Contacteer ons hierover!'', NULL, 8, N''Geen extra info'', N''Red-Bull (0.25L)'', 2.75, N''Energiedrank''),
    (41, N''Contacteer ons hierover!'', NULL, 8, N''Geen extra info'', N''Cold Coffee to Go'', 1.2, N''Koffiedrank'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductID', N'Allergieën', N'CategorieCategoryID', N'CategoryID', N'Extra', N'Omschrijving', N'Prijs', N'ProduktNaam') AND [object_id] = OBJECT_ID(N'[Produkten]'))
        SET IDENTITY_INSERT [Produkten] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240327110535_InitialCreate')
BEGIN
    CREATE INDEX [IX_Produkten_CategorieCategoryID] ON [Produkten] ([CategorieCategoryID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240327110535_InitialCreate')
BEGIN
    CREATE INDEX [IX_WinkelmandjeItems_ProduktProductID] ON [WinkelmandjeItems] ([ProduktProductID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240327110535_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240327110535_InitialCreate', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328123033_ProductsAndCategories')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240328123033_ProductsAndCategories', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328123218_WinkelmandjeItem')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240328123218_WinkelmandjeItem', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328135240_AddIdentity')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328135240_AddIdentity')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328135240_AddIdentity')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328135240_AddIdentity')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328135240_AddIdentity')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328135240_AddIdentity')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328135240_AddIdentity')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328135240_AddIdentity')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328135240_AddIdentity')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328135240_AddIdentity')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328135240_AddIdentity')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328135240_AddIdentity')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328135240_AddIdentity')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328135240_AddIdentity')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328135240_AddIdentity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240328135240_AddIdentity', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328195754_UpdateWinkelmandjeItem')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240328195754_UpdateWinkelmandjeItem', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328200614_Bestellingen')
BEGIN
    ALTER TABLE [WinkelmandjeItems] ADD [BestellingId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328200614_Bestellingen')
BEGIN
    CREATE TABLE [Bestellingen] (
        [BestellingId] int NOT NULL IDENTITY,
        [UserId] nvarchar(max) NOT NULL,
        [BestelDatum] datetime2 NOT NULL,
        [TotaalPrijs] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Bestellingen] PRIMARY KEY ([BestellingId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328200614_Bestellingen')
BEGIN
    CREATE INDEX [IX_WinkelmandjeItems_BestellingId] ON [WinkelmandjeItems] ([BestellingId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328200614_Bestellingen')
BEGIN
    ALTER TABLE [WinkelmandjeItems] ADD CONSTRAINT [FK_WinkelmandjeItems_Bestellingen_BestellingId] FOREIGN KEY ([BestellingId]) REFERENCES [Bestellingen] ([BestellingId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240328200614_Bestellingen')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240328200614_Bestellingen', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407085320_AddUserIdToWinkelmandjeItem')
BEGIN
    ALTER TABLE [WinkelmandjeItems] ADD [UserId] nvarchar(450) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407085320_AddUserIdToWinkelmandjeItem')
BEGIN
    CREATE INDEX [IX_WinkelmandjeItems_UserId] ON [WinkelmandjeItems] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407085320_AddUserIdToWinkelmandjeItem')
BEGIN
    ALTER TABLE [WinkelmandjeItems] ADD CONSTRAINT [FK_WinkelmandjeItems_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407085320_AddUserIdToWinkelmandjeItem')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240407085320_AddUserIdToWinkelmandjeItem', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407094535_AddBestelling')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bestellingen]') AND [c].[name] = N'TotaalPrijs');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Bestellingen] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Bestellingen] DROP COLUMN [TotaalPrijs];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407094535_AddBestelling')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bestellingen]') AND [c].[name] = N'UserId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Bestellingen] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Bestellingen] ALTER COLUMN [UserId] nvarchar(450) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407094535_AddBestelling')
BEGIN
    ALTER TABLE [Bestellingen] ADD [IsAfgerond] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407094535_AddBestelling')
BEGIN
    CREATE INDEX [IX_Bestellingen_UserId] ON [Bestellingen] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407094535_AddBestelling')
BEGIN
    ALTER TABLE [Bestellingen] ADD CONSTRAINT [FK_Bestellingen_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407094535_AddBestelling')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240407094535_AddBestelling', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407123335_AddBestelItems')
BEGIN
    ALTER TABLE [Bestellingen] DROP CONSTRAINT [FK_Bestellingen_AspNetUsers_UserId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407123335_AddBestelItems')
BEGIN
    DROP INDEX [IX_Bestellingen_UserId] ON [Bestellingen];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407123335_AddBestelItems')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bestellingen]') AND [c].[name] = N'UserId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Bestellingen] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Bestellingen] ALTER COLUMN [UserId] nvarchar(max) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407123335_AddBestelItems')
BEGIN
    CREATE TABLE [BestelItems] (
        [BestelItemId] int NOT NULL IDENTITY,
        [Aantal] int NOT NULL,
        [PrijsPerStuk] decimal(18,2) NOT NULL,
        [ProduktProductID] int NOT NULL,
        [BestellingId] int NOT NULL,
        CONSTRAINT [PK_BestelItems] PRIMARY KEY ([BestelItemId]),
        CONSTRAINT [FK_BestelItems_Bestellingen_BestellingId] FOREIGN KEY ([BestellingId]) REFERENCES [Bestellingen] ([BestellingId]) ON DELETE CASCADE,
        CONSTRAINT [FK_BestelItems_Produkten_ProduktProductID] FOREIGN KEY ([ProduktProductID]) REFERENCES [Produkten] ([ProductID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407123335_AddBestelItems')
BEGIN
    CREATE INDEX [IX_BestelItems_BestellingId] ON [BestelItems] ([BestellingId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407123335_AddBestelItems')
BEGIN
    CREATE INDEX [IX_BestelItems_ProduktProductID] ON [BestelItems] ([ProduktProductID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407123335_AddBestelItems')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240407123335_AddBestelItems', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407201628_AddPaymentAndCancellation')
BEGIN
    ALTER TABLE [Bestellingen] ADD [IsBetaald] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407201628_AddPaymentAndCancellation')
BEGIN
    ALTER TABLE [Bestellingen] ADD [IsGeannuleerd] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240407201628_AddPaymentAndCancellation')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240407201628_AddPaymentAndCancellation', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    ALTER TABLE [Produkten] ADD [ImagePath] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bestellingen]') AND [c].[name] = N'UserId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Bestellingen] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Bestellingen] ALTER COLUMN [UserId] nvarchar(450) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''soep.jpeg'', [Omschrijving] = N''Soep van de dag (zie bord)''
    WHERE [ProductID] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''stokbrood.jpeg'', [Omschrijving] = N''Stuk stokbrood (20cm)''
    WHERE [ProductID] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Boter.jpeg''
    WHERE [ProductID] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''CeasarSalad.jpeg''
    WHERE [ProductID] = 4;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''PastaKlein.jpeg'', [Omschrijving] = N''Pasta 4 kazen klein'', [ProduktNaam] = N''Pasta Klein''
    WHERE [ProductID] = 5;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''PastaGroot.jpeg'', [Omschrijving] = N''Pasta 4 kazen Groot'', [ProduktNaam] = N''Pasta Groot''
    WHERE [ProductID] = 6;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Panini.jpeg''
    WHERE [ProductID] = 7;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''BroodjeKaas.jpg'', [Omschrijving] = N''Belegd Broodje met kaas'', [ProduktNaam] = N''Broodje Kaas''
    WHERE [ProductID] = 8;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''BroodjeHam.jpeg'', [Omschrijving] = N''Belegd broodje metham'', [ProduktNaam] = N''Broodje Ham''
    WHERE [ProductID] = 9;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''BroodjeKaas-Ham.jpeg'', [Omschrijving] = N''Belegd Broodje met kaas/ham'', [ProduktNaam] = N''Broodje Kaas - Ham''
    WHERE [ProductID] = 10;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''BroodjePrepare.jpeg''
    WHERE [ProductID] = 11;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Smoske.jpeg'', [Omschrijving] = N''Smoske''
    WHERE [ProductID] = 12;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''BroodjeKipCurry.jpeg'', [Omschrijving] = N''Belegd Broodje met kip curry'', [ProduktNaam] = N''Broodje Kip Curry''
    WHERE [ProductID] = 13;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''BroodjeSurimi.jpeg'', [Omschrijving] = N''Belegd Broodje met surimi'', [ProduktNaam] = N''Broodje Surimi''
    WHERE [ProductID] = 14;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''BroodjeGerookteHam.jpeg'', [Omschrijving] = N''Belegd Broodje met gerookte ham'', [ProduktNaam] = N''Broodje Gerookte Ham''
    WHERE [ProductID] = 15;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''BroodjeGerookteZalm.jpeg'', [Omschrijving] = N''Belegd Broodje met gerookte zalm'', [ProduktNaam] = N''Broodje Gerookte Zalm''
    WHERE [ProductID] = 16;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''StukjeFruit.jpeg'', [Omschrijving] = N''Stuk fruit (Appel, Peer, Banaan, 2x kiwi)''
    WHERE [ProductID] = 17;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''PotjeYogurt.jpeg'', [Omschrijving] = N''Potje yogurt''
    WHERE [ProductID] = 18;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''HomeMadeDessert.jpeg''
    WHERE [ProductID] = 19;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''FoodbaryBerry.jpeg'', [Omschrijving] = N''Foodbar - Crazy Berry'', [ProduktNaam] = N''Foodbar Berry''
    WHERE [ProductID] = 20;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''FoodbarHealt.jpeg'', [Omschrijving] = N''Foodbar - Good Food'', [ProduktNaam] = N''Foodbar Healt''
    WHERE [ProductID] = 21;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Muffin-Donut.jpeg'', [Omschrijving] = N''Muffin of Donut'', [ProduktNaam] = N''Muffin - Donut''
    WHERE [ProductID] = 22;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Gebak.jpeg'', [Omschrijving] = N''Stukje gebak (zelf gebakken)'', [ProduktNaam] = N''Gebak''
    WHERE [ProductID] = 23;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''DessertVoorverpaktDessert.jpeg'', [Omschrijving] = N''Dessert in voorverpakking'', [ProduktNaam] = N''Voorverpakt Dessert''
    WHERE [ProductID] = 24;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Snoep.jpeg'', [Omschrijving] = N''Zakje Snoep''
    WHERE [ProductID] = 25;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''KinderBueno.jpeg'', [ProduktNaam] = N''Kinder Bueno''
    WHERE [ProductID] = 26;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Chips.jpeg'', [Omschrijving] = N''Zakje Chips'', [ProduktNaam] = N''Chips''
    WHERE [ProductID] = 27;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Chocolade.jpeg'', [Omschrijving] = N''Reep Chocolade'', [ProduktNaam] = N''Chocolade''
    WHERE [ProductID] = 28;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Smoothie.jpeg''
    WHERE [ProductID] = 29;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Chaudefontaine.jpeg''
    WHERE [ProductID] = 30;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Chaudefontaine.jpeg''
    WHERE [ProductID] = 31;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Cola.jpeg'', [ProduktNaam] = N''Cola''
    WHERE [ProductID] = 32;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Fanta.jpeg'', [ProduktNaam] = N''Fanta''
    WHERE [ProductID] = 33;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Sprite.jpeg'', [ProduktNaam] = N''Sprite''
    WHERE [ProductID] = 34;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''LiptonIce-Tea.jpeg'', [ProduktNaam] = N''Lipton Ice-Tea''
    WHERE [ProductID] = 35;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Appelsiensap.jpeg'', [ProduktNaam] = N''Appelsiensap''
    WHERE [ProductID] = 36;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Appelsap.jpeg'', [ProduktNaam] = N''Appelsap''
    WHERE [ProductID] = 37;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Cécémel.jpeg'', [ProduktNaam] = N''Cécémel''
    WHERE [ProductID] = 38;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''BlikjeNalu.jpeg'', [Omschrijving] = N''Nalu (0.25L)'', [ProduktNaam] = N''Blikje Nalu''
    WHERE [ProductID] = 39;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''Red-Bull.jpeg'', [ProduktNaam] = N''Blikje Red-Bull''
    WHERE [ProductID] = 40;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    EXEC(N'UPDATE [Produkten] SET [ImagePath] = N''ColdCoffeeToGo.jpeg'', [Omschrijving] = N''Cup koude kofie om mee te nemen'', [ProduktNaam] = N''Cold Coffee to Go''
    WHERE [ProductID] = 41;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    CREATE INDEX [IX_Bestellingen_UserId] ON [Bestellingen] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    ALTER TABLE [Bestellingen] ADD CONSTRAINT [FK_Bestellingen_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240414151019_UpdateProduktenImage')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240414151019_UpdateProduktenImage', N'6.0.10');
END;
GO

COMMIT;
GO

