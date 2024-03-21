CREATE TABLE Bookings (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    Tickets INT NOT NULL,
    Event NVARCHAR(100) NOT NULL,
    Location NVARCHAR(100) NOT NULL
);

INSERT INTO Bookings (Name, Phone, Tickets, Event, Location)
VALUES 
    ('John Doe', '1234567890', 5, 'DJ Experience', 'London'),
    ('Jane Smith', '9876543210', 2, 'Rod Wave Concert', 'Birmingham'),
    ('Alice Johnson', '5551234567', 3, 'Easter Egg Hunt', 'Liverpool');

