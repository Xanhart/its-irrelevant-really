--DROP TABLE Park


CREATE TABLE parks (

id							int						primary key				identity(1,1),
parkName					varchar(1000)			NOT NULL, 
parkAddress					varchar(1000)			NOT NULL, 
parkCity					varchar(1000)			NOT NULL, 
parkState					varchar(1000)			NOT NULL, 
parkZip						int						NOT NULL, 

);

INSERT INTO parks VALUES ('ParkABC','123 North st','Albuquerque','AB', 12345 );
INSERT INTO parks VALUES ('ParkDEF','456 South st','Boston','CD', 23456 );
INSERT INTO parks VALUES ('ParkGHI','789 West St','Chicago','EF', 34567 );
