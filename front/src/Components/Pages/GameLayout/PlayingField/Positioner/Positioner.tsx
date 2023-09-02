import React from 'react';
import styled from 'styled-components';
import {IPositionProps, IPositionPropsFiltered, TProps} from './Positioner.types';
import { TICK_MS } from '../../../../../constants';

const linearRule = `${TICK_MS}ms linear`;
const PositionContainer = styled.div<IPositionPropsFiltered>`
  position: absolute;
  left: ${(props) => `${props.$xPx}px`};
  top: ${(props) => `${props.$yPx}px`};
  transform: translate(-50%, -50%);
  transition: top ${linearRule}, left ${linearRule};
`;

const isGoodPx = (px: number | void) => Number.isNaN(Number(px));
function Positioner({ children, xPx, yPx }: TProps) {
  if (isGoodPx(xPx) || isGoodPx(yPx)) {
    return null;
  }
  return (
    <PositionContainer $xPx={xPx} $yPx={yPx}>
      {children}
    </PositionContainer>
  );
}

export default Positioner;
