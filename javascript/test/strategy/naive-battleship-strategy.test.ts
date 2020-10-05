import {expect} from 'chai'
import {FireResult} from '../../src/fire-result'
import {NaiveBattleshipStrategy} from '../../src/strategy/naive-battleship-strategy'

describe('The naive strategy', () => {
  let classUnderTest: NaiveBattleshipStrategy

  beforeEach(() => {
    classUnderTest = new NaiveBattleshipStrategy()
  })

  describe('When starting a game', () => {
    it('should start at the origin', () => {
      const firstShot = classUnderTest.nextMove(FireResult.None)
      expect(firstShot).to.deep.equal({x: 0, y: 0})
    })
  })

  describe('When advancing', () => {
    it('should increment x', () => {
      classUnderTest.nextMove(FireResult.None)
      const secondShot = classUnderTest.nextMove(FireResult.Miss)
      expect(secondShot).to.deep.equal({x: 1, y: 0})
    })
  })

  describe('When reaching the end of a row', () => {
    it('should increment y', () => {
      classUnderTest.nextMove(FireResult.None)
      for (let i = 0; i < 9; i++) {
        classUnderTest.nextMove(FireResult.Miss)
      }
      const secondRowFirstShot = classUnderTest.nextMove(FireResult.Miss)
      expect(secondRowFirstShot).to.deep.equal({x: 0, y: 1})
    })
  })

  describe('When filling out a full map', () => {
    it('should hit every point on the map', () => {
      let nextPoint = classUnderTest.nextMove(FireResult.None)
      let xSum = 0
      let ySum = 0
      for (let i = 0; i < 99; i++) {
        nextPoint = classUnderTest.nextMove(FireResult.Miss)
        xSum += nextPoint.x
        ySum += nextPoint.y
      }
      expect(nextPoint).to.deep.equal({x: 9, y: 9})
      expect(xSum).to.equal(450)
      expect(ySum).to.equal(450)
    })
  })
})
