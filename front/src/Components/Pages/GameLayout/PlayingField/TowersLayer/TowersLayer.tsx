import React from 'react';
import { Tower as ITower } from '../../../../../services/towers/towers';
import Tower from './Tower/Tower';

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
