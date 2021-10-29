USE MASTER
GO

IF EXISTS (SELECT NAME FROM master.sys.databases WHERE NAME = N'au653164')
DROP DATABASE au653164
GO

IF NOT EXISTS (SELECT NAME FROM master.sys.databases WHERE NAME = N'au653164')
CREATE DATABASE au653164
GO

USE au653164
GO

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Location_Properties')
CREATE TABLE [Location_Properties] (
  [propertyId] int identity(1, 1) not null,
  [_coffeeMachine] bit,
  [_toilet] bit,
  [_water] bit,
  [_chairs] bit,
  [_wifi] bit,
  [_whiteboard] bit,
  [_soccerGoals] bit,
  [_tables] bit,
  [_soundSystem] bit,
  PRIMARY KEY ([propertyId])
);

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Chairman')
CREATE TABLE [Chairman] (
  [chairmanName] nvarchar(50) not null,
  [_cpr] bigint,
  [_adress] nvarchar(50),
  [roomKey] int,
  [locationAdress] nvarchar(50),
  PRIMARY KEY ([chairmanName])
);

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Activity')
CREATE TABLE [Activity] (
  [activityName] nvarchar(50) not null,
  PRIMARY KEY ([activityName])
);

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Municipality_Location')
CREATE TABLE [Municipality_Location] (
  [locationAdress] nvarchar(50) not null,
  [_maxMembers] int,
  [_locationAvailabilityStart] time,
  [_locationAvailabilityStop] time,
  [propertyId] int,
  PRIMARY KEY ([locationAdress]),
  CONSTRAINT [FK.Municipality_Location.propertyId]
    FOREIGN KEY ([propertyId])
      REFERENCES [Location_Properties]([propertyId])
);

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Room')
CREATE TABLE [Room] (
    [roomId] int identity(1, 1) not null,
    [_roomKey] int not null,
    [_maxMembers] int,
    [_roomAvailabilityStart] time,
    [_roomAvailabilityStop] time,
    [_bookedByName] nvarchar(50),
    [_bookedBySociety] nvarchar(50),
    [_bookedStart] time,
    [_bookedStop] time,
    [locationAdress] nvarchar(50) not null,
    PRIMARY KEY ([roomId]),
    CONSTRAINT [FK_Room.locationAdress]
     FOREIGN KEY ([locationAdress])
      REFERENCES [Municipality_Location] ([locationAdress])
);

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Member')
CREATE TABLE [Member] (
  [memberId] int identity(1, 1) not null,
  [roomId] int,
  [_name] nvarchar(50),
  [_adress] nvarchar(50),
  [_cpr] bigint,
  [locationAdress] nvarchar(50),
  PRIMARY KEY ([memberId]),
  CONSTRAINT [FK_Member.locationAdress]
    FOREIGN KEY ([locationAdress])
      REFERENCES [Municipality_Location]([locationAdress]),
  CONSTRAINT [FK_Member.roomId]
   FOREIGN KEY ([roomId])
    REFERENCES [Room] ([roomId])
);

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Society')
CREATE TABLE [Society] (
  [societyCvr] bigint not null,
  [_societyName] nvarchar(50) not null,
  [_societyAdress] nvarchar(50) not null,
  [activityName] nvarchar(50),
  [chairmanName] nvarchar(50),
  PRIMARY KEY ([societyCvr]),
  CONSTRAINT [FK_Society.activityName]
    FOREIGN KEY ([activityName])
      REFERENCES [Activity]([activityName]),
  CONSTRAINT [FK_Society.chairmanName]
    FOREIGN KEY ([chairmanName])
      REFERENCES [Chairman]([chairmanName]),
);

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Municipality')
CREATE TABLE[SocietyMemberRelations](
  [societyCvr] bigint not null,
  [memberId] int not null,

  FOREIGN KEY (societyCvr)
   REFERENCES [Society] ([societyCvr]),
  FOREIGN KEY (memberId)
   REFERENCES [Member] ([memberId]),
  UNIQUE (memberId, societyCvr)
);

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Municipality')
CREATE TABLE [Municipality] (
  [societyCvr] bigint not null
  CONSTRAINT [FK_Municipality.societyCvr]
    FOREIGN KEY ([societyCvr])
      REFERENCES [Society]([societyCvr]),
);

