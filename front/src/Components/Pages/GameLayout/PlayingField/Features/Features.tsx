import React, { useContext } from 'react';
import Positioner from '../Positioner/Positioner';
import { CoordinatePx, FieldObject, Position } from '../PayingField.types';
import Feature from './Feature/Feature';
import { GameLayoutContext } from '../../../../Providers/GameLayoutProvider/GameLayoutProvider';
import { TPosition } from '../../../../../api/useSocketData/useSocketData.types';
import { TWayPoint } from '../Positioner/Positioner.types';
import { TFeatureProps } from './Feature/Feature.types';

const toPosition = (upperPosition: TPosition): Position => {
  const { X, Y } = upperPosition;
  return { x: X, y: Y };
};
const getCellCenterPx = (
  pos: Position,
  fieldObject: FieldObject,
): CoordinatePx => {
  const { xPx = 50, yPx = 50 } = fieldObject.rows[pos.y].cells[pos.x].centerPx!;
  return { xPx, yPx };
};

const getWayPoints = (
  feature: TFeatureProps,
  fieldObject: FieldObject,
): TWayPoint[] => [
  { ...getCellCenterPx(feature.currentCell, fieldObject), duration: 500 },
];
export default function Features() {
  const { fieldParams, socket } = useContext(GameLayoutContext);
  const socketData = socket?.socketData;
  const initialObject = fieldParams?.initialObject;
  const path = fieldParams?.path;
  if (!initialObject || !socketData || !path) {
    return null;
  }
  const featuresData = socketData.Features.map((fFromBack) => {
    const feature: TFeatureProps = {
      id: fFromBack.Id,
      speed: fFromBack.ProgressPerTick,
      progress: fFromBack.ProgressPercents,
      currentCell: toPosition(fFromBack.CurrentCoordinate),
      nextCell: toPosition(
        fFromBack.NextCoordinate || fFromBack.CurrentCoordinate,
      ),
      name: fFromBack.Name,
    };
    const wayPoints = getWayPoints(feature, initialObject);
    return { feature, wayPoints };
  });

  return (
    <>
      {featuresData.map(({ feature, wayPoints }) => (
        <Positioner key={feature.id} wayPoints={wayPoints}>
          <Feature {...feature} />
        </Positioner>
      ))}
    </>
  );
}
