connect 'jdbc:rmi://localhost:1099/jdbc:cloudscape:tips;create=true'
;

drop table tipInfo
;

create table tipInfo (
	tipID int DEFAULT AUTOINCREMENT,
	tipName varchar (255) NOT NULL,
	tipDescription varchar (255) NOT NULL,
	tipImage varchar (255) NOT NULL,
	shortName varchar (255) NOT NULL
	)
;

insert into tipInfo (tipName, tipDescription, tipImage, shortName) values ('Good Programming Practice', 
   'Good Programming Practices call the student&apos;s attention to techniques that help produce better programs.',
   'goodProgramming', 'GPP')
;

insert into tipInfo (tipName, tipDescription, tipImage, shortName) values ('Common Programming Error', 
   'Students learning a language tend to make certain kinds of errors frequently. Focusing on these Common Programming Errors helps students avoid making the same errors.',
   'programmingError', 'CPE')
;

insert into tipInfo (tipName, tipDescription, tipImage, shortName) values ('Look-and-Feel Observation', 
   'We provide Look-and-Feel Observations to highlight graphical user interface conventions. These observations help students design their own graphical user interfaces to conform with industry norms.',
   'lookAndFeel', 'LAF')
;

insert into tipInfo (tipName, tipDescription, tipImage, shortName) values ('Performance Tip', 
   'Performance Tips highlight opportunities for improving program performance',
   'perf', 'PERF')
;

insert into tipInfo (tipName, tipDescription, tipImage, shortName) values ('Portability Tip', 
   'Organizations that develop software must often produce versions customized to a variety of computers and operating systems. These tips offer suggestions to make your applications more portable.',
   'portability', 'PORT')
;

insert into tipInfo (tipName, tipDescription, tipImage, shortName) values ('Software Engineering Observation', 
   'The Software Engineering Observations highlight techniques, architectural issues and design issues, etc. that affect the architecture and construction of software systems, especially large-scale systems.',
   'softwareEngineering', 'SEO')
;

insert into tipInfo (tipName, tipDescription, tipImage, shortName) values ('Testing and Debugging Tip', 
   'Most of these tips tend to be observations about capabilities and features that prevent bugs from getting into programs in the first place.',
   'testingDebugging', 'TAD')
;