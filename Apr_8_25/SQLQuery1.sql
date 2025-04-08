-- create database Apr_8

-- Use the new database
--USE Apr_8;
-- GO

-- Create tables
CREATE TABLE Superheroes (
    SuperheroID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Alias NVARCHAR(100),
    FirstAppearance DATE,
    Publisher NVARCHAR(50) DEFAULT 'DC Comics'
);

CREATE TABLE Villains (
    VillainID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Alias NVARCHAR(100),
    FirstAppearance DATE,
    Publisher NVARCHAR(50) DEFAULT 'DC Comics'
);

CREATE TABLE Teams (
    TeamID INT PRIMARY KEY IDENTITY(1,1),
    TeamName NVARCHAR(100) NOT NULL,
    BaseOfOperations NVARCHAR(100)
);

CREATE TABLE VillainTeams (
    VillainTeamID INT PRIMARY KEY IDENTITY(1,1),
    TeamName NVARCHAR(100) NOT NULL,
    BaseOfOperations NVARCHAR(100)
);

CREATE TABLE Comics (
    ComicID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    IssueNumber INT,
    ReleaseDate DATE,
    SuperheroID INT,
    VillainID INT,
    FOREIGN KEY (SuperheroID) REFERENCES Superheroes(SuperheroID),
    FOREIGN KEY (VillainID) REFERENCES Villains(VillainID)
);

CREATE TABLE SuperheroTeams (
    SuperheroID INT,
    TeamID INT,
    PRIMARY KEY (SuperheroID, TeamID),
    FOREIGN KEY (SuperheroID) REFERENCES Superheroes(SuperheroID),
    FOREIGN KEY (TeamID) REFERENCES Teams(TeamID)
);

CREATE TABLE VillainTeamMemberships (
    VillainID INT,
    VillainTeamID INT,
    PRIMARY KEY (VillainID, VillainTeamID),
    FOREIGN KEY (VillainID) REFERENCES Villains(VillainID),
    FOREIGN KEY (VillainTeamID) REFERENCES VillainTeams(VillainTeamID)
);

-- Insert sample data into Superheroes table
INSERT INTO Superheroes (Name, Alias, FirstAppearance)
VALUES 
    ('Clark Kent', 'Superman', '1938-06-01'),
    ('Bruce Wayne', 'Batman', '1939-05-01'),
    ('Diana Prince', 'Wonder Woman', '1941-12-01'),
    ('Barry Allen', 'The Flash', '1956-10-01'),
    ('Hal Jordan', 'Green Lantern', '1959-07-01'),
    ('Arthur Curry', 'Aquaman', '1941-11-01'),
    ('Victor Stone', 'Cyborg', '1980-10-01'),
    ('John Constantine', 'Constantine', '1985-06-01'),
    ('Billy Batson', 'Shazam', '1940-02-01'),
    ('Oliver Queen', 'Green Arrow', '1941-11-01'),
    ('Kara Zor-El', 'Supergirl', '1959-05-01'),
    ('Jonn Jonzz', 'Martian Manhunter', '1955-11-01'),
    ('John Stewart', 'Green Lantern', '1971-12-01'),
    ('Zatanna Zatara', 'Zatanna', '1964-11-01'),
    ('Dinah Lance', 'Black Canary', '1947-08-01');

-- Insert sample data into Villains table
INSERT INTO Villains (Name, Alias, FirstAppearance)
VALUES 
    ('Lex Luthor', 'Lex Luthor', '1940-04-01'),
    ('Joker', 'Joker', '1940-04-25'),
    ('Harley Quinn', 'Harley Quinn', '1992-09-11'),
    ('Cheetah', 'Cheetah', '1943-10-01'),
    ('Black Manta', 'Black Manta', '1967-09-01'),
    ('Reverse-Flash', 'Reverse-Flash', '1963-09-01'),
    ('Sinestro', 'Sinestro', '1961-08-01'),
    ('Deathstroke', 'Deathstroke', '1980-12-01'),
    ('Darkseid', 'Darkseid', '1970-11-01'),
    ('Brainiac', 'Brainiac', '1958-07-01');

-- Insert sample data into Teams table
INSERT INTO Teams (TeamName, BaseOfOperations)
VALUES 
    ('Justice League', 'Hall of Justice'),
    ('Teen Titans', 'Titans Tower'),
    ('Suicide Squad', 'Belle Reve Penitentiary');

