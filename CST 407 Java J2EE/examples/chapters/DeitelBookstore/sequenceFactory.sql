connect 'jdbc:rmi://localhost:1099/jdbc:cloudscape:Bookstore;create=true';

insert into SequenceFactory (tableName, nextID) values ('Customer','0');
insert into SequenceFactory (tableName, nextID) values ('Address','0');
insert into SequenceFactory (tableName, nextID) values ('CustomerOrders','0');
