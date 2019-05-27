
INSERT INTO Courses (Id, Discriminator, Code, VideoUrl) VALUES
	(NEWID(), 'OnlineCourse', 'ONLINE_COURSE_1', 'http://sampleurl.com')
	
INSERT INTO Courses (Id, Discriminator, Code, Address) VALUES
	(NEWID(), 'ClassRoomCourse', 'ROOM_COURSE_1', 'Vallromanes')

INSERT INTO Students (Id, Name, Email) VALUES
	(NEWID(), 'Student 1', 'student1@itequia.com'),
	(NEWID(), 'Student 2', 'student2@itequia.com')

INSERT INTO CourseStudents (CourseId, StudentId, Score) VALUES
	((SELECT TOP 1 Id FROM Courses WHERE Code = 'ONLINE_COURSE_1'), (SELECT TOP 1 Id FROM Students WHERE Email = 'student1@itequia.com'), NULL),
	((SELECT TOP 1 Id FROM Courses WHERE Code = 'ROOM_COURSE_1'), (SELECT TOP 1 Id FROM Students WHERE Email = 'student2@itequia.com'), NULL)

