import {Command, flags} from '@oclif/command'
import {readFile} from 'fs'
import {BattleshipSimulator} from './ai-tester/battleship-simulator'
import {BattleshipStrategyFactory} from './strategy/battleship-strategy-factory'

class TestAi extends Command {
  static description = 'describe the command here'

  static flags = {
    // add --version flag to show CLI version
    version: flags.version({char: 'v'}),
    help: flags.help({char: 'h'}),
  }

  static args = [{name: 'file'}]

  async run() {
    const {args} = this.parse(TestAi)

    const name = 'world'
    this.log(`hello ${name} from .\\src\\index.ts`)
    if (!args.file) {
      this.log('File required')
      return
    }

    readFile(args.file, (err, data) => {
      if (err) {
        this.log(`Error reading file: ${err}`)
      }
      const allMaps = JSON.parse(data.toString())
      const simulator = new BattleshipSimulator(new BattleshipStrategyFactory())
      simulator.simulateGameSet(allMaps, this.log)
    })
  }
}

export = TestAi
