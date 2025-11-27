-- Get latest 10 messages
SELECT * FROM Messages ORDER BY Timestamp DESC LIMIT 10;

-- Get pinned messages
SELECT m.Username, m.MessageText, p.PinnedAt
FROM PinnedMessages p
JOIN Messages m ON p.MessageId = m.Id;

-- Get poll results
SELECT VoteOption, COUNT(*) AS Votes
FROM PollVotes
WHERE PollId = 1
GROUP BY VoteOption;