-- Create the database and switch to it
CREATE DATABASE weedingorganizerfinal;
GO
USE weedingorganizerfinal

-- 1. User Data Table
CREATE TABLE UserData (
    ID INT PRIMARY KEY IDENTITY(1, 1),
    UserName VARCHAR(255) UNIQUE,
    Password VARCHAR(255) NOT NULL,
    Role VARCHAR(50) NOT NULL,
    SignUpDate DATE NOT NULL,
    UpdatedDate DATE
);

-- 2. Payment Table
CREATE TABLE Payment (
    ID INT PRIMARY KEY IDENTITY,
    CreditCardNumber VARCHAR(16) NOT NULL,
    CVV VARCHAR(4) NOT NULL,
    ExpiryDate DATE NOT NULL
);

-- 3. Customers Table
CREATE TABLE Customers (
    ID INT PRIMARY KEY,
    Address TEXT,
    PaymentID INT,
    Budget DECIMAL(10, 2) NOT NULL DEFAULT 0,
    FOREIGN KEY (ID) REFERENCES UserData(ID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (PaymentID) REFERENCES Payment(ID) ON DELETE SET NULL ON UPDATE NO ACTION
);

-- 4. Hall Provider Table
CREATE TABLE HallProvider (
    HallID INT IDENTITY(1,1),
    ProvID INT,
    HallName VARCHAR(255) NOT NULL,
    Location TEXT NOT NULL,
    Capacity INT NOT NULL,
    Size DECIMAL(10, 2),
    PRIMARY KEY (HallID, ProvID),
    FOREIGN KEY (ProvID) REFERENCES UserData(ID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- 5. Request Table
CREATE TABLE Request (
    ID INT PRIMARY KEY IDENTITY(1, 1),
    CustomerID INT,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    Date DATE NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    HallID INT,
    ProvID INT,
    DuePayment DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(ID) ON DELETE CASCADE ON UPDATE NO ACTION,
    FOREIGN KEY (HallID, ProvID) REFERENCES HallProvider(HallID, ProvID) ON DELETE NO ACTION ON UPDATE NO ACTION
);

-- 6. Request Payment Table
CREATE TABLE RequestPayment (
    RequestID INT,
    CustomerID INT,
    Amount DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (RequestID, CustomerID),
    FOREIGN KEY (RequestID) REFERENCES Request(ID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(ID) ON DELETE NO ACTION ON UPDATE NO ACTION
);

-- 7. Guest List Table
CREATE TABLE GuestList (
    ID INT IDENTITY(1, 1) PRIMARY KEY,
    RequestID INT,
    GuestName VARCHAR(255) NOT NULL,
    Phone VARCHAR(20),
    Address TEXT,
    FOREIGN KEY (RequestID) REFERENCES Request(ID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- 8. Transportation Table
CREATE TABLE Transportation (
    ID INT IDENTITY(1, 1) PRIMARY KEY,
    Type VARCHAR(255),
    Serving_Location TEXT NOT NULL,
    Rating DECIMAL(3, 2),
    RequestID INT,
    FOREIGN KEY (RequestID) REFERENCES Request(ID) ON DELETE SET NULL ON UPDATE CASCADE
);

-- 9. Caterer Table
CREATE TABLE Caterer (
    ID INT PRIMARY KEY,
    Rating DECIMAL(3, 2),
    FOREIGN KEY (ID) REFERENCES UserData(ID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- 10. Menu Option Table
CREATE TABLE MenuOption (
    CatererID INT,
    Fname VARCHAR(255),
    Price DECIMAL(10, 2),
    PRIMARY KEY (CatererID, Fname),
    FOREIGN KEY (CatererID) REFERENCES Caterer(ID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- 11. Menu Requests Table
CREATE TABLE MenuRequests (
    RequestID INT,
    Fname VARCHAR(255),
    CatererID INT,
    Quantity INT,
    PRIMARY KEY (RequestID, Fname, CatererID),
    FOREIGN KEY (RequestID) REFERENCES Request(ID) ON DELETE CASCADE,
    FOREIGN KEY (CatererID, Fname) REFERENCES MenuOption(CatererID, Fname)
);

-- 12. Entertainers Table
CREATE TABLE Entertainers (
    ID INT PRIMARY KEY,
    Name VARCHAR(255),
    Type VARCHAR(255),
    Price_Per_Hour INT NOT NULL,
    FOREIGN KEY (ID) REFERENCES UserData(ID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- 13. Musician Table
CREATE TABLE Musician (
    EntertainerID INT PRIMARY KEY,
    BandName VARCHAR(255),
    Genre VARCHAR(255),
    FOREIGN KEY (EntertainerID) REFERENCES Entertainers(ID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- 14. Florists Table
CREATE TABLE Florists (
    EntertainerID INT PRIMARY KEY,
    Arrangement TEXT,
    FOREIGN KEY (EntertainerID) REFERENCES Entertainers(ID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- 15. Photographer Table
CREATE TABLE Photographer (
    EntertainerID INT PRIMARY KEY,
    Camera VARCHAR(255),
    FOREIGN KEY (EntertainerID) REFERENCES Entertainers(ID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- 16. Entertainment Request Table
CREATE TABLE EntertainmentRequest (
    RequestID INT,
    EntertainersID INT,
    Type VARCHAR(255),
    PRIMARY KEY (RequestID, EntertainersID),
    FOREIGN KEY (RequestID) REFERENCES Request(ID) ,
    FOREIGN KEY (EntertainersID) REFERENCES Entertainers(ID)
);

-- 1. UserData Table
INSERT INTO UserData (UserName, Password, Role, SignUpDate, UpdatedDate)
VALUES
    ('user1', 'password1', 'Admin', '2023-04-01', '2023-04-01'),
    ('user2', 'password2', 'Customer', '2023-04-02', '2023-04-02'),
    ('user3', 'password3', 'HallProvider', '2023-04-03', '2023-04-03'),
    ('user4', 'password4', 'Caterer', '2023-04-04', '2023-04-04'),
    ('user5', 'password5', 'Entertainer', '2023-04-05', '2023-04-05');

-- 2. Payment Table
INSERT INTO Payment (CreditCardNumber, CVV, ExpiryDate)
VALUES
    ('1234567890123456', '123', '2025-06-30'),
    ('9876543210987654', '456', '2026-12-31'),
    ('5678901234567890', '789', '2027-03-31');

-- 3. Customers Table
INSERT INTO Customers (ID, Address, PaymentID, Budget)
VALUES
    (2, '123 Main St, Anytown USA', 1, 10000.00),
    (3, '456 Oak Rd, Somewhere City', 2, 15000.00),
    (4, '789 Elm St, Nowhere Town', 3, 20000.00);

-- 4. HallProvider Table
INSERT INTO HallProvider (ProvID, HallName, Location, Capacity, Size)
VALUES
    (3, 'Grand Hall', '123 Main St, Anytown USA', 500, 5000.00),
    (3, 'Elegant Ballroom', '456 Oak Rd, Somewhere City', 300, 3000.00),
    (3, 'Spacious Venue', '789 Elm St, Nowhere Town', 400, 4000.00);

-- 5. Request Table
INSERT INTO Request (CustomerID, StartTime, EndTime, Date, Price, HallID, ProvID, DuePayment)
VALUES
    (2, '10:00:00', '16:00:00', '2023-06-01', 5000.00, 1, 3, 5000.00),
    (3, '14:00:00', '20:00:00', '2023-07-15', 7500.00, 2, 3, 7500.00),
    (4, '12:00:00', '18:00:00', '2023-08-20', 6000.00, 3, 3, 6000.00);

-- 6. RequestPayment Table
INSERT INTO RequestPayment (RequestID, CustomerID, Amount)
VALUES
    (1, 2, 5000.00),
    (2, 3, 7500.00),
    (3, 4, 6000.00);

-- 7. GuestList Table
INSERT INTO GuestList (RequestID, GuestName, Phone, Address)
VALUES
    (1, 'John Doe', '123-456-7890', '123 Main St, Anytown USA'),
    (1, 'Jane Smith', '987-654-3210', '456 Oak Rd, Somewhere City'),
    (2, 'Bob Johnson', '555-555-5555', '789 Elm St, Nowhere Town');

-- 8. Transportation Table
INSERT INTO Transportation (Type, Serving_Location, Rating, RequestID)
VALUES
    ('Limousine', '123 Main St, Anytown USA', 4.8, 1),
    ('Party Bus', '456 Oak Rd, Somewhere City', 4.5, 2),
    ('Shuttle Service', '789 Elm St, Nowhere Town', 4.2, 3);

-- 9. Caterer Table
INSERT INTO Caterer (ID, Rating)
VALUES
    (4, 4.7),
    (5, 4.9);

-- 10. MenuOption Table
INSERT INTO MenuOption (CatererID, Fname, Price)
VALUES
    (4, 'Grilled Salmon', 35.00),
    (4, 'Roasted Chicken', 25.00),
    (5, 'Vegetarian Lasagna', 30.00),
    (5, 'Beef Tenderloin', 45.00);

-- 11. MenuRequests Table
INSERT INTO MenuRequests (RequestID, Fname, CatererID, Quantity)
VALUES
    (1, 'Grilled Salmon', 4, 50),
    (1, 'Roasted Chicken', 4, 75),
    (2, 'Vegetarian Lasagna', 5, 60),
    (2, 'Beef Tenderloin', 5, 40);

-- 12. Entertainers Table
INSERT INTO Entertainers (ID, Name, Type, Price_Per_Hour)
VALUES
    (1, 'The Rockstars', 'Band', 500),
    (2, 'Floral Arrangements', 'Florist', 200),
    (3, 'Snap Shots', 'Photographer', 300);

-- 13. Musician Table
INSERT INTO Musician (EntertainerID, BandName, Genre)
VALUES
    (1, 'The Rockstars', 'Rock');

-- 14. Florists Table
INSERT INTO Florists (EntertainerID, Arrangement)
VALUES
    (2, 'Elegant Floral Arrangements');


-- 16. EntertainmentRequest Table
INSERT INTO EntertainmentRequest (RequestID, EntertainersID, Type)
VALUES
    (1, 1, 'Band'),
    (2, 2, 'Florist');