# MiniMax TicTacToe

Following 2 hours the code was complete and (mostly) tested but the solution hadn't yet been hosted.  
Also, there were bugs! :(

**Known issues:**

i. The Game Over check omits checking for a winning condition (bug not feature) so some moves by 'o' won't be optimal!  
e.g. input:  `++++xx++o` -> output: `++++xxo+o`

ii. Currently, there is no validation that the board is in an illegal state because of an incorrect number of pieces.  
e.g. The following does not result in a Bad Request (400), input: `++x+xx++o`  
 
 **TODO:**
 
 * Add winning condition check to Game Over function
 * Check valid number of pieces for each player on board
 
 **Possible enhancements:**
 
 * Optimise first move played by 'o' given an empty board
 * Use generative testing (potentially) to brute force test implementation
 * Caching moves for performance
 * Varying board dimensions, etc