-- Insert sample data into VillainTeams table
INSERT INTO VillainTeams (TeamName, BaseOfOperations)
VALUES 
    ('Legion of Doom', 'Hall of Doom'),
    ('Injustice League', 'Secret Base'),
    ('Suicide Squad', 'Belle Reve Penitentiary');

-- Insert sample data into Comics table
INSERT INTO Comics (Title, IssueNumber, ReleaseDate, SuperheroID, VillainID)
VALUES 
    ('Action Comics', 1, '1938-06-01', 1, 1), -- Superman vs Lex Luthor
    ('Detective Comics', 27, '1939-05-01', 2, 2), -- Batman vs Joker
    ('Wonder Woman', 1, '1941-12-01', 3, 4), -- Wonder Woman vs Cheetah
    ('The Flash', 123, '1961-09-01', 4, 6), -- Flash vs Reverse-Flash
    ('Green Lantern', 1, '1959-07-01', 5, 7), -- Green Lantern vs Sinestro
    ('Aquaman', 35, '1967-09-01', 6, 5), -- Aquaman vs Black Manta
    ('Teen Titans', 2, '1980-12-01', 7, 8); -- Cyborg vs Deathstroke

-- Insert sample data into SuperheroTeams table
INSERT INTO SuperheroTeams (SuperheroID, TeamID)
VALUES 
    (1, 1), -- Superman in Justice League
    (2, 1), -- Batman in Justice League
    (3, 1), -- Wonder Woman in Justice League
    (4, 1), -- The Flash in Justice League
    (5, 1), -- Green Lantern in Justice League
    (6, 1), -- Aquaman in Justice League
    (7, 1), -- Cyborg in Justice League
    (8, 1), -- Constantine in Justice League
    (9, 1), -- Shazam in Justice League
    (10, 1), -- Green Arrow in Justice League
    (11, 1), -- Supergirl in Justice League
    (12, 1), -- Martian Manhunter in Justice League
    (13, 1), -- John Stewart (Green Lantern) in Justice League
    (14, 1), -- Zatanna in Justice League
    (15, 1); -- Black Canary in Justice League

-- Insert sample data into VillainTeamMemberships table
INSERT INTO VillainTeamMemberships (VillainID, VillainTeamID)
VALUES 
    (1, 1), -- Lex Luthor in Legion of Doom
    (2, 1), -- Joker in Legion of Doom
    (3, 1), -- Harley Quinn in Legion of Doom
    (4, 1), -- Cheetah in Legion of Doom
    (5, 1), -- Black Manta in Legion of Doom
    (6, 2), -- Reverse-Flash in Injustice League
    (7, 2), -- Sinestro in Injustice League
    (8, 2), -- Deathstroke in Injustice League
    (9, 2), -- Darkseid in Injustice League
    (10, 2); -- Brainiac in Injustice League

