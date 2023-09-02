import { Cell } from '../PayingField.types';

export const getColor = (cellInfo: Cell): string => {
  const { position: { x, y }, isPath } = cellInfo;

  if (isPath) return '#C578C2';
  if (x % 2) {
    return y % 2 ? '#FFFFFF' : '#DAF8F2';
  }
  return y % 2 ? '#DAF8F2' : '#FFFFFF';
};
