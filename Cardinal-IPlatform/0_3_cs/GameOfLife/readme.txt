Conway's Game of Life
---------------------
The Game of Life, also known simply as Life, is a cellular automation devised by the British mathematician John Horton Conway in 1970.

The "game" is a zero-player game, meaning that its evolution is determined by its initial state, requiring no further input. One interacts with the Game of Life by creating an initial configuration and observing how it evolves.

The universe of the Game of Life is an infinite two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, alive or dead. Every cell interacts with its eight neighbours, which are the cells that are horizontally, vertically, or diagonally adjacent. At each step in time, the following transitions occur:

Rule 1:	Any live cell with fewer than two live neighbours dies, as if caused by under-population.
Rule 2:	Any live cell with two or three live neighbours lives on to the next generation.
Rule 3:	Any live cell with more than three live neighbours dies, as if by overcrowding.
Rule 4:	Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

Read more at http://en.wikipedia.org/wiki/Conway's_Game_of_Life

What is expected in this test
-----------------------------
This test measures your object orientated development skills, working with an existing (and flawed) system and problem solving abilities.

The game has partly been implemented.

Implement the following:
1)	The GetNeighbors method in the World class
		This method returns all the neighbours for a cell located at rowNumber and cellNumber (parameters)
2)	Implement rule 4 of the game as described in the Conway's Game of Life section
3)	Implement a new rule called zombie state. If a cell is deemed to die (based on rule 1 and rule 3), but it is the first time 	the cell should die, the cell goes into a zombie state. If a cell is in zombie state and is deemed to die again (based on 		rule 1 and rule 3) the cell dies. If however the zombie cell is deemed to regenerate (based on rule 4) the cell becomes 		alive again. The existing rules (rules 1-4) treat a zombie cell as a dead cell.
4)	Implement functionality to output the world state to a text file. The output should look as follows:
		+---+---+---+---+---+---+
		|   | 0 | 1 | 2 | 3 | 4 |
		+---+---+---+---+---+---+
		| 0 |   |   |   |   |   |
		+---+---+---+---+---+---+
		| 1 |   |   |   |   |   |
		+---+---+---+---+---+---+
		| 2 |   |   |   |   |   |
		+---+---+---+---+---+---+
		| 3 |   |   |   |   |   |
		+---+---+---+---+---+---+
		| 4 |   |   |   |   |   |
		+---+---+---+---+---+---+

	a)	if a cell is alive print @
	b)	if a cell is dead print an empty cell
	c)	if a cell is a zombie state print #
5)	If you see any refactoring opportunities apply the refactoring and make us aware of the changes applied
6)	If you find a bug, log a call!!


Notes
-----
*	A log file is written by the rule instances. The log file is found in the same folder as the executable for the 				application and is called game_of_life.yyyy-mm-dd-PM/AM.log. Common.Logging in conjunction with log4net is used to generate 	the logs. The log file will be used to trace the correctness of the completed system