import {FireResult} from '../fire-result'

const emptySpace = '\u0000'
const hitSpace = 'X'

export class BattleshipMap {
  map: string[][]

  constructor() {
    this.map = []
  }

  public deserialize(serialized: string) {
    this.map = JSON.parse(serialized)
  }

  public size(): number {
    let columnCount = this.map.length
    this.map.forEach(x => {
      if (x.length !== columnCount) {
        columnCount = -1
      }
    })
    return columnCount
  }

  public shoot(x: number, y: number): FireResult {
    const space = this.map[x][y]
    if (space !== emptySpace)  {
      this.map[x][y] = hitSpace
      return this.isShipSunk(space) ? FireResult.Sink : FireResult.Hit
    }
    return FireResult.Miss
  }

  public hasWon(): boolean {
    let anyShipsRemain = false
    this.map.forEach(row => row.forEach(space => {
      if (!(space === emptySpace || space === hitSpace)) {
        anyShipsRemain = true
      }
    }))
    return !anyShipsRemain
  }

  private isShipSunk(shipMarker: string): boolean {
    let shipMarkerFound = false
    this.map.forEach(row => row.forEach(space => {
      if (space === shipMarker) {
        shipMarkerFound = true
      }
    }))
    return !shipMarkerFound
  }
}
