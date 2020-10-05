import {BattleshipStrategy} from './battleship-strategy'
import {NaiveBattleshipStrategy} from './naive-battleship-strategy'

export class BattleshipStrategyFactory {
  getStrategy(): BattleshipStrategy {
    return new NaiveBattleshipStrategy()
  }
}
