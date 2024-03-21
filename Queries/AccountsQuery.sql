CREATE TABLE Accounts (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);

INSERT INTO Accounts (Name, Email, Password, Role) VALUES
('Tia', 'admin@example.com', 'admin', 'admin'),
('Jane Smith', 'jane@example.com', 'password456', 'user'),
('Alice Johnson', 'alice@example.com', 'password789', 'user');
