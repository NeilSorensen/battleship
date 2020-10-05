import {max, mean, min, sampleSkewness, standardDeviation} from 'simple-statistics'
import {FireResult} from '../fire-result'
import {Point} from '../point'
import {BattleshipStrategy} from '../strategy/battleship-strategy'
import {BattleshipStrategyFactory} from '../strategy/battleship-strategy-factory'
import {BattleshipMap} from './battleship-map'

export class BattleshipSimulator {
  strategyFactory: BattleshipStrategyFactory

  constructor(strategyFactory: BattleshipStrategyFactory) {
    this.strategyFactory = strategyFactory
  }

  simulateGame(map: BattleshipMap, strategy: BattleshipStrategy): number {
    let turnCount = 0
    let result = FireResult.None
    let nextTarget: Point
    do {
      turnCount++
      nextTarget = strategy.nextMove(result)
      result = map.shoot(nextTarget.x, nextTarget.y)
    } while (!map.hasWon())
    return turnCount
  }

  simulateGameSet(maps: string[], log: (message: string) => void) {
    const turnCounts: number[] = []
    maps.forEach(mapString => {
      const map = new BattleshipMap()
      map.deserialize(mapString)
      const strategy = this.strategyFactory.getStrategy()
      const turnCount = this.simulateGame(map, strategy)
      turnCounts.push(turnCount)
    })
    const stats = this.generateStatistics(turnCounts)
    log(`Simulated ${turnCounts.length} games of battleship. Results follow:`)
    log(`Min: ${stats.minimum}`)
    log(`Max: ${stats.maximum}`)
    log(`Mean: ${stats.mean}`)
    log(`Standard Deviation: ${stats.standardDeviation}`)
    log(`Skewness: ${stats.skewness}`)
  }

  private generateStatistics(turnCounts: number[]): SampleStats {
    return {
      minimum: min(turnCounts),
      maximum: max(turnCounts),
      mean: mean(turnCounts),
      standardDeviation: standardDeviation(turnCounts),
      skewness: sampleSkewness(turnCounts),
    }
  }
}

interface SampleStats {
  minimum: number;
  maximum: number;
  mean: number;
  standardDeviation: number;
  skewness: number;
}
