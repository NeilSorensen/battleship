import {FireResult} from '../fire-result'
import {BattleshipStrategy} from './battleship-strategy'
import {Point} from '../point'

const maxColumns = 10

export class NaiveBattleshipStrategy implements BattleshipStrategy {
  lastPoint: Point

  constructor() {
    this.lastPoint = {x: -1, y: 0}
  }

  nextMove(_: FireResult): Point {
    this.lastPoint =  {x: this.lastPoint.x + 1, y: this.lastPoint.y}
    if (this.lastPoint.x >= maxColumns) {
      this.lastPoint = {x: 0, y: this.lastPoint.y + 1}
    }
    return this.lastPoint
  }
}
