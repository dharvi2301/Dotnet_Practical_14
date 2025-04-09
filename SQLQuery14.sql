CREATE DATABASE Employee_Db_Practical_14;

CREATE TABLE Employee14 (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name VARCHAR(50) NOT NULL,
    DOB DATE NOT NULL,
    Age INT NULL
);

 INSERT INTO [Employee14] ([Name], [DOB], [Age]) VALUES
('Alice Johnson', '1990-05-12', 34),
('Bob Smith', '1985-03-22', 39),
('Cathy Lee', '1992-07-18', 32),
('David Brown', '1988-11-30', 36),
('Eva Green', '1991-01-25', 33),
('Frank Moore', '1983-06-15', 41),
('Grace King', '1995-04-10', 29),
('Harry White', '1987-09-01', 37),
('Isla Black', '1993-12-05', 31),
('Jack Wilson', '1989-08-20', 35),
('Kelly Turner', '1994-03-17', 30),
('Leo Scott', '1996-10-08', 28),
('Mia Adams', '1990-12-12', 34),
('Nathan Hall', '1986-02-27', 38),
('Olivia Clark', '1991-07-01', 33),
('Peter Young', '1984-04-03', 40),
('Quinn Walker', '1992-11-11', 32),
('Rachel Harris', '1993-05-25', 31),
('Sam Mitchell', '1987-10-19', 37),
('Tina Edwards', '1989-01-29', 35),
('Umar Patel', '1995-09-14', 29),
('Vera Cooper', '1990-02-09', 34),
('William Reed', '1986-06-30', 38),
('Xena Foster', '1993-08-03', 31),
('Yusuf Khan', '1994-12-21', 30),
('Zara Lopez', '1991-06-06', 33),
('Alan Wright', '1988-02-12', 36),
('Bianca Morris', '1992-04-23', 32),
('Carlos Diaz', '1995-07-09', 29),
('Diana Stone', '1989-11-03', 35);
