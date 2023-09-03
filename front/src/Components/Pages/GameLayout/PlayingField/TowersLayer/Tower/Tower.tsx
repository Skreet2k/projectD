import React, { useContext } from 'react';
import styled from 'styled-components';
import { keyframes } from '@mui/material';
import { zIndex } from '../../../../../../constants';
import { towers } from '../../../../../../assets/towers';
import { GameLayoutContext } from '../../../../../Providers/GameLayoutProvider/GameLayoutProvider';
import { DeveloperLevel, TowerType } from '../TowerLayer.types';
import { CoordinatePx, FieldObject, Position } from '../../PayingField.types';

const spriteAnimation = (x: number) => keyframes`
  from{background-position-x:0;}
  to{background-position-x: -${x}px;}
`;

const TowerContainer = styled.div<{ $size: number, $top:number, $left: number, $background: string }>`
  position: absolute;
  transform: translate(-50%, -50%);
  z-index: ${zIndex};
  width: ${(props) => `${props.$size}px`};
  height: ${(props) => `${props.$size}px`};
  background-image: ${(props) => `url(${props.$background})`};
  background-size: cover;
  top: ${(props) => `${props.$top}px`};
  left: ${(props) => `${props.$left}px`};
  animation : ${(props) => spriteAnimation(props.$size * 3)} 1s steps(3) infinite;
`;

type TowerProps = {
  type: TowerType,
  level: DeveloperLevel,
  position: Position,
};
const getCellCenterPx = (pos: Position, fieldObject: FieldObject): CoordinatePx => {
  const { xPx = 50, yPx = 50 } = fieldObject.rows[pos.y].cells[pos.x].centerPx!;
  return { xPx, yPx };
};
function Tower({ type, level, position }:TowerProps) {
  const { sizes, fieldParams } = useContext(GameLayoutContext);
  const size = sizes?.sizeOfFieldCell;

  const background = towers[type][level];
  const positionPx = getCellCenterPx(position, fieldParams?.initialObject!);

  return size ? (
    <TowerContainer $size={size} $top={positionPx.yPx} $left={positionPx.xPx} $background={background} />
  ) : <div />;
}

export default Tower;
