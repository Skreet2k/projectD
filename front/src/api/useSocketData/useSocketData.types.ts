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
  Path: TPosition[],
  Configuration: {
    MillisecondsToTick: number,
    TicksToSpawn: number,
    IsEndlessLevel: boolean
  },
  Customer: any,
  Workers: any[],
  Features: TFeature[]
};

export type WorkerPayload = {
  workerId: string,
  coordinate: TPosition
};

export type TSocket = {
  path: Position[]
  socketData: TSocketData | null
  createSession: () => Promise<any>
  startSession: () => Promise<any>
  addWorker: (args: WorkerPayload) => Promise<any>
  removeWorker: (args: WorkerPayload) => Promise<any>
  connection: HubConnection | null
  isSessionCreated: boolean
  isSessionStarted: boolean
};
