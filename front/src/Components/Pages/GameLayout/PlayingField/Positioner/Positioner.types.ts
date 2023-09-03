import { ReactNode } from 'react';

export interface IPositionsList {
  wayPoints: TWayPoint[]
}

export type TWayPoint = {
  xPx: number
  yPx: number
  delayMS?: number
  duration: number
};
export interface IPositionPropsFiltered {
  $xPx: number
  $yPx: number
  $duration: number
}
export interface TProps extends IPositionsList {
  children: ReactNode
}
