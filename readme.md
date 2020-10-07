For this exercise, we'll be building an AI to play the classic board game `Battleship`.
In the `testRuns` folder, there are a number of different files that contain 1000 randomly generated battleship maps.
At the end of the excercise, we will roll a dice to determine which of those files everyone will evaluate their AI against.
The lowest average number of turns will win.

# Rules

First, a quick reminder of the rules of the game battleship.

The single player variant (which we will be using) takes place on a 10x10 map.
Classically, grid coordinates are defined by a letter-number combination, but for the purposes of this exercise, we will be using X and Y coordinates.
Both X and Y are 0 based, with 0,0 representing the bottom left hand corner of the map.

The map contains five hidden ships (of lengths 5, 4, 3, 3, and 2), oriented in straight lines on the map grid. 
Ships may not be placed on diagonals, and may not overlap, but they _may_ be adjacent.

Each turn, the player will choose one space to shoot.
They will then be informed of the result of their shot, which will either be hit, miss, or sink (when a given ship has no more un-hit spaces on the map).
Play continues until all of the spaces occupied by ships have been hit.

# Implementation details

Language specific implementation details are included in their respective folders, but there are a few things that are the same across both implementations.

You will need to implement a single method that takes as an argument the result of your last shot. 
You should return the next space you want to shoot next.
Because of this, there is a fourth result that can be passed to this method, none, which will be passed for the first shot of a new game.

All implementations also include a console application that takes as an argument a file with a number of maps.
When run, this application will simulate each of the games in the file, and return statistics about how many turns your AI took to win.
Specifics about how to run this are included in the implementation readme.
If you want to test this initially, `testRuns\quickRun.json` is a good file to use (it contains only 10 maps, and so will run quickly).