-- Insert additional comic book entries into the Comics table
INSERT INTO Comics (Title, IssueNumber, ReleaseDate, SuperheroID, VillainID)
VALUES 
    ('Superman', 75, '1992-11-18', 1, 1), -- Superman vs Lex Luthor
    ('Batman', 251, '1973-09-01', 2, 2), -- Batman vs Joker
    ('Wonder Woman', 200, '1972-05-01', 3, 4), -- Wonder Woman vs Cheetah
    ('The Flash', 139, '1963-09-01', 4, 6), -- Flash vs Reverse-Flash
    ('Green Lantern', 40, '1965-09-01', 5, 7), -- Green Lantern vs Sinestro
    ('Aquaman', 57, '1977-03-01', 6, 5), -- Aquaman vs Black Manta
    ('Teen Titans', 44, '1976-11-01', 7, 8), -- Cyborg vs Deathstroke
    ('Justice League of America', 21, '1963-08-01', 1, 9), -- Justice League vs Darkseid
    ('Justice League of America', 22, '1963-09-01', 2, 9), -- Justice League vs Darkseid
    ('Action Comics', 252, '1959-05-01', 11, 10), -- Supergirl vs Brainiac
    ('Detective Comics', 359, '1967-01-01', 2, 3), -- Batman vs Harley Quinn
    ('Wonder Woman', 329, '1986-02-01', 3, 4), -- Wonder Woman vs Cheetah
    ('The Flash', 110, '1959-12-01', 4, 6), -- Flash vs Reverse-Flash
    ('Green Lantern', 87, '1971-12-01', 5, 7), -- Green Lantern vs Sinestro
    ('Aquaman', 42, '1968-07-01', 6, 5), -- Aquaman vs Black Manta
    ('Teen Titans', 44, '1976-11-01', 7, 8), -- Cyborg vs Deathstroke
    ('Justice League of America', 29, '1964-08-01', 1, 9), -- Justice League vs Darkseid
    ('Justice League of America', 30, '1964-09-01', 2, 9), -- Justice League vs Darkseid
    ('Action Comics', 285, '1962-02-01', 11, 10), -- Supergirl vs Brainiac
    ('Detective Comics', 474, '1977-12-01', 2, 3), -- Batman vs Harley Quinn
    ('Wonder Woman', 300, '1983-02-01', 3, 4), -- Wonder Woman vs Cheetah
    ('The Flash', 140, '1963-11-01', 4, 6), -- Flash vs Reverse-Flash
    ('Green Lantern', 76, '1970-04-01', 5, 7), -- Green Lantern vs Sinestro
    ('Aquaman', 48, '1970-02-01', 6, 5), -- Aquaman vs Black Manta
    ('Teen Titans', 1, '1966-02-01', 7, 8), -- Cyborg vs Deathstroke
    ('Justice League of America', 1, '1960-11-01', 1, 9), -- Justice League vs Darkseid
    ('Justice League of America', 2, '1961-01-01', 2, 9), -- Justice League vs Darkseid
    ('Action Comics', 500, '1979-10-01', 1, 1), -- Superman vs Lex Luthor
    ('Detective Comics', 500, '1981-03-01', 2, 2), -- Batman vs Joker
    ('Wonder Woman', 1, '1987-02-01', 3, 4), -- Wonder Woman vs Cheetah
    ('The Flash', 1, '1987-06-01', 4, 6), -- Flash vs Reverse-Flash
    ('Green Lantern', 1, '1990-06-01', 5, 7), -- Green Lantern vs Sinestro
    ('Aquaman', 1, '1994-08-01', 6, 5), -- Aquaman vs Black Manta
    ('Teen Titans', 1, '1996-10-01', 7, 8), -- Cyborg vs Deathstroke
    ('Justice League', 1, '1987-05-01', 1, 9), -- Justice League vs Darkseid
    ('Justice League', 2, '1987-06-01', 2, 9), -- Justice League vs Darkseid
    ('Action Comics', 600, '1988-05-01', 1, 1), -- Superman vs Lex Luthor
    ('Detective Comics', 600, '1989-05-01', 2, 2), -- Batman vs Joker
    ('Wonder Woman', 2, '1987-03-01', 3, 4), -- Wonder Woman vs Cheetah
    ('The Flash', 2, '1987-07-01', 4, 6), -- Flash vs Reverse-Flash
    ('Green Lantern', 2, '1990-07-01', 5, 7), -- Green Lantern vs Sinestro
    ('Aquaman', 2, '1994-09-01', 6, 5), -- Aquaman vs Black Manta
    ('Teen Titans', 2, '1996-11-01', 7, 8), -- Cyborg vs Deathstroke
    ('Justice League', 3, '1987-07-01', 1, 9), -- Justice League vs Darkseid
    ('Justice League', 4, '1987-08-01', 2, 9), -- Justice League vs Darkseid
    ('Action Comics', 700, '1994-06-01', 1, 1), -- Superman vs Lex Luthor
    ('Detective Comics', 700, '1996-08-01', 2, 2), -- Batman vs Joker
    ('Wonder Woman', 3, '1987-04-01', 3, 4), -- Wonder Woman vs Cheetah
    ('The Flash', 3, '1987-08-01', 4, 6), -- Flash vs Reverse-Flash
    ('Green Lantern', 3, '1990-08-01', 5, 7), -- Green Lantern vs Sinestro
    ('Aquaman', 3, '1994-10-01', 6, 5), -- Aquaman vs Black Manta
    ('Teen Titans', 3, '1996-12-01', 7, 8), -- Cyborg vs Deathstroke
    ('Justice League', 5, '1987-09-01', 1, 9), -- Justice League vs Darkseid
    ('Justice League', 6, '1987-10-01', 2, 9), -- Justice League vs Darkseid
    ('Action Comics', 800, '2003-04-01', 1, 1), -- Superman vs Lex Luthor
    ('Detective Comics', 800, '2005-05-01', 2, 2), -- Batman vs Joker
    ('Wonder Woman', 4, '1987-05-01', 3, 4), -- Wonder Woman vs Cheetah
    ('The Flash', 4, '1987-09-01', 4, 6), -- Flash vs Reverse-Flash
    ('Green Lantern', 4, '1990-09-01', 5, 7), -- Green Lantern vs Sinestro
    ('Aquaman', 4, '1994-11-01', 6, 5), -- Aquaman vs Black Manta
    ('Teen Titans', 4, '1997-01-01', 7, 8), -- Cyborg vs Deathstroke
    ('Justice League', 7, '1987-11-01', 1, 9), -- Justice League vs Darkseid
    ('Justice League', 8, '1988-01-01', 2, 9), -- Justice League vs Darkseid
    ('Action Comics', 900, '2011-06-01', 1, 1), -- Superman vs Lex Luthor
    ('Detective Comics', 900, '2013-08-01', 2, 2), -- Batman vs Joker
    ('Wonder Woman', 5, '1987-06-01', 3, 4), -- Wonder Woman vs Cheetah
    ('The Flash', 5, '1987-10-01', 4, 6), -- Flash vs Reverse-Flash
    ('Green Lantern', 5, '1990-10-01', 5, 7), -- Green Lantern vs Sinestro
    ('Aquaman', 5, '1994-12-01', 6, 5), -- Aquaman vs Black Manta
    ('Teen Titans', 5, '1997-02-01', 7, 8), -- Cyborg vs Deathstroke
    ('Justice League', 9, '1988-02-01', 1, 9), -- Justice League vs Darkseid
    ('Justice League', 10, '1988-04-01', 2, 9), -- Justice League vs Darkseid
    ('Action Comics', 1000, '2018-04-01', 1, 1), -- Superman vs Lex Luthor
    ('Detective Comics', 1000, '2019-03-01', 2, 2), -- Batman vs Joker
    ('Wonder Woman', 6, '1987-07-01', 3, 4), -- Wonder Woman vs Cheetah
    ('The Flash', 6, '1987-11-01', 4, 6), -- Flash vs Reverse-Flash
    ('Green Lantern', 6, '1990-11-01', 5, 7), -- Green Lantern vs Sinestro
    ('Aquaman', 6, '1995-01-01', 6, 5), -- Aquaman vs Black Manta
    ('Teen Titans', 6, '1997-03-01', 7, 8), -- Cyborg vs Deathstroke
    ('Justice League', 11, '1988-05-01', 1, 9), -- Justice League vs Darkseid
    ('Justice League', 12, '1988-07-01', 2, 9); -- Justice League vs Darkseid
