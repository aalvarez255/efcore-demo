﻿
INSERT INTO Courses (Id, Discriminator, Code, VideoUrl) VALUES
	(NEWID(), 'OnlineCourse', 'ONLINE_COURSE_1', 'http://sampleurl.com'),
	(NEWID(), 'OnlineCourse', 'ONLINE_COURSE_2', 'http://sampleurl.com'),
	(NEWID(), 'OnlineCourse', 'ONLINE_COURSE_3', 'http://sampleurl.com'),
	(NEWID(), 'OnlineCourse', 'ONLINE_COURSE_4', 'http://sampleurl.com'),
	(NEWID(), 'OnlineCourse', 'ONLINE_COURSE_5', 'http://sampleurl2.com'),
	(NEWID(), 'OnlineCourse', 'ONLINE_COURSE_6', 'http://sampleurl2.com'),
	(NEWID(), 'OnlineCourse', 'ONLINE_COURSE_7', 'http://sampleurl2.com'),
	(NEWID(), 'OnlineCourse', 'ONLINE_COURSE_8', 'http://sampleurl2.com')
	
INSERT INTO Courses (Id, Discriminator, Code, Address) VALUES
	(NEWID(), 'ClassRoomCourse', 'ROOM_COURSE_1', 'Vallromanes'),
	(NEWID(), 'ClassRoomCourse', 'ROOM_COURSE_2', 'Vallromanes'),
	(NEWID(), 'ClassRoomCourse', 'ROOM_COURSE_3', 'Vallromanes'),
	(NEWID(), 'ClassRoomCourse', 'ROOM_COURSE_4', 'Vallromanes'),
	(NEWID(), 'ClassRoomCourse', 'ROOM_COURSE_5', 'Vallromanes'),
	(NEWID(), 'ClassRoomCourse', 'ROOM_COURSE_6', 'Vallromanes'),
	(NEWID(), 'ClassRoomCourse', 'ROOM_COURSE_7', 'Vallromanes'),
	(NEWID(), 'ClassRoomCourse', 'ROOM_COURSE_8', 'Vallromanes')

INSERT INTO Students (Id, Name, Email) VALUES
	(NEWID(), 'Student 1', 'student1@itequia.com'),
	(NEWID(), 'Student 2', 'student2@itequia.com'),
	(NEWID(), 'Student 3', 'student3@itequia.com'),
	(NEWID(), 'Student 4', 'student4@itequia.com'),
	(NEWID(), 'Student 5', 'student5@itequia.com'),
	(NEWID(), 'Student 6', 'student6@itequia.com'),
	(NEWID(), 'Student 7', 'student7@itequia.com'),
	(NEWID(), 'Student 8', 'student8@itequia.com'),
	(NEWID(), 'Student 9', 'student9@itequia.com'),
	(NEWID(), 'Student 10', 'student10@itequia.com')
	
INSERT INTO StudentAddress (Id, Address, City, State, Country, StudentId) VALUES
	(NEWID(), 'Test Address 1', 'Barcelona', NULL, 'Spain', (SELECT TOP 1 ID FROM STUDENTS WHERE Name = 'Student 1')),
	(NEWID(), 'Test Address 2', 'Barcelona', NULL, 'Spain', (SELECT TOP 1 ID FROM STUDENTS WHERE Name = 'Student 2')),
	(NEWID(), 'Test Address 3', 'Barcelona', NULL, 'Spain', (SELECT TOP 1 ID FROM STUDENTS WHERE Name = 'Student 3')),
	(NEWID(), 'Test Address 4', 'Barcelona', NULL, 'Spain', (SELECT TOP 1 ID FROM STUDENTS WHERE Name = 'Student 4')),
	(NEWID(), 'Test Address 5', 'Barcelona', NULL, 'Spain', (SELECT TOP 1 ID FROM STUDENTS WHERE Name = 'Student 5')),
	(NEWID(), 'Test Address 6', 'Barcelona', NULL, 'Spain', (SELECT TOP 1 ID FROM STUDENTS WHERE Name = 'Student 6')),
	(NEWID(), 'Test Address 7', 'Barcelona', NULL, 'Spain', (SELECT TOP 1 ID FROM STUDENTS WHERE Name = 'Student 7')),
	(NEWID(), 'Test Address 8', 'Barcelona', NULL, 'Spain', (SELECT TOP 1 ID FROM STUDENTS WHERE Name = 'Student 8')),
	(NEWID(), 'Test Address 9', 'Barcelona', NULL, 'Spain', (SELECT TOP 1 ID FROM STUDENTS WHERE Name = 'Student 9')),
	(NEWID(), 'Test Address 10', 'Barcelona', NULL, 'Spain', (SELECT TOP 1 ID FROM STUDENTS WHERE Name = 'Student 10'))

INSERT INTO CourseStudents (CourseId, StudentId, Score) VALUES
	((SELECT TOP 1 Id FROM Courses WHERE Code = 'ONLINE_COURSE_1'), (SELECT TOP 1 Id FROM Students WHERE Email = 'student1@itequia.com'), NULL),
	((SELECT TOP 1 Id FROM Courses WHERE Code = 'ROOM_COURSE_1'), (SELECT TOP 1 Id FROM Students WHERE Email = 'student2@itequia.com'), NULL)

