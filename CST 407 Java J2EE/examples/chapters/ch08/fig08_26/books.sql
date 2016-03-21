connect 'jdbc:db2j:books;create=true'
;

drop table authorISBN
;
drop table titles
;
drop table publishers
;
drop table authors
;

create table publishers (
	publisherID int DEFAULT AUTOINCREMENT,
	publisherName varchar (30) NOT NULL,
	constraint pk_publishers primary key (publisherID)
) 
;
create table authors (
	authorID int DEFAULT AUTOINCREMENT,
	firstName varchar (20) NOT NULL,
	lastName varchar (30) NOT NULL,
	constraint pk_authors primary key (authorID)
) 
;
create table titles (
	isbn varchar (20) NOT NULL,
	title varchar (100) NOT NULL,
	editionNumber int NOT NULL,
	copyright varchar (4) NOT NULL,
	publisherID int NOT NULL,
	imageFile varchar (20) NOT NULL,
	price real NOT NULL,
	constraint fk_titles foreign key (publisherID)
		references publishers (publisherID), 
	constraint pk_titles primary key (isbn)
) 
;
create table authorISBN (
	authorID int NOT NULL,
	isbn varchar (20) NOT NULL,
	constraint fk_authorISBN_1 foreign key (authorID)
		references authors (authorID), 
	constraint fk_authorISBN_2 foreign key (isbn)
		references titles (isbn)
) 
;

insert into publishers (publisherName) values ('Prentice Hall')
;
insert into publishers (publisherName) values ('Prentice Hall PTG')
;

insert into authors (firstName,lastName) values ('Harvey','Deitel')
;
insert into authors (firstName,lastName) values ('Paul','Deitel')
;
insert into authors (firstName,lastName) values ('Tem','Nieto')
;
insert into authors (firstName,lastName) values ('Sean','Santry')
;

insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('0130895725','C How to Program',3,'2001',1,'chtp3.jpg',69.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('0132261197','C How to Program',2,'1994',1,'chtp2.jpg',49.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('0130895717','C++ How to Program',3,'2001',1,'cpphtp3.jpg',69.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID, imageFile,price) values ('0135289106','C++ How to Program',2,'1998',1,'cpphtp2.jpg',49.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('0139163050','The Complete C++ Training Course',3,'2001',2,'cppctc3.jpg',109.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('013028419x','e-Business and e-Commerce How to Program',1,'2001',1,'ebechtp1.jpg',69.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('0130161438','Internet and World Wide Web How to Program',1,'2000',1,'iw3htp1.jpg',69.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('0130856118','The Complete Internet and World Wide Web Programming Training Course',1,'2000',2,'iw3ctc1.jpg',109.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('0130125075','Java How to Program (Java 2)',3,'2000',1,'jhtp3.jpg',69.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('0138993947','Java How to Program (Java 1.1)',2,'1998',1,'jhtp2.jpg',49.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('0130852473','The Complete Java 2 Training Course',3,'2000',2,'javactc3.jpg',109.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('0130829277','The Complete Java Training Course (Java 1.1)',2,'1998',2,'javactc2.jpg',99.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('0134569555','Visual Basic 6 How to Program',1,'1999',1,'vbhtp1.jpg',69.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('0130829293','The Complete Visual Basic 6 Training Course',1,'1999',2,'vbctc1.jpg',109.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('0130284173','XML How to Program',1,'2001',1,'xmlhtp1.jpg',69.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('0130284181','Perl How to Program',1,'2001',1,'perlhtp1.jpg',69.95)
;
insert into titles (isbn,title,editionNumber,copyright,publisherID,imageFile,price) values ('0130895601','Advanced Java 2 Platform How to Program',1,'2002',1,'advjhtp1.jpg',69.95)
;

insert into authorISBN (authorID,isbn) values (1,'0130895725')
;
insert into authorISBN (authorID,isbn) values (1,'0132261197')
;
insert into authorISBN (authorID,isbn) values (1,'0130895717')
;
insert into authorISBN (authorID,isbn) values (1,'0135289106')
;
insert into authorISBN (authorID,isbn) values (1,'0139163050')
;
insert into authorISBN (authorID,isbn) values (1,'013028419x')
;
insert into authorISBN (authorID,isbn) values (1,'0130161438')
;
insert into authorISBN (authorID,isbn) values (1,'0130856118')
;
insert into authorISBN (authorID,isbn) values (1,'0130125075')
;
insert into authorISBN (authorID,isbn) values (1,'0138993947')
;
insert into authorISBN (authorID,isbn) values (1,'0130852473')
;
insert into authorISBN (authorID,isbn) values (1,'0130829277')
;
insert into authorISBN (authorID,isbn) values (1,'0134569555')
;
insert into authorISBN (authorID,isbn) values (1,'0130829293')
;
insert into authorISBN (authorID,isbn) values (1,'0130284173')
;
insert into authorISBN (authorID,isbn) values (1,'0130284181')
;
insert into authorISBN (authorID,isbn) values (1,'0130895601')
;

insert into authorISBN (authorID,isbn) values (2,'0130895725')
;
insert into authorISBN (authorID,isbn) values (2,'0132261197')
;
insert into authorISBN (authorID,isbn) values (2,'0130895717')
;
insert into authorISBN (authorID,isbn) values (2,'0135289106')
;
insert into authorISBN (authorID,isbn) values (2,'0139163050')
;
insert into authorISBN (authorID,isbn) values (2,'013028419x')
;
insert into authorISBN (authorID,isbn) values (2,'0130161438')
;
insert into authorISBN (authorID,isbn) values (2,'0130856118')
;
insert into authorISBN (authorID,isbn) values (2,'0130125075')
;
insert into authorISBN (authorID,isbn) values (2,'0138993947')
;
insert into authorISBN (authorID,isbn) values (2,'0130852473')
;
insert into authorISBN (authorID,isbn) values (2,'0130829277')
;
insert into authorISBN (authorID,isbn) values (2,'0134569555')
;
insert into authorISBN (authorID,isbn) values (2,'0130829293')
;
insert into authorISBN (authorID,isbn) values (2,'0130284173')
;
insert into authorISBN (authorID,isbn) values (2,'0130284181')
;
insert into authorISBN (authorID,isbn) values (2,'0130895601')
;


insert into authorISBN (authorID,isbn) values (3,'013028419x')
;
insert into authorISBN (authorID,isbn) values (3,'0130161438')
;
insert into authorISBN (authorID,isbn) values (3,'0130856118')
;
insert into authorISBN (authorID,isbn) values (3,'0134569555')
;
insert into authorISBN (authorID,isbn) values (3,'0130829293')
;
insert into authorISBN (authorID,isbn) values (3,'0130284173')
;
insert into authorISBN (authorID,isbn) values (3,'0130284181')
;


insert into authorISBN (authorID,isbn) values (4,'0130895601')
;
