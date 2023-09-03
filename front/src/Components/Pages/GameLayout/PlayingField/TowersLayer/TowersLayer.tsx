import React from 'react';
import { Tower as ITower, useGetTowersQuery } from '../../../../../services/towers/towers';
import Tower from './Tower/Tower';
import { TWorker } from '../../../../../api/useSocketData/useSocketData.types';

type TowersLayerProps = {
  workers: TWorker[];
};
function TowersLayer({ workers }: TowersLayerProps) {
  const { data } = useGetTowersQuery();

  if (!data) {
    return null;
  }
  const getFullTowerData = (worker:TWorker): ITower => data.content.find((t) => t.id === worker.Id)!;

  const towers: ITower[] = workers.map((worker) => ({
    ...getFullTowerData(worker),
    position: {
      x: worker.Coordinate.X,
      y: worker.Coordinate.Y,
    },
  })).filter((t) => t.id);
  return (
    <>
      {towers.map((tower) => <Tower key={tower.id} {...tower} />)}
    </>
  );
}

export default TowersLayer;
