import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { CellProps } from './Cell.types';
import { CellDiv } from './Cell.styles';
import { RootState } from '../../../../../store/store';
import { setSelectedShopTower } from '../../../../../store/slices/gameLayoutSlice';
import { useAddTowerMutation } from '../../../../../services/towers/towers';

function Cell({ cell, cellSize }: CellProps) {
  const dispatch = useDispatch();
  const shopTowerSelected = useSelector(
    (state: RootState) => state.gameLayout.shopTowerSelected,
  );
  const [addTower] = useAddTowerMutation();

  const onClick = () => {
    if (shopTowerSelected) {
      if (!cell?.isPath) {
        addTower({
          id: shopTowerSelected.id,
          coordinate: { X: cell.position.x, Y: cell.position.y },
        });
      }
      dispatch(setSelectedShopTower({ id: '' }));
    }
  };

  return (
    <CellDiv
      $size={cellSize}
      $cellInfo={cell}
      onClick={onClick}
      role="button"
    />
  );
}
export default Cell;
