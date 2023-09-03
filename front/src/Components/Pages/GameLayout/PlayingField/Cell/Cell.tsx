import React, { useContext } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { CellProps } from './Cell.types';
import { CellDiv } from './Cell.styles';
import { RootState } from '../../../../../store/store';
import { GameLayoutContext } from '../../../../Providers/GameLayoutProvider/GameLayoutProvider';
import { setSelectedShopTower } from '../../../../../store/slices/gameLayoutSlice';
import { useAddTowerMutation } from '../../../../../services/towers/towers';

function Cell({ cell, cellSize }: CellProps) {
  const dispatch = useDispatch();
  const { socket } = useContext(GameLayoutContext);
  const shopTowerSelected = useSelector(
    (state: RootState) => state.gameLayout.shopTowerSelected,
  );
  const [addTower] = useAddTowerMutation();

  const onClick = () => {
    if (shopTowerSelected) {
      addTower({ id: shopTowerSelected.id, coordinate: { X: cell.position.x, Y: cell.position.y } });
      dispatch(setSelectedShopTower({ id: '' }));
    }
  };

  return (
    <CellDiv
      $size={cellSize}
      $cellInfo={cell}
      // id={`${position.x}${position.y}`} /* don't set symbols between x and y */
      onClick={onClick}
      role="button"
    />
  );
}
export default Cell;
