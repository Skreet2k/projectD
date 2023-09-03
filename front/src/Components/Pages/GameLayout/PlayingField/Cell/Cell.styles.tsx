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
   box-shadow: ${(props) => !props.$cellInfo?.isPath && '0px 0px 0px 2px black'}; 
   z-index: ${(props) => !props.$cellInfo?.isPath && 1};
  }
`;
