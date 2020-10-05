import {expect} from 'chai'
import {BattleshipMap} from '../../src/ai-tester/battleship-map'
import {BattleshipSimulator} from '../../src/ai-tester/battleship-simulator'
import {BattleshipStrategyFactory} from '../../src/strategy/battleship-strategy-factory'
import {NaiveBattleshipStrategy} from '../../src/strategy/naive-battleship-strategy'

describe('When simulating battleship', () => {
  const sampleMap = '[["D","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000"],["D","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000"],["\\u0000","\\u0000","C","C","C","C","C","\\u0000","\\u0000","\\u0000"],["\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000"],["\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000"],["\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000"],["\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","S","S","S","\\u0000","c"],["\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","c"],["\\u0000","\\u0000","\\u0000","\\u0000","B","B","B","B","\\u0000","c"],["\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000"]]'

  let classUnderTest: BattleshipSimulator
  let turnCount: number
  beforeEach(() => {
    const map = new BattleshipMap()
    map.deserialize(sampleMap)
    const strategy = new NaiveBattleshipStrategy()
    classUnderTest = new BattleshipSimulator(new BattleshipStrategyFactory())
    turnCount = classUnderTest.simulateGame(map, strategy)
  })

  it('should take a deterministic number of turns', () => {
    expect(turnCount).to.equal(99)
  })
})
