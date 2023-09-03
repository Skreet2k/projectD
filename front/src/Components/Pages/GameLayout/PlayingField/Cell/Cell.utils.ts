import { Cell } from '../PayingField.types';
import { playingFieldTheme } from '../../../../../theme';

export const getColor = (cellInfo: Cell): string => {
  const { position: { x, y }, isPath } = cellInfo;

  if (isPath) return playingFieldTheme.pathColor; // #ff8a65
  if (x % 2) {
    return y % 2 ? playingFieldTheme.cell.light : playingFieldTheme.cell.light2;
  }
  return y % 2 ? playingFieldTheme.cell.light2 : playingFieldTheme.cell.light;
};
