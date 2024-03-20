CREATE TABLE Accounts (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);

INSERT INTO Accounts (Id, Name, Email, Password, Role) VALUES
(1, 'Salman', 'admin@example.com', 'admin', 'admin'),
(2, 'Jane Smith', 'jane@example.com', 'password456', 'user'),
(3, 'Alice Johnson', 'alice@example.com', 'password789', 'user');
