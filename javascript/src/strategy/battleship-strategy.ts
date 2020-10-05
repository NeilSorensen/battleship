import {FireResult} from '../fire-result'
import {Point} from '../point'

export interface BattleshipStrategy {
  nextMove(previousHitResult: FireResult): Point;
}
