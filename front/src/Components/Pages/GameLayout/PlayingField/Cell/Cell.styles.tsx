import styled from 'styled-components';
import { getColor } from './Cell.utils';
import { Cell } from '../PayingField.types';

export const CellDiv = styled.div<{ $size: number, $cellInfo: Cell }>`
  display: flex;
  width: ${(props) => `${props.$size}px`};
  height: ${(props) => `${props.$size}px`};
  background-color: ${(props) => getColor(props.$cellInfo)};
  color: ${(props) => getColor(props.$cellInfo)};

 &:hover {
   box-shadow: ${(props) => !props.$cellInfo?.isPath && '0 0 10px 10px rgba(211, 104, 9, 0.6)'}; 
   z-index: ${(props) => !props.$cellInfo?.isPath && 1};
  }
`;
