import {expect} from 'chai'
import {BattleshipMap} from '../../src/ai-tester/battleship-map'
import {FireResult} from '../../src/fire-result'

describe('battleshipMap', () => {
  const sampleMap = '[["D","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000"],["D","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000"],["\\u0000","\\u0000","C","C","C","C","C","\\u0000","\\u0000","\\u0000"],["\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000"],["\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000"],["\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000"],["\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","S","S","S","\\u0000","c"],["\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","c"],["\\u0000","\\u0000","\\u0000","\\u0000","B","B","B","B","\\u0000","c"],["\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000","\\u0000"]]'
  let classUnderTest: BattleshipMap
  beforeEach(() => {
    classUnderTest = new BattleshipMap()
  })

  describe('deserialize', () => {
    beforeEach(() => {
      classUnderTest.deserialize(sampleMap)
    })

    it('should end up with the right size', () => {
      expect(classUnderTest.size()).to.be.equal(10)
    })
  })

  describe('when shooting', () => {
    beforeEach(() => {
      classUnderTest.deserialize(sampleMap)
    })

    describe('when shooting an empty space', () => {
      let result: FireResult
      beforeEach(() => {
        result = classUnderTest.shoot(0, 1)
      })

      it('should return miss', () => {
        expect(result).to.be.equal(FireResult.Miss)
      })
    })

    describe('when shooting an occupied space', () => {
      let result: FireResult
      beforeEach(() => {
        result = classUnderTest.shoot(0, 0)
      })

      it('should return hit', () => {
        expect(result).to.be.equal(FireResult.Hit)
      })
    })

    describe('when sinking a ship', () => {
      let firstResult: FireResult
      let lastResult: FireResult
      beforeEach(() => {
        firstResult = classUnderTest.shoot(0, 0)
        lastResult = classUnderTest.shoot(1, 0)
      })

      it('should return hit on the first hit', () => {
        expect(firstResult).to.be.equal(FireResult.Hit)
      })

      it('should return sink on the last hit', () => {
        expect(lastResult).to.be.equal(FireResult.Sink)
      })
    })
  })
})
