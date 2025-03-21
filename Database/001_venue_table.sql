CREATE TABLE venue (
  venueId int(11) NOT NULL,
  venueName varchar(255) NOT NULL,
  venueCapacity int(11) NOT NULL
) 

ALTER TABLE venue
  ADD PRIMARY KEY (venueId);

ALTER TABLE venue 
  MODIFY COLUMN venueId INT(11) NOT NULL AUTO_INCREMENT;
