# [CSCI321 Marble Game](https://github.com/00bayz/csci321_marblegame)

[ Requirements ]

- [x] Create custom analog stopwatch control
	- [x] Must be a control that can be put on any form
		- [x] Size of the control is determined by where it is used
	- [x] Must make use of two separate dials with different center points
		- [x] Small dial for minutes
		- [x] Large dial for seconds
	- [x] Must have the following features:
		- [x] Method to **Start** the stopwatch
		- [x] Method to **Stop** the stopwatch
		- [x] Method to **Pause** the stopwatch
		- [x] Method to **Reset** the stopwatch
		- [x] Property to get the number of elasped seconds
		- [x] Property to get the number of elapsed minutes
	- [x] Must start running after use selects their MRB file
	- [x] Must stop when the puzzle is solved

- [x] Create a **pause** button
	- [x] On click to pause:
		- [x] Hide the puzzle
		- [x] Pause the stopwatch
	- [x] On click to resume:
		- [x] Show the puzzle
		- [x] Resume the stopwatch

- [x] Create a leaderboard
	- [x] Must list top five performances, each including the following:
		- [x] Name
		- [x] Number of moves
		- [x] Time to solve puzzle
	- [x] Leaderboard file should be named "puzzle.bin" and use the Serialized format discussed in class
	- [x] Leaderboard file should be saved in corresponding MRB file
	- [x] Listings should be ordered first by the **number of moves** and then by the **time** it took to solve

