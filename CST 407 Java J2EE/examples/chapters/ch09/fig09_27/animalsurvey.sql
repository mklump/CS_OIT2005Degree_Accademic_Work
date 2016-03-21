connect 'jdbc:rmi://localhost:1099/jdbc:cloudscape:animalsurvey;create=true'
;
drop table surveyresults
;

create table surveyresults (
	id int NOT NULL ,
	surveyoption varchar (20) NOT NULL ,
	votes int NOT NULL ,
	constraint surveyresults_id primary key (id)
) 
;

insert into surveyresults (id,surveyoption,votes) values (1, 'Dog', 0)
;
insert into surveyresults (id,surveyoption,votes) values (2, 'Cat', 0)
;
insert into surveyresults (id,surveyoption,votes) values (3, 'Bird', 0)
;
insert into surveyresults (id,surveyoption,votes) values (4, 'Snake', 0)
;
insert into surveyresults (id,surveyoption,votes) values (5, 'None', 0)
;
