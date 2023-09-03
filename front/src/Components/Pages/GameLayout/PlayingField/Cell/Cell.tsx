import React from 'react';
import { useSelector } from 'react-redux';
import { CellProps } from './Cell.types';
import { CellDiv } from './Cell.styles';
import { RootState } from '../../../../../store/store';

function Cell({ cell, cellSize }: CellProps) {
  const { position/* cellCenter */ } = cell;
  const shopTowerSelected = useSelector(
    (state: RootState) => state.gameLayout.shopTowerSelected,
  );

  const onClick = () => {
    if (shopTowerSelected) {
      // console.log(shopTowerSelected);
      //
    }
  };

  return (
    <CellDiv
      $size={cellSize}
      $cellInfo={cell}
      // id={`${position.x}${position.y}`} /* don't set symbols between x and y */
      onClick={onClick}
      role="button"
    >
      {`${position.x}${position.y}`}
    </CellDiv>
  );
}
export default Cell;
