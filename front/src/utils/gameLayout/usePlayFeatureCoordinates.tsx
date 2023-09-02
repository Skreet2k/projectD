import { useEffect, useRef, useState } from 'react';
import { CoordinatePx, FieldObject, Position } from '../../Components/Pages/GameLayout/PlayingField/PayingField.types';
import { IPositionProps } from '../../Components/Pages/GameLayout/PlayingField/Positioner/Positioner.types';
import { TICK_MS } from '../../constants';

const getCellCenterPx = (pos: Position, fieldObject: FieldObject): CoordinatePx => {
  const { xPx = 50, yPx = 50 } = fieldObject.rows[pos.y].cells[pos.x].centerPx!;
  return { xPx, yPx };
};
export const usePlayFeatureCoordinates = (fieldObject: FieldObject | null | undefined, path: Position[] | undefined) => {
  const coordinateRef = useRef<IPositionProps>({});
  const [coordinate, setCoordinate] = useState(coordinateRef.current);

  useEffect(() => {
    if (!fieldObject) {
      return;
    }
    let pathPosition = 0;
    const iid = setInterval(() => {
      const position = path && path[pathPosition];
      if (!position) {
        clearInterval(iid);
        coordinateRef.current = {};
      } else {
        coordinateRef.current = getCellCenterPx(position, fieldObject);
        pathPosition += 1;
      }
      setCoordinate(coordinateRef.current);
    }, TICK_MS);
  }, [path, fieldObject]);

  return coordinate;
};