GO

-- Insert comic book entries for Oliver Queen (Green Arrow)
INSERT INTO Comics (Title, IssueNumber, ReleaseDate, SuperheroID, VillainID)
VALUES 
    ('Green Arrow', 1, '1983-11-01', 10, 2), -- Green Arrow vs Joker
    ('Green Arrow', 2, '1983-12-01', 10, 4), -- Green Arrow vs Cheetah
    ('Green Arrow', 3, '1984-01-01', 10, 7), -- Green Arrow vs Sinestro
    ('Green Arrow', 4, '1984-02-01', 10, 1), -- Green Arrow vs Lex Luthor
    ('Green Arrow', 5, '1984-03-01', 10, 6), -- Green Arrow vs Reverse-Flash
    ('Green Arrow', 6, '1984-04-01', 10, 9), -- Green Arrow vs Darkseid
    ('Green Arrow', 7, '1984-05-01', 10, 8), -- Green Arrow vs Deathstroke
    ('Green Arrow', 8, '1984-06-01', 10, 5), -- Green Arrow vs Black Manta
    ('Green Arrow', 9, '1984-07-01', 10, 10), -- Green Arrow vs Brainiac
    ('Green Arrow', 10, '1984-08-01', 10, 3); -- Green Arrow vs Harley Quinn
GO

-- Insert comic book entries for Zatanna Zatara
INSERT INTO Comics (Title, IssueNumber, ReleaseDate, SuperheroID, VillainID)
VALUES 
    ('Zatanna', 1, '1964-11-01', 14, 2), -- Zatanna vs Joker
    ('Zatanna', 2, '1965-01-01', 14, 4), -- Zatanna vs Cheetah
    ('Zatanna', 3, '1965-03-01', 14, 9), -- Zatanna vs Darkseid
    ('Zatanna', 4, '1965-05-01', 14, 10); -- Zatanna vs Brainiac
