USE au653164
GO

-- Selects all data on rooms and their adresses
SELECT 
	_roomKey, locationAdress 
FROM 
	room

-- Get cvr, adresses and chairmen by society activity
SELECT 
	activityName, societyCvr, _societyAdress, chairmanName  
FROM 
	Society

-- Get booked rooms, time booked, and booked by
SELECT 
	Room._roomKey, Room._bookedStart, Room._bookedStop, Room.locationAdress, 
	Room._bookedByName, _bookedBySociety
FROM 
	Room
WHERE 
	Room._bookedByName IS NOT NULL