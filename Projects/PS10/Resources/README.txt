Project started on 12/8/2014
Authors: Jessie Delacenserie and Camille Rasmussen

Monday 12/8 -- 3 hrs
Today we set up the tables in our database and set up the connection.
We had to run several updates on MySQL Workbench so this step took a little longer than expected.

Wednesday 12/10 -- 4 hrs
Today we modified our server to send data to our tables in teh database.
We wrote 3 helper methods, each of which could send a command to insert data into one of the three tables
we had set up. These helper methods were called each time we sent right after the game ended, before the
final data was sent to the client. As we collected the lists of words for the final game summary we sent that
data to the database. This might not be the most efficient way, but it worked and we will go back later to modify
if time allows. Now that we are writing to the database correctly we need to focus on sending the html.

Thursday 12/11 -- 5 1/2 hrs
Today was a big day and we are almost done with the html - it deals with the database a lot more than we had 
initially anticipated. We have now learned html!!!
Questions for the TA today:
- We have a bit in the table for true/false in 'valid' column - just pas in 1 ok?
- Does Visual Studio DateTime match MySql DateTime? -- Conclusion: ended up just passing in a string
- How can we check the tables after the server has added info to it? Look at it in Workbench? -- Conclusion: yes!
- Does the primary key get automagically generated? -- Conclusion: yes!
Matthew also suggested splitting up some of our queries that were trying to do multiple things.

Friday 12/12 -- 3 hrs
Finishing up the project - today we are finishing the last bit of html pages and need to write the database 
description!
Note: queries seem redundant sometimes... wish there was one to select a row where column = x or y???

TOTAL HRS SPENT -- about 15 1/2


----------------------
DATABASE DESCRIPTION!!
----------------------
Tables: 

game_info - contains all the relevant information pertaining to a specific game ID
		columns: game_ID (Primary Key), player1_ID, player2_ID, date_time, board_config (the 16 letters that went on the board, 
		time_limit (in seconds of the game), player1_score, player2_score
player_info - contains all the relevant information pertaining to a specific player ID
		columns: ID (Primary Key), p_name (player name), wins (for this player), losses (also), ties (also)
words_played - contains all words ever played in Boggle and which player played it, in which game, and if it is legal
		columns: word, game_ID (that this word was played in), player_ID (of the player who played the word), legal (bit 0 for 
		false, 1 for true), word_ID (Primary Key)

Our database has 3 main tables that serve for basic functionality for our 3 main html pages. Occasionaly the html page will request 
data from another table and we will accomodate using IDs for either games or players. (These ID's act as primary keys that auto- 
increment, we have one for words_played table as well to allow for editing the table, but we don't access it in the code.)

Data Queries Used:
In SendServerStatsPage, in BoggleServer.cs
	This query "SELECT * FROM player_info"
	We create a reader to grab specific things from each row that is returned. We save the name, number of wins, losses, and ties 
	into a local variable in our program for usage when sending the html page.

In SendGameInfoPage
	This query "SELECT * FROM game_info WHERE game_id = {0};", gameID
	Again we create a reader to grab specific things from each row that is returned. We save each player's ID's, the date/time, the 
	16 board letters, the game's time limit, and each player's scores into a local variable in our program for usage when sending 
	the html page.
In same method
	This query "SELECT p_name FROM player_info WHERE ID = {0};", p1ID
	Get this player's name using their ID we got from game_info query
In same method
	This query "SELECT p_name FROM player_info WHERE ID = {0};", p2ID
	Get this player's name using their ID we got from game_info query
In same method
	This query "SELECT * FROM words_played WHERE game_ID = {0}", gameID
	Again we create a reader to grab all the words and attributes (who played it, in what game, legal or not) and we store them in 
	a list of tuples of words and their attributes.

In SendPlayerInfoPage
	This query "SELECT count(*) FROM player_info WHERE p_name = '{0}'", playerName
	We are first checking to see if the player exists in the database, and if it doesn't, we report that to the web page.
In same method
	This query "SELECT ID FROM player_info WHERE p_name = '{0}'", playerName
	Get this player's ID using their name we got from parameter
In same method
	This query "SELECT * FROM game_info WHERE player1_ID = {0}", playerID
	Get the information for all the games where this player has been player 1
In same method
	This query "SELECT * FROM game_info WHERE player2_ID = {0}", playerID
	Get the information for all the games where this player has been player 2
In same method
	This query "SELECT p_name FROM player_info WHERE ID = {0}", game.Item3
	All the names of the players that were opponents to our player, using their game ID

In InsertWordInfo
	This query "INSERT INTO words_played (word, game_ID, player_ID, legal) VALUES ('{0}', {1}, {2}, {3});", word, gameID, playerID, valid
	Insert each word and which game it was played in, who played it, and wether or not it was legal, into the words_played table

In InsertGameInfo
	This query "INSERT INTO game_info (player1_ID, player2_ID, date_time, board_config, time_limit, player1_score, player2_score) VALUES 
		({0}, {1}, '{2}', '{3}', {4}, {5}, {6});", id1, id2, dateNtime, gameBoard, gameLength, score1, score2
	Here we are inserting all the game information from the end of the game into the game_info table, like the player ID's, the date/time, 
	the scores, and the 16 letters from the boggle board that was just played on.
In same method
	This query "SELECT last_insert_id();"
	We are getting the game ID that was just generated for us when we added the game to the table.

In InsertPlayerInfo
	This query "SELECT count(*) FROM player_info WHERE p_name = '{0}'", name
	Here we are checking to see if the username is in the table by seeing the count. If it is 0, we add them. If not, we just update the 
	other columns.
In same method
	This query "INSERT INTO player_info (p_name) VALUES ('{0}');", name
	We simply insert the player name into the table under the p_name column and a new player ID is generated automagically for us.
In same method
	This query "UPDATE player_info SET {0} = {0} + 1 WHERE p_name = '{1}'", outcome, name
	Incrementing the appropriate column with the outcome, which will be either 'wins', 'losses', or 'ties'.
In same method
	This query "SELECT ID FROM player_info WHERE p_name = '{0}'", name
	We get the auto-generated player ID from the player name.

----------------------
NOTES ON WRITING HTML
----------------------
- SERVER STATS:
	- we realized it would be easier to send wins/losses/ties to the web server if they were saved that way
		in the database, so we added 3 columns to our player_info table and incremented the wins/losses/ties
		columns accordingly as each game ended
	- with the altered player_info table, this page was pretty straightforward by creating one table

- PARTIC. PLAYER:
	- this page was also straightforward because almost all of the info we needed for the table was in the 
		game_info table of our database
	- the only complication was that the player we wanted could be player 1 or player 2 so we had to execute
		2 queries in the database to get all games that a player participated in

- SPEC. GAME:
	- this was the hardest page to format, though mostly simple to get the data for since it was all easily accessible
		from the game_info table
	- the 5-part summary was the most complicated because it required us to go into words_played for each player
		in the game, then compare every word to make sure they were not common between the players (since they 
		were not stored that way in the database)
	- once we figured that out we managed to basically make the whole page a table so that the different items
		could be placed next to each other instead of just listing everything down the page -- pretty tricky
		for someone who has never done html!

Final Notes on HTML:
	- we added the top title bars to add some color and structure to our page, to give it that little extra
		"oomph"
	- we also added links to every game number and name on each page, also links to the main page as that seemed
		like it would be useful to the user