-- Creazione della tabella Clienti
CREATE TABLE Clients (
    ClientID INT PRIMARY KEY IDENTITY(1,1),
    Code NVARCHAR(50) NOT NULL,
    Surname NVARCHAR(50) NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    City NVARCHAR(50),
    Province NVARCHAR(50),
    Email NVARCHAR(50),
    Phone NVARCHAR(15),
    Mobile NVARCHAR(15)
);

-- Creazione della tabella Camere
CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomNumber NVARCHAR(10) NOT NULL,
    Description NVARCHAR(255),
    Type NVARCHAR(50) -- singola, doppia
);

-- Creazione della tabella Prenotazioni
CREATE TABLE Reservations (
    ReservationID INT PRIMARY KEY IDENTITY(1,1),
    ClientID INT FOREIGN KEY REFERENCES Clients(ClientID),
    RoomID INT FOREIGN KEY REFERENCES Rooms(RoomID),
    ReservationDate DATE NOT NULL,
    ProgressiveNumber INT NOT NULL,
    Year INT NOT NULL,
    StayFrom DATE NOT NULL,
    StayTo DATE NOT NULL,
    Deposit DECIMAL(10, 2) NOT NULL,
    RateApplied DECIMAL(10, 2) NOT NULL,
    Details NVARCHAR(255) -- mezza pensione, pensione completa, pernottamento con colazione
);

-- Creazione della tabella ServiziAggiuntivi
CREATE TABLE AdditionalServices (
    ServiceID INT PRIMARY KEY IDENTITY(1,1),
    ReservationID INT FOREIGN KEY REFERENCES Reservations(ReservationID),
    ServiceName NVARCHAR(50),
    ServiceDate DATE,
    Quantity INT,
    Price DECIMAL(10, 2)
);

-- Creazione della tabella DettagliPrenotazione per memorizzare i dettagli del checkout
CREATE TABLE ReservationDetails (
    DetailID INT PRIMARY KEY IDENTITY(1,1),
    ReservationID INT FOREIGN KEY REFERENCES Reservations(ReservationID),
    RoomNumber NVARCHAR(10),
    Period NVARCHAR(50),
    RateApplied DECIMAL(10, 2),
    AdditionalServicesList NVARCHAR(MAX),
    TotalAmountToPay DECIMAL(10, 2)
);