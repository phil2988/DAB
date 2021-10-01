USE MASTER
GO

IF EXISTS (SELECT NAME FROM master.sys.databases WHERE NAME = N'MunicipalityDB')
DROP DATABASE MunicipalityDB
GO

CREATE DATABASE MunicipalityDB
GO

USE MunicipalityDB
GO

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Room')
CREATE TABLE [Room] (
    [roomKey] int not null,
    [_maxMembers] int,
    [_roomAvailabilityStart] time,
    [_roomAvailabilityStop] time,
    PRIMARY KEY ([roomKey])
);

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Location_Properties')
CREATE TABLE [Location_Properties] (
  [propertyId] int identity(1, 1) not null,
  [_coffeeMachine] bit,
  [_wifi] bit,
  [_whiteboard] bit,
  [_soccerGoals] bit,
  [_chairs] bit,
  [_tables] bit,
  [_soundSystem] bit,
  PRIMARY KEY ([propertyId])
);

--DROP TABLE Chairman
IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Chairman')
CREATE TABLE [Chairman] (
  [chairmanName] nvarchar(50) not null,
  [_cpr] int,
  [_adress] nvarchar(50),
  [roomKey] int,
  [locationAdress] nvarchar(50),
  PRIMARY KEY ([chairmanName])
);

--DROP TABLE Activity
IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Activity')
CREATE TABLE [Activity] (
  [activityName] nvarchar(50) not null,
  PRIMARY KEY ([activityName])
);

--DROP TABLE Municipality
IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Municipality')
CREATE TABLE [Municipality] (
  [societyCvr] int not null
);

--DROP TABLE Municipality_Location
IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Municipality_Location')
CREATE TABLE [Municipality_Location] (
  [locationAdress] nvarchar(50) not null,
  [_maxMembers] int,
  [_locationAvailabilityStart] time,
  [_locationAvailabilityStop] time,
  [roomKey] int,
  [propertyId] int,
  PRIMARY KEY ([locationAdress]),
  CONSTRAINT [FK_Municipality_Location.roomKey]
    FOREIGN KEY ([roomKey])
      REFERENCES [Room]([roomKey]) ON DELETE CASCADE,
  CONSTRAINT [FK_Municipality_Location.propertyId]
    FOREIGN KEY ([propertyId])
      REFERENCES [Location_Properties]([propertyId]) ON DELETE CASCADE
);

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Member')
CREATE TABLE [Member] (
  [memberId] int identity(1, 1) not null,
  [_name] nvarchar(50),
  [_adress] nvarchar(50),
  [_cpr] int,
  [locationAdress] nvarchar(50),
  PRIMARY KEY ([memberId]),
  CONSTRAINT [FK_Member.locationAdress]
    FOREIGN KEY ([locationAdress])
      REFERENCES [Municipality_Location]([locationAdress]) ON DELETE CASCADE
);

--DROP TABLE Society
IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Society')
CREATE TABLE [Society] (
  [societyCvr] int not null,
  [activityName] nvarchar(50),
  [chairmanName] nvarchar(50),
  [memberId] int,
  PRIMARY KEY ([societyCvr]),
  CONSTRAINT [FK_Society.activityName]
    FOREIGN KEY ([activityName])
      REFERENCES [Activity]([activityName]) ON DELETE CASCADE,
  CONSTRAINT [FK_Society.chairmanName]
    FOREIGN KEY ([chairmanName])
      REFERENCES [Chairman]([chairmanName]) ON DELETE CASCADE,
  CONSTRAINT [FK_Society.memberId]
    FOREIGN KEY ([memberId])
      REFERENCES [Member]([memberId]) ON DELETE CASCADE
);