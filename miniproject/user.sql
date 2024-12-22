use mini_project

CREATE TABLE Tickets (
    TicketID INT IDENTITY(1,1) PRIMARY KEY, -- Unique ticket ID
    TrainNo INT NOT NULL, -- Foreign key to Trains table
    PassengerName NVARCHAR(50) NOT NULL,
    PassengerAge INT NOT NULL,
    ClassType NVARCHAR(20) CHECK (ClassType IN ('First', 'Second', 'Sleeper')), -- Ticket class
    NumberOfSeats INT NOT NULL,
    --BookingDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (TrainNo) REFERENCES Trains(TrainNo)
);
alter table tickets add IsActive bit default 1;
select * from tickets

--tickets booking
CREATE OR ALTER PROCEDURE SP_BookTicket
    @TrainNo INT,
    @PassengerName NVARCHAR(50),
    @PassengerAge INT,
    @ClassType NVARCHAR(20),
    @NumberOfSeats INT
AS
BEGIN
    -- Check if the train exists and is active
    IF NOT EXISTS (SELECT 1 FROM Trains WHERE TrainNo = @TrainNo AND IsActive = 1)
    BEGIN
        RAISERROR ('Train does not exist or is inactive.', 16, 1);
        RETURN;
    END;
 
    -- Check seat availability
    IF (@ClassType = 'First' AND @NumberOfSeats > (SELECT first_class_available FROM Trains WHERE TrainNo = @TrainNo)) OR
       (@ClassType = 'Second' AND @NumberOfSeats > (SELECT second_class_available FROM Trains WHERE TrainNo = @TrainNo)) OR
       (@ClassType = 'Sleeper' AND @NumberOfSeats > (SELECT sleeper_class_available FROM Trains WHERE TrainNo = @TrainNo))
    BEGIN
        RAISERROR ('Not enough seats available.', 16, 1);
        RETURN;
    END;
 
    -- Deduct seats and book ticket
    IF (@ClassType = 'First')
    BEGIN
        UPDATE Trains SET first_class_available = first_class_available - @NumberOfSeats WHERE TrainNo = @TrainNo;
    END
    ELSE IF (@ClassType = 'Second')
    BEGIN
        UPDATE Trains SET second_class_available = second_class_available - @NumberOfSeats WHERE TrainNo = @TrainNo;
    END
    ELSE IF (@ClassType = 'Sleeper')
    BEGIN
        UPDATE Trains SET sleeper_class_available = sleeper_class_available - @NumberOfSeats WHERE TrainNo = @TrainNo;
    END;
 
    -- Insert ticket into Tickets table
    INSERT INTO Tickets (TrainNo, PassengerName, PassengerAge, ClassType, NumberOfSeats)
    VALUES (@TrainNo, @PassengerName, @PassengerAge, @ClassType, @NumberOfSeats);
 
    PRINT 'Ticket booked successfully.';
END;






--CANCEL TICKET


CREATE OR ALTER PROCEDURE SP_CancelTicket
    @TicketID INT
AS
BEGIN
    -- Check if the ticket exists
    IF NOT EXISTS (SELECT 1 FROM Tickets WHERE TicketID = @TicketID)
    BEGIN
        RAISERROR ('Ticket does not exist.', 16, 1);
        RETURN;
    END;
 
    -- Retrieve ticket details
    DECLARE @TrainNo INT, @ClassType NVARCHAR(20), @NumberOfSeats INT;
    SELECT @TrainNo = TrainNo, @ClassType = ClassType, @NumberOfSeats = NumberOfSeats
    FROM Tickets WHERE TicketID = @TicketID;
 
    -- Update seat availability in the Trains table
    IF (@ClassType = 'First')
    BEGIN
        UPDATE Trains SET first_class_available = first_class_available + @NumberOfSeats WHERE TrainNo = @TrainNo;
    END
    ELSE IF (@ClassType = 'Second')
    BEGIN
        UPDATE Trains SET second_class_available = second_class_available + @NumberOfSeats WHERE TrainNo = @TrainNo;
    END
    ELSE IF (@ClassType = 'Sleeper')
    BEGIN
        UPDATE Trains SET sleeper_class_available = sleeper_class_available + @NumberOfSeats WHERE TrainNo = @TrainNo;
    END;
 
    -- Delete the ticket
	update Tickets set IsActive =0 
    --DELETE FROM Tickets
	WHERE TicketID = @TicketID;
 
    PRINT 'Ticket canceled successfully.';
END;



CREATE OR ALTER PROCEDURE SP_ShowBookings
AS
BEGIN
    SELECT
        T.TicketID,
        T.PassengerName,
        T.PassengerAge,
        T.ClassType,
        T.NumberOfSeats,
        Tr.TrainNo,
        Tr.TrainName,
        Tr.Source,
        Tr.Destination,
        T.IsActive AS BookingStatus -- 1 for active, 0 for canceled
    FROM Tickets T
    JOIN Trains Tr ON T.TrainNo = Tr.TrainNo
    ORDER BY T.TicketID;
END;






 
   select * from Tickets
   select * from  trains