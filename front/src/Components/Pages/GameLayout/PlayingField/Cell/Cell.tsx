import React from 'react';
import { CellProps } from './Cell.types';
import { CellDiv } from './Cell.styles';

function Cell({ cell, cellSize }: CellProps) {
  const { position/* cellCenter */ } = cell;

  const getCellInfo = () => {
    // console.log('cellCeneter', cellCenter);
    // записывает данные о том, что в ячейке должен находиться объект
  };

  return (
    <CellDiv
      size={cellSize}
      cellInfo={cell}
      // id={`${position.x}${position.y}`} /* don't set symbols between x and y */
      onClick={getCellInfo}
    >
      {`${position.x}${position.y}`}
    </CellDiv>
  );
}
export default Cell;
