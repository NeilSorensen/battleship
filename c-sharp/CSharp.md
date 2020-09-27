# Battleship

## General instructions

Replicate the general instructions here from readme.md for ease of use.

## C# Specific instructions

All the code you will need to modify is in the Battleship.AI.Strategy namespace.
Specifically, you will need to build an implementation of IBattleshipStrategy that outperforms the included NaiveBattleshipStrategy.
This shouldn't be too hard, since the NaiveBattleshipStrategy requires an average of 90+ moves to win.

Once you have a strategy that you want to simulate, you will need to change StrategyFactory to return your new strategy instead of a NaiveBattleshipStrategy.
The simulator will call GetStrategy again every time it starts a new map, so this method may be useful for resetting your state.

To run a simulation, you can execute `dotnet run -- <filename.json>` in the Battleship.AI folder.
When you are first experimenting, I recommend `dotnet run -- ../../testRuns/quickRun.json`, which contains only 10 maps.
As a baseline, the naive implementation gets the following results from the quick run:

```
Average number of turns required: 91.1
Minimum number of turns required: 84
Maximum number of turns required: 100
Standard Deviation: 6.118278625016461
Skewness (0 represents a normal distribution): 0.5469501789145725
```