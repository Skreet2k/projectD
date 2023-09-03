import { Position } from '../../PayingField.types';

export type TFeatureProps = {
  id: string
  name: string
  speed: number
  progress: number
  nextCell: Position
  currentCell: Position
};
