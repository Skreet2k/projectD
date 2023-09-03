import React, {
  useContext, useEffect, useRef, useState,
} from 'react';
import useSocketData from '../../../../../api/useSocketData/useSocketData';
import Positioner from '../Positioner/Positioner';
import { CoordinatePx, FieldObject, Position } from '../PayingField.types';
import Feature from './Feature/Feature';
import { GameLayoutContext } from '../../../../Providers/GameLayoutProvider/GameLayoutProvider';
import { TFeatureData } from './Features.types';
import { TFeature, TPosition } from '../../../../../api/useSocketData/useSocketData.types';
import { TWayPoint } from '../Positioner/Positioner.types';
import { TFeatureProps } from './Feature/Feature.types';

const toPosition = (upperPosition: TPosition):Position => {
  const { X, Y } = upperPosition;
  return { x: X, y: Y };
};
const getCellCenterPx = (pos: Position, fieldObject: FieldObject): CoordinatePx => {
  const { xPx = 50, yPx = 50 } = fieldObject.rows[pos.y].cells[pos.x].centerPx!;
  return { xPx, yPx };
};

const getWayPoints = (feature: TFeatureProps, featureElements: Record<string, HTMLDivElement | null>, fieldObject:FieldObject, path: Position[]): TWayPoint[] => {
  // TODO make this smooth
  const featureElement = featureElements[feature.id];
  if (!featureElement) {
    return [{ ...getCellCenterPx(feature.currentCell, fieldObject), duration: 500 }];
  }
  return [{ ...getCellCenterPx(feature.currentCell, fieldObject), duration: 500 }];
};
export default function Features() {
  const socketData = useSocketData();
  const { fieldParams } = useContext(GameLayoutContext);
  const initialObject = fieldParams?.initialObject;
  const path = fieldParams?.path;
  const prevFeaturesData = useRef<TFeatureData[]>([]);
  const [featuresData, setFeaturesData] = useState<TFeatureData[]>([]);
  const featureElements = useRef<Record<string, HTMLDivElement | null>>({});
  useEffect(() => {
    if (!initialObject || !socketData || !path) {
      return;
    }
    const newFeaturesData = socketData.Features.map((fFromBack) => {
      const feature: TFeatureProps = {
        id: fFromBack.Id,
        speed: fFromBack.ProgressPerTick,
        progress: fFromBack.ProgressPercents,
        currentCell: toPosition(fFromBack.CurrentCoordinate),
        nextCell: toPosition(fFromBack.NextCoordinate),
        name: fFromBack.Name,
      };
      const wayPoints = getWayPoints(feature, featureElements.current, initialObject, path);
      return { feature, wayPoints };
    });

    setFeaturesData(newFeaturesData);
    prevFeaturesData.current = newFeaturesData;
  }, [socketData]);
  if (!initialObject || !socketData) {
    return null;
  }
  return (
    <>
      {featuresData.map(({ feature, wayPoints }) => (
        <Positioner
          key={feature.id}
          ref={(e) => {
            featureElements.current[feature.id] = e;
          }}
          wayPoints={wayPoints}
        >
          <Feature {...feature} />
        </Positioner>
      ))}
    </>
  );
}
