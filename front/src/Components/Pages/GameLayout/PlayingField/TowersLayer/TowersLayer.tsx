import React from 'react';
import { Tower as ITower } from '../../../../../services/towers/towers';
import Tower from './Tower/Tower';
import { TWorker } from '../../../../../api/useSocketData/useSocketData.types';
import { DeveloperLevel, TowerType } from './TowerLayer.types';

type TowersLayerProps = {
  workers: TWorker[];
};
function TowersLayer({ workers }: TowersLayerProps) {
  const towers: ITower[] = workers.map((worker) => ({
    id: worker.Id,
    level: DeveloperLevel.junior,
    type: TowerType.frontend,
    position: {
      x: worker.Coordinate.X + 2,
      y: worker.Coordinate.Y + 5,
    },
  }));
  return (
    <>
      {towers.map((tower) => <Tower key={tower.id} {...tower} />)}
    </>
  );
}

export default TowersLayer;
