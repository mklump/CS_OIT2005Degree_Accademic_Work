connect 'jdbc:rmi://localhost:1099/jdbc:cloudscape:addressbook;create=true'
;

drop table addresses
;
drop table phoneNumbers
;
drop table emailAddresses
;
drop table names
;

create table names (
	personID int DEFAULT AUTOINCREMENT,
	firstName varchar (30) NOT NULL,
	lastName varchar (30) NOT NULL,
	constraint pk_name primary key (personID)
) 
;
create table addresses (
	addressID int DEFAULT AUTOINCREMENT,
        personID int NOT NULL,
	address1 varchar (50),
	address2 varchar (50),
	city varchar (30),
	state varchar (2),
	zipcode varchar (10),
	constraint fk_addresses foreign key (personID)
		references names (personID),
	constraint pk_addresses primary key (addressID)
) 
;
create table phoneNumbers (
	phoneID int DEFAULT AUTOINCREMENT,
        personID int NOT NULL,
	phoneNumber varchar (20),
	constraint fk_phoneNumbers foreign key (personID)
		references names (personID),
	constraint pk_phoneNumbers primary key (phoneID)
) 
;
create table emailAddresses (
	emailID int DEFAULT AUTOINCREMENT,
        personID int NOT NULL,
	emailAddress varchar (50),
	constraint fk_emailAddresses foreign key (personID)
		references names (personID),
	constraint pk_emailAddresses primary key (emailID)
) 
;
