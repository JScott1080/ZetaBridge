-- Messages table: stores all chat messages
CREATE TABLE Messages (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL,
    Channel TEXT NOT NULL,
    MessageText TEXT NOT NULL,
    Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Pinned messages: references Messages
CREATE TABLE PinnedMessages (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    MessageId INTEGER NOT NULL,
    PinnedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (MessageId) REFERENCES Messages(Id)
);

-- Announcements: streamer-created messages
CREATE TABLE Announcements (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Text TEXT NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Polls: question + options
CREATE TABLE Polls (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Question TEXT NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Poll votes: linked to Polls
CREATE TABLE PollVotes (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    PollId INTEGER NOT NULL,
    Username TEXT NOT NULL,
    VoteOption TEXT NOT NULL,
    VotedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (PollId) REFERENCES Polls(Id)
);