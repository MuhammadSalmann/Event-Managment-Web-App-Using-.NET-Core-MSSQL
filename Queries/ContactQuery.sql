-- Create the Contact table
CREATE TABLE Contact (
    ContactID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    Subject NVARCHAR(100) NOT NULL,
    Message NVARCHAR(MAX) NOT NULL
);

-- Insert some dummy values into the Contact table
INSERT INTO Contact (Name, Email, Phone, Subject, Message)
VALUES 
    ('John Doe', 'john@example.com', '123-456-7890', 'Inquiry', 'This is a test message.'),
    ('Jane Smith', 'jane@example.com', '987-654-3210', 'Feedback', 'Another test message.'),
    ('Alice Johnson', 'alice@example.com', '555-555-5555', 'Support', 'Yet another test message.');
