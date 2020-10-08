test-ai
=======

# Javascript Specific instructions

All the code you will need to modify is in `src/strategy`.
Specifically, you will need to build an implementation of BattleshipStrategy that outperforms the included NaiveBattleshipStrategy.
This shouldn't be too hard, since the NaiveBattleshipStrategy requires an average of 90+ moves to win.

Once you have a strategy that you want to simulate, you will need to change BattleshipStrategyFactory to return your new strategy instead of a NaiveBattleshipStrategy.
The simulator will call getStrategy again every time it starts a new map, so this method may be useful for resetting your state.

To test your battleship strategy against a map file, you'll first need to run `npm run prepack`.
This will compile your typescript into an oclif executable.
Then you can run `command/run [filename]` to simulate games for each map in the file.
I recommend starting with `command/run ../testRuns/quickRun.json` to verify that everything is hooked up with a small dataset.
With the NaiveBattleshipStrategy, here's the output you should expect:
```
hello world from .\src\index.ts
Simulated 10 games of battleship. Results follow:
Min: 84
Max: 100
Mean: 91.1
Standard Deviation: 5.80430874437258
Skewness: 0.5469501789145763
```

# Oclif generated stuff

[![oclif](https://img.shields.io/badge/cli-oclif-brightgreen.svg)](https://oclif.io)
[![License](https://img.shields.io/npm/l/test-ai.svg)](https://github.com/NeilSorensen/battleship/blob/master/package.json)

<!-- toc -->
* [Usage](#usage)
* [Commands](#commands)
<!-- tocstop -->
# Usage
<!-- usage -->
```sh-session
$ npm install -g test-ai
$ test-ai COMMAND
running command...
$ test-ai (-v|--version|version)
test-ai/0.1.0 win32-x64 node-v12.16.1
$ test-ai --help [COMMAND]
USAGE
  $ test-ai COMMAND
...
```
<!-- usagestop -->
# Commands
<!-- commands -->

<!-- commandsstop -->
