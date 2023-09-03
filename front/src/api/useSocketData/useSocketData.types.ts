import { HubConnection } from '@microsoft/signalr';
import { Position } from '../../Components/Pages/GameLayout/PlayingField/PayingField.types';

export type TPosition = {
  X: number
  Y: number
};

export type TFeature = {
  Id: string,
  CurrentCoordinate: TPosition,
  NextCoordinate: TPosition | null,
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

export type TSocket = {
  socketData: TSocketData | null
  createSession: () => Promise<any>
  startSession: () => Promise<any>
  addWorker: () => Promise<any>
  removeWorker: () => Promise<any>
  connection: HubConnection | null
  isSessionCreated: boolean
  isSessionStarted: boolean
};
