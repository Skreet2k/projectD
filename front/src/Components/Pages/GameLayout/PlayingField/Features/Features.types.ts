import { CoordinatePx, Position } from '../PayingField.types';
import { TFeatureProps } from './Feature/Feature.types';
import { TWayPoint } from '../Positioner/Positioner.types';

export type TFeatureData = {
  feature: TFeatureProps
  wayPoints: TWayPoint[]
};
