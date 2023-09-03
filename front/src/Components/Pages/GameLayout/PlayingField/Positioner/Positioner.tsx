import React, { Ref, useEffect, useState } from 'react';
import styled from 'styled-components';
import { IPositionPropsFiltered, TProps, TWayPoint } from './Positioner.types';
import { TICK_MS } from '../../../../../constants';

const PositionContainer = styled.div<IPositionPropsFiltered>`
  position: absolute;
  left: ${(props) => `${props.$xPx}px`};
  top: ${(props) => `${props.$yPx}px`};
  transform: translate(-50%, -50%);
  transition: ${(props) => `top ${props.$duration}ms linear, left ${props.$duration}ms linear`};
`;

const Positioner = React.forwardRef(({ children, wayPoints }: TProps, ref: Ref<HTMLDivElement>) => {
  const [pxPosition, setPxPosition] = useState<TWayPoint>(wayPoints[0]);
  useEffect(() => {
    const futureWayPoints = wayPoints;
    setPxPosition(futureWayPoints.shift()!);
    futureWayPoints.forEach(({ delayMS, ...futurePxPosition }) => {
      setTimeout(() => setPxPosition(futurePxPosition), delayMS);
    });
  }, [wayPoints]);
  if (!pxPosition) {
    return null;
  }
  const { xPx, yPx, duration } = pxPosition;
  return (
    <PositionContainer ref={ref} $xPx={xPx} $yPx={yPx} $duration={duration}>
      {children}
    </PositionContainer>
  );
});

export default Positioner;
