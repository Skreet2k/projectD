export enum TowerType {
  frontend = 2,
  backend = 1,
  qa = 6,
  teamlead = 3,
  analyst = 4,
  pm = 5,
  // dba = 7, // TODO
  designer = 8,
}

export enum DeveloperLevel {
  junior = 1,
  middle = 2,
  senior = 3,
}
export interface ITower {
  type: TowerType,
  level: DeveloperLevel,
}
