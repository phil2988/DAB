USE au653164
GO


INSERT INTO Location_Properties(_toilet, _water, _chairs, _coffeeMachine, _soccerGoals, _soundSystem, _tables, _whiteboard, _wifi)
VALUES
(1, 1, 1, 1, 0, 1, 1, 1, 1),
(1, 1, 1, 1, 0, 0, 1, 1, 1),
(1, 1, 1, 0, 1, 1, 0, 0, 1)


INSERT INTO Chairman(chairmanName, _adress, _cpr) 
VALUES
('Bo Bjerring','Stenløsegyden 18', 1103583159),
('Abellona B. Frederiksen','Søndergade 58', 0311761552),
('Rosa M. Winther','Havnegade 6', 0305921246)


INSERT INTO Activity(activityName) 
VALUES
('Fodbold'),
('Hånbold'),
('Skak'),
('Videospil'),
('Dart')


INSERT INTO Municipality_Location(locationAdress, propertyId, _maxMembers, _locationAvailabilityStart, _locationAvailabilityStop) 
VALUES
('Manchester gade 22', (SELECT propertyId FROM Location_Properties WHERE propertyId = 1), 100, '10:00:00', '21:00:00'),
('Åboulevarden 22', (SELECT propertyId FROM Location_Properties WHERE propertyId = 2), 100, '10:00:00', '21:00:00'),
('Strandalléen 29', (SELECT propertyId FROM Location_Properties WHERE propertyId = 3), 40, '10:00:00', '18:00:00')

INSERT INTO Room(locationAdress, _roomKey,_maxMembers, _roomAvailabilityStart, _roomAvailabilityStop) 
VALUES 
('Manchester gade 22', 1, 10, '10:00:00', '18:00:00'),
('Manchester gade 22', 2, 15, '10:00:00', '18:00:00'),
('Manchester gade 22', 3, 20, '10:00:00', '23:00:00'),
('Manchester gade 22', 4, 5, '10:00:00', '10:00:00'),
('Manchester gade 22', 5, 12, '10:00:00', '15:00:00'),
('Åboulevarden 22', 1, 10, '12:00:00', '21:00:00'),
('Åboulevarden 22', 2, 15, '12:00:00', '21:00:00'),
('Strandalléen 29', 1, 10, '15:00:00', '21:00:00')

INSERT INTO Member(_name, _adress, _cpr) 
VALUES
('Bo Johnson', 'Ligustervænget 23', 4216333547),
('Torben M. Berg', 'Møllevænget 96', 2309941546),
('Aase N. Petersen', 'Eskelundsvej 86', 3006543196),
('Abellona R. Bach', 'Søndergade 92', 0503734192),
('Rikke A. Vestergaard', 'Byvej 81', 0901662886),
('Celina M. Bertelsen', 'Skolegyden 89', 0710874972),
('Tobias L. Bach', 'Kamperhoug 52', 2108680965),
('Nicklas A. Jensen', 'Kohaven 75', 1310801077),
('Helena J. Holst', 'Ribelandevej 39', 0109920614),
('Torben K. Kruse', 'Mellemvej 21', 2402453187)


INSERT INTO Society(societyCvr, _societyName, _societyAdress, activityName, chairmanName) 
VALUES 
(5882819528, 'Gamma Alfa', 'Adelgade 5', (SELECT activityName FROM Activity where activityName = 'Skak'),
(SELECT chairmanName FROM Chairman where chairmanName = 'Bo Bjerring')),
(1222834281, 'Beta Zeta', 'Skolegyden 94', (SELECT activityName FROM Activity where activityName = 'Videospil'), 
(SELECT chairmanName FROM Chairman where chairmanName = 'Abellona B. Frederiksen')),
(9963727657, 'Epsilon Alfa', 'Nyborgvej 61', (SELECT activityName FROM Activity where activityName = 'Fodbold'), 
(SELECT chairmanName FROM Chairman where chairmanName = 'Rosa M. Winther'))


INSERT INTO SocietyMemberRelations(societyCvr, memberId) 
VALUES
((SELECT societyCvr FROM Society WHERE _societyName = 'Gamma Alfa'), (SELECT memberId FROM Member WHERE memberId = 2)),
((SELECT societyCvr FROM Society WHERE _societyName = 'Gamma Alfa'), (SELECT memberId FROM Member WHERE memberId = 1)),
((SELECT societyCvr FROM Society WHERE _societyName = 'Gamma Alfa'), (SELECT memberId FROM Member WHERE memberId = 7)),
((SELECT societyCvr FROM Society WHERE _societyName = 'Gamma Alfa'), (SELECT memberId FROM Member WHERE memberId = 10)),
((SELECT societyCvr FROM Society WHERE _societyName = 'Gamma Alfa'), (SELECT memberId FROM Member WHERE memberId = 5)),
((SELECT societyCvr FROM Society WHERE _societyName = 'Beta Zeta'), (SELECT memberId FROM Member WHERE memberId = 1)),
((SELECT societyCvr FROM Society WHERE _societyName = 'Beta Zeta'), (SELECT memberId FROM Member WHERE memberId = 6)),
((SELECT societyCvr FROM Society WHERE _societyName = 'Beta Zeta'), (SELECT memberId FROM Member WHERE memberId = 8)),
((SELECT societyCvr FROM Society WHERE _societyName = 'Beta Zeta'), (SELECT memberId FROM Member WHERE memberId = 7)),
((SELECT societyCvr FROM Society WHERE _societyName = 'Epsilon Alfa'), (SELECT memberId FROM Member WHERE memberId = 9)),
((SELECT societyCvr FROM Society WHERE _societyName = 'Epsilon Alfa'), (SELECT memberId FROM Member WHERE memberId = 3)),
((SELECT societyCvr FROM Society WHERE _societyName = 'Epsilon Alfa'), (SELECT memberId FROM Member WHERE memberId = 4))


INSERT INTO Municipality(societyCvr) 
VALUES
((SELECT societyCvr FROM Society WHERE societyCvr = 5882819528)),
((SELECT societyCvr FROM Society WHERE societyCvr = 1222834281)),
((SELECT societyCvr FROM Society WHERE societyCvr = 9963727657))

INSERT INTO Room(locationAdress, _roomKey, _bookedStart, _bookedStop, _bookedByName, _bookedBySociety)
VALUES
('Manchester gade 22', 1, '10:00:00', '13:00:00', 'Bo Johnson', 'Beta Zeta'),
('Manchester gade 22', 1, '14:00:00', '16:00:00', 'Rikke A. Vestergaard', 'Gamma Alfa'),
('Manchester gade 22', 1, '16:00:00', '18:00:00', 'Torben K. Kruse', 'Gamma Alfa')
