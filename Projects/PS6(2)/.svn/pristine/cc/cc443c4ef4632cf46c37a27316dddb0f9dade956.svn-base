Camille Rasmussen
UID: u0717763
CS 3500

Project started on October 29, 2014
-----------------------------------
approx. 2 hours

Before beginning to code, things to consider:

- displaying contents: display "Formula" or "numerical value" or "text"?
	ended up not doing this
- only be able to edit contents from contents bar
- DO NOT forget to update cells in GUI when their contents are updated.
- Keep track of number of windows? Check out demo project
- Window to fill entire screen at start?
- Version "ps6" for every spreadsheet
- Clicking on cells? probably best option
- A1 highlighted by default - how to highlight?
	figured out this was done for us in the demo project

Error messages:

- cells unsuccessfully updated and nothing else should change
- file not loading successfully
- file not saving successfully
- reg. message asking the user if they want to save work
- automatic file dialog error messages

Implementation order:

- Open saved Spreadsheet
	file dialog and making sure file has ext. ".sprd"
- Selected cell info displayed
- Updating cells
- saving a spreadsheet
	version ps6, and again ".sprd"

November 1, 2014
----------------
approx. 1/2 hour

Figured out that I need to pass in isValid that only returns true if cell name
is one letter followed by one or more digits... for this SpreadsheetPanel obj

Catching SpreadsheetReadWriteExceptions and InvalidNameExceptions and Argument-
NullExceptions etc.
Scratch that. ArgumentNullExceptions and InvalidNameExceptions are caught in my
read/write methods in Spreadsheet and a SpreadsheetReadWriteException is thrown.

November 3, 2014 
----------------
approx. 4 hours

Almost done, last things to figure out/consider
* Formulas that reference cells not in the grid - is an exception thrown? How to handle this?
	figured out yes, and display error message
* When changing cells - make sure dependent cells update too!
* Reasons a selected cell may not be successfully edited? invalid formula, referencing a cell
	not in the table, circular dependency
* How do we handle circular dependencies?
	exception is thrown - catch it and display error message
* When the .sprd extension restriction is not imposed, just have the file try to be read? 
	(All possible exceptions are caught when reading, so we could do this)
* Adding instructions for TA's
* Adding something super rad (built-in/free tools)
* Testing of course -.-

November 4, 2014
----------------
approx. 4 hours

Ideas for super rad feature to set me apart? 
Background picture, tutorial video, background colors, 

ADDITIONAL FEATURE
Changing the background/border color of the spreadsheet. I include a dropdown box for choice
of color and label for the dropdown box. When the color is chosen in the box, the background/
border color changes.

November 5, 2014
----------------

For some reason the tests that deal with opening a file and saving a file fail. They will 
probably fail on other machines as well because file directories are different.

Previous Testing Projects branched to this project and used for testing -
From PS5

approx. 10 1/2 hrs total