# CSCI321 Marble Game

[ Requirements ]

- [ ] Create custom analog stopwatch control
	- [ ] Must be a control that can be put on any form
		- [ ] Size of the control is determined by where it is used
	- [ ] Must make use of two separate dials with different center points
		- [ ] Small dial for minutes
		- [ ] Large dial for seconds
	- [ ] Must have the following features:
		- [ ] Method to **Start** the stopwatch
		- [ ] Method to **Stop** the stopwatch
		- [ ] Method to **Pause** the stopwatch
		- [ ] Method to **Reset** the stopwatch
		- [ ] Property to get the number of elasped seconds
		- [ ] Property to get the number of elapsed minutes
	- [ ] Must start running after use selects their MRB file
	- [ ] Must stop when the puzzle is solved

- [ ] Create a **pause** button
	- [ ] On click to pause:
		- [ ] Hide the puzzle
		- [ ] Pause the stopwatch
	- [ ] On click to resume:
		- [ ] Show the puzzle
		- [ ] Resume the stopwatch

- [ ] Create a leaderboard
	- [ ] Must list top five performances, each including the following:
		- [ ] Name
		- [ ] Number of moves
		- [ ] Time to solve puzzle
	- [ ] Leaderboard file should be named "puzzle.bin" and use the Serialized format discussed in class
	- [ ] Listings should be ordered first by the **number of moves** and then by the **time** it took to solve

