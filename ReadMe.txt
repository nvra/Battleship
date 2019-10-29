This is a console application of Battleship for ONE Player with ONE Batleship on board.

When the application is run, first an empty placement grid and firing grid will be shown.
	> Both grids are of 10X10 size. 
	> Rows are identified by letters i.e. from A to J.
	> Columns are identified by numbers i.e. from 1 to 10.

	 	1	2	3	4	5	6	7	8	9	10/X
	A	
	B
	C
	D
	E
	F
	G
	H
	I
	J

Now the application will prompt the user to enter the 3 inputs in the below order:

1) Whether to place the battleship horizontally or vertically. 
	> It allows 'H'/'h' for horizontal layout and 'V'/'v' for Vertical layout.
	> If valid input is provided it goes to next step, else it retry for the valid input.
	> It retries for 5 times to get a valid input, in case not provided with in 5 times, application will exit.

2) Length of the Battleship
	> It allows any number between 1 to 5.
	> If valid input is provided it goes to next step, else it retry for the valid input.
	> It retries for 5 times to get a valid input, in case not provided with in 5 times, application will exit.

3) Starting position of the Battleship
	> The input format should be <Row><Col>. Eg, B1 means the starting position is in Row B and Column 1.
	> <Row> should be between A-J.
	> <Col> should be between 1-10.
	> If valid input is provided it goes to next step, else it retry for the valid input.
	> It retries for 5 times to get a valid input, in case not provided with in 5 times, application will exit.
		> Once the valid position is entered, then it checks if the battleship can be placed at that position.
		> Suppose if the length of the battleship is 5, orientation is 'H' and the start position entered is J7, 
			then battleship can't be placed at this position as the length exceeds the grid length of 10. It should be less than J6.		
		> If valid input is provided it goes to next step, else it retry for the valid input.
		> It retries for 5 times to get a valid input, in case not provided with in 5 times, application will exit.


After successfully getting all the 3 inputs, the battleship is placed on the placement grid and firing grid will be empty.
Now the game is ready to play.

	> The application gets the firing position from the User. 
	> Checks if the position is a valid position on the grid.
		> if not valid retry for 5 times before exiting.
	> if the position is valid
		> checks if the battleship is placed at that position.
			> if NO, then displays a message "MISS", and updates that position in firing grid as 'M'
			> if YES, then displays a message "HIT", and updates that position in firing grid as 'H'
	> Repeat the steps till all the positions have been "HIT".
	> if all the positions have been "HIT", then displays a message "Battleship SUNK" and the application gets exit.


