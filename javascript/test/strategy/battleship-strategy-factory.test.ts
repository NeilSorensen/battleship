import {expect} from 'chai'
import {BattleshipStrategyFactory} from '../../src/strategy/battleship-strategy-factory'
import {NaiveBattleshipStrategy} from '../../src/strategy/naive-battleship-strategy'

describe('Battleship Strategy Factory', () => {
  let classUnderTest: BattleshipStrategyFactory
  beforeEach(() => {
    classUnderTest = new BattleshipStrategyFactory()
  })

  it('should create a NaiveBattleshipStrategy', () => {
    expect(classUnderTest.getStrategy()).to.be.instanceOf(NaiveBattleshipStrategy)
  })
})
