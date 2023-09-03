import React, { useContext } from 'react';
import styled from 'styled-components';
import { keyframes } from '@mui/material';
import { zIndex } from '../../../../../../constants';
import { towers } from '../../../../../../assets/towers';
import { GameLayoutContext } from '../../../../../Providers/GameLayoutProvider/GameLayoutProvider';
import { DeveloperLevel, TowerType } from '../TowerLayer.types';

const spriteAnimation = (x: number) => keyframes`
  from{background-position-x:0;}
  to{background-position-x: -${x}px;}
`;

const TowerContainer = styled.div<{ $size: number, $top:number, $left: number, $background: string }>`
  position: absolute;
  z-index: ${zIndex};
  width: ${(props) => `${props.$size}px`};
  height: ${(props) => `${props.$size}px`};
  background-image: ${(props) => `url(${props.$background})`};
  background-size: cover;
  top: ${(props) => props.$top};
  left: ${(props) => props.$left};
  animation : ${(props) => spriteAnimation(props.$size * 3)} 1s steps(3) infinite;
`;

type TowerProps = {
  type: TowerType,
  level: DeveloperLevel,
};
function Tower({ type, level }:TowerProps) {
  const { sizes } = useContext(GameLayoutContext);
  const size = sizes?.sizeOfFieldCell;

  const background = towers[type][level];

  return size ? (
    <TowerContainer $size={size} $top={0} $left={0} $background={background} />
  ) : <div />;
}

export default Tower;
