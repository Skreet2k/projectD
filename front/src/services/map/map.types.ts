import { Position } from '../../Components/Pages/GameLayout/PlayingField/PayingField.types';

export interface MapResponse {
  errorMessage: 'string';
  returnCode: number;
  isSuccess: true;
  content: {
    width: number;
    height: number;
    path: Position[];
  };
}

export interface MapPayload {
  width: number;
  height: number;
  startX: number;
  startY: number;
  finishX: number;
  finishY: number;
}
