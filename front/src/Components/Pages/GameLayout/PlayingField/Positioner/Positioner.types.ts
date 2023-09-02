import { ReactNode } from 'react';

export interface IPositionProps {
  xPx?: number
  yPx?: number
}
export interface TProps extends IPositionProps {
  children: ReactNode
}
