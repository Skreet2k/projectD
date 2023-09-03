import { Cell } from '../PayingField.types';
import { playingField } from '../../../../../theme';

export const getColor = (cellInfo: Cell): string => {
  const { position: { x, y }, isPath } = cellInfo;

  if (isPath) return '#ffab40'; // #ff8a65
  if (x % 2) {
    return y % 2 ? playingField.cell.light : playingField.cell.light2;
  }
  return y % 2 ? playingField.cell.light2 : playingField.cell.light;
};
