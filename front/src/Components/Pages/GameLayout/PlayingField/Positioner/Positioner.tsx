import React from 'react';
import styled from 'styled-components';
import { IPositionPropsFiltered, TProps } from './Positioner.types';

const PositionContainer = styled.div<IPositionPropsFiltered>`
  position: absolute;
  left: ${(props) => `${props.$xPx}px`};
  top: ${(props) => `${props.$yPx}px`};
  transform: translate(-50%, -50%);
  transition: ${(props) => `top ${props.$duration}ms linear, left ${props.$duration}ms linear`};
`;

function Positioner({ children, wayPoints }: TProps) {
  // const [pxPosition, setPxPosition] = useState<TWayPoint>(wayPoints[0]);
  // useEffect(() => {
  //   const futureWayPoints = [...wayPoints];
  //   setPxPosition(futureWayPoints.shift()!);
  //   futureWayPoints.forEach(({ delayMS, ...futurePxPosition }) => {
  //     setTimeout(() => setPxPosition(futurePxPosition), delayMS);
  //   });
  // }, [wayPoints]);
  // if (!pxPosition) {
  //   return null;
  // }

  const firstPoint = wayPoints[0];
  if (!firstPoint) {
    return null;
  }
  const { xPx, yPx, duration } = firstPoint;
  return (
    <PositionContainer $xPx={xPx} $yPx={yPx} $duration={duration}>
      {children}
    </PositionContainer>
  );
}

export default Positioner;