GO

-- Insert comic book entries for Billy Batson (Shazam)
INSERT INTO Comics (Title, IssueNumber, ReleaseDate, SuperheroID, VillainID)
VALUES 
    ('Shazam!', 1, '1940-02-01', 9, 1), -- Shazam vs Lex Luthor
    ('Shazam!', 2, '1940-04-01', 9, 2), -- Shazam vs Joker
    ('Shazam!', 3, '1940-06-01', 9, 3), -- Shazam vs Harley Quinn
    ('Shazam!', 4, '1940-08-01', 9, 4), -- Shazam vs Cheetah
    ('Shazam!', 5, '1940-10-01', 9, 5), -- Shazam vs Black Manta
    ('Shazam!', 6, '1940-12-01', 9, 6), -- Shazam vs Reverse-Flash
    ('Shazam!', 7, '1941-02-01', 9, 7), -- Shazam vs Sinestro
    ('Shazam!', 8, '1941-04-01', 9, 8), -- Shazam vs Deathstroke
    ('Shazam!', 9, '1941-06-01', 9, 9), -- Shazam vs Darkseid
    ('Shazam!', 10, '1941-08-01', 9, 10); -- Shazam vs Brainiac
GO

-- Insert comic book entries for John Constantine
INSERT INTO Comics (Title, IssueNumber, ReleaseDate, SuperheroID, VillainID)
VALUES 
    ('Hellblazer', 1, '1985-06-01', 8, 1), -- Constantine vs Lex Luthor
    ('Hellblazer', 2, '1985-07-01', 8, 2), -- Constantine vs Joker
    ('Hellblazer', 3, '1985-08-01', 8, 3), -- Constantine vs Harley Quinn
    ('Hellblazer', 4, '1985-09-01', 8, 4), -- Constantine vs Cheetah
    ('Hellblazer', 5, '1985-10-01', 8, 5); -- Constantine vs Black Manta
GO

-- Insert comic book entries for John Stewart
INSERT INTO Comics (Title, IssueNumber, ReleaseDate, SuperheroID, VillainID)
VALUES 
    ('Green Lantern Corps', 1, '1971-12-01', 13, 7), -- John Stewart vs Sinestro
    ('Green Lantern Corps', 2, '1972-01-01', 13, 6), -- John Stewart vs Reverse-Flash
    ('Green Lantern Corps', 3, '1972-02-01', 13, 8), -- John Stewart vs Deathstroke
    ('Green Lantern Corps', 4, '1972-03-01', 13, 9), -- John Stewart vs Darkseid
    ('Green Lantern Corps', 5, '1972-04-01', 13, 10), -- John Stewart vs Brainiac
    ('Green Lantern Corps', 6, '1972-05-01', 13, 1); -- John Stewart vs Lex Luthor
GO

-- Insert comic book entries for J'onn J'onzz
INSERT INTO Comics (Title, IssueNumber, ReleaseDate, SuperheroID, VillainID)
VALUES 
    ('Martian Manhunter', 1, '1955-11-01', 12, 2), -- Martian Manhunter vs Joker
    ('Martian Manhunter', 2, '1955-12-01', 12, 4), -- Martian Manhunter vs Cheetah
    ('Martian Manhunter', 3, '1956-01-01', 12, 8), -- Martian Manhunter vs Deathstroke
    ('Martian Manhunter', 4, '1956-02-01', 12, 10); -- Martian Manhunter vs Brainiac
GO

-- Insert comic book entries for Dinah Lance (Black Canary)
INSERT INTO Comics (Title, IssueNumber, ReleaseDate, SuperheroID, VillainID)
VALUES 
    ('Black Canary', 1, '1947-08-01', 15, 1), -- Black Canary vs Lex Luthor
    ('Black Canary', 2, '1947-09-01', 15, 3), -- Black Canary vs Harley Quinn
    ('Black Canary', 3, '1947-10-01', 15, 7); -- Black Canary vs Sinestro
GO

-- Query to verify data
SELECT * FROM Superheroes;
SELECT * FROM Villains;
SELECT * FROM Teams;
SELECT * FROM VillainTeams;
SELECT * FROM Comics;
SELECT * FROM SuperheroTeams;
SELECT * FROM VillainTeamMemberships;
GO


