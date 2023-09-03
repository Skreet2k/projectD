import { Position } from '../../Components/Pages/GameLayout/PlayingField/PayingField.types';

export type TPosition = {
  X: number
  Y: number
};

export type TFeature = {
  Id: string,
  CurrentCoordinate: TPosition,
  NextCoordinate: TPosition,
  ProgressPercents: number,
  CurrentHealthPoints: number,
  MaxHealthPoints: number,
  Name: string,
  ProgressPerTick: number,
  Reward: number
};

export type TSocketData = {
  Path: Position[],
  Configuration: {
    MillisecondsToTick: number,
    TicksToSpawn: number,
    IsEndlessLevel: boolean
  },
  Customer: any,
  Workers: any[],
  Features: TFeature[]
};

export type NullableSocketData = TSocketData | null;
