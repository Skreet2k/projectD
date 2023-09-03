import React from 'react';
import Tower from './Tower/Tower';
import { ITower } from './TowerLayer.types';

type TowersLayerProps = {
  towers: ITower[];
};
function TowersLayer({ towers }: TowersLayerProps) {
  return (
    <>
      {towers.map((item) => <Tower type={item.type} level={item.level} />)}
    </>
  );
}

export default TowersLayer;
