Project started on 12/1/2014
Authors: Jessie Delacenserie and Camille Rasmussen

*******A NOTE ON TESTING*******
At the end of each of our unit tests, we close the server and sockets. However, we under-
stand that tests can begin quicker than others end and if we try to run all our tests 
together to check our code coverage, our tests throw exceptions saying only one instance 
of the server can run at one time. We run all the tests separately and they pass no 
problem. We just can't analyze code coverage.

Monday 12/1 - 2 1/2 hours
Spending time on writing a functional GUI client. Haven't run into any big problems or bugs
 yet. At the end of today we got the GUI components placed and are considering jobs of the 
 client model. In this project what is considered the Model, View, or Controller??


Tuesday 12/2 - about 6 hours
Continuing work on the model. We are getting better at the event-driven aspect of this 
project.

Questions - How do we close/disconnect the server connection??
How do we know if the server crashes? -- answered: if the string is null upon receiving 
a command from that string socket

Bug discovered today - changes to the GUI components in any callback methods must be 
invoked separately!! (So they can continue on the GUI tread)
Something else we need to update - Matthew suggested parsing commands in the model and 
registering different actions for each command to send to the view instead of sending 
the whole command to the view.
And yes, we finally figured out model-view-controller in this project.

The TA's are awesome...


Wednesday 12/3 - no time spent, but found out some advice in lab.
We need to add try-catch around our connection in the connect method - just because the 
little box pops up when connection fails does not mean we don't need to handle that 
exception!!
We should be printing out lines in our server so we can keep track of connections, 
games, disconnections etc. (this made finding problems so much easier!!)
K, XML comments on member variables, we did not know they absolutely have to have three 
///!! We were just doing a little // comment!!


Thursday 12/4 - about 5 1/2 hours
All instances where the game should reset to a connection/play page:
- Cancel button before partner is found
- Exit Game button after the game begins
- Server terminates the game (TERMINATED)
- Server crashes
- Game ends normally, and following the display of scores

Things we finished up today - 
- Trim off white space off incoming commands (beginning and endings)
- We need to look for multiple characters of white space in the our RegEx and split()
methods
- Commands are case-insensitive... do we take this into account yet?
- Oh, showing Qu for Q's!!!


Friday 12/5 - about 1 hr
Fine-tuning, commenting, README, etc. 