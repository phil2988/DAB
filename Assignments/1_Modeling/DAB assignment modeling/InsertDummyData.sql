USE au653164
GO


INSERT INTO Room(_roomKey,_maxMembers, _roomAvailabilityStart, _roomAvailabilityStop) VALUES (1, 10, '10:00:00', '18:00:00')
INSERT INTO Room(_roomKey,_maxMembers, _roomAvailabilityStart, _roomAvailabilityStop) VALUES (2, 15, '10:00:00', '18:00:00')
INSERT INTO Room(_roomKey,_maxMembers, _roomAvailabilityStart, _roomAvailabilityStop) VALUES (3, 20, '10:00:00', '23:00:00')
INSERT INTO Room(_roomKey,_maxMembers, _roomAvailabilityStart, _roomAvailabilityStop) VALUES (4, 5, '10:00:00', '10:00:00')
INSERT INTO Room(_roomKey,_maxMembers, _roomAvailabilityStart, _roomAvailabilityStop) VALUES (5, 12, '10:00:00', '15:00:00')
INSERT INTO Room(_roomKey,_maxMembers, _roomAvailabilityStart, _roomAvailabilityStop) VALUES (1, 10, '12:00:00', '21:00:00')
INSERT INTO Room(_roomKey,_maxMembers, _roomAvailabilityStart, _roomAvailabilityStop) VALUES (2, 15, '12:00:00', '21:00:00')
INSERT INTO Room(_roomKey,_maxMembers, _roomAvailabilityStart, _roomAvailabilityStop) VALUES (1, 10, '15:00:00', '21:00:00')


INSERT INTO Location_Properties(_chairs, _coffeeMachine, _soccerGoals, _soundSystem, _tables, _whiteboard, _wifi)
VALUES(1, 1, 0, 1, 1, 1, 1)
INSERT INTO Location_Properties(_chairs, _coffeeMachine, _soccerGoals, _soundSystem, _tables, _whiteboard, _wifi)
VALUES(1, 1, 0, 0, 1, 1, 1)
INSERT INTO Location_Properties(_chairs, _coffeeMachine, _soccerGoals, _soundSystem, _tables, _whiteboard, _wifi)
VALUES(1, 0, 1, 1, 0, 0, 1)


INSERT INTO Chairman(_adress, _cpr) VALUES('Goddreng alé', 2562818525)


INSERT INTO Activity(activityName) VALUES('Fodbold')
INSERT INTO Activity(activityName) VALUES('Hånbold')
INSERT INTO Activity(activityName) VALUES('Skak')
INSERT INTO Activity(activityName) VALUES('Videospil')
INSERT INTO Activity(activityName) VALUES('Dart')


INSERT INTO Municipality_Location(locationAdress, propertyId, _maxMembers, _locationAvailabilityStart, _locationAvailabilityStop) 
VALUES('Manchester gade 22', )

INSERT INTO Member(_name, _adress, _cpr) VALUES('Bo Johnson', 'Ligustervænget 23', 4216333547)