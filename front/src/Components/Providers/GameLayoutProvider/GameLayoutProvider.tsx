import React, { createContext, useMemo } from 'react';
import {
  InitialField,
  Sizes,
} from '../../Pages/GameLayout/PlayingField/PayingField.types';
import { useGetMapQuery } from '../../../services/map/map';
import { useFieldParams } from '../../Pages/GameLayout/PlayingField/useFieldParams';
import { TSocket } from '../../../api/useSocketData/useSocketData.types';
import useSocketData from '../../../api';

type GameLayoutProviderProps = {
  children: React.ReactNode;
};

type GameLayoutContextProps = {
  sizes?: Sizes;
  fieldParams?: InitialField;
  socket?: TSocket;
};
export const GameLayoutContext = createContext<GameLayoutContextProps>({});

function GameLayoutProvider({
  children,
}: GameLayoutProviderProps) {
  const { data } = useGetMapQuery({
    width: 8,
    height: 6,
    startX: 0,
    startY: 1,
    finishX: 7,
    finishY: 3,
  });

  const fieldParams = useFieldParams(data);
  const socket = useSocketData();
  const gameLayoutProviderValue = useMemo(() => ({
    sizes: fieldParams.sizes,
    fieldParams,
    socket,
  }), [fieldParams.sizes, socket]);

  return (
    <GameLayoutContext.Provider
      value={gameLayoutProviderValue}
    >
      {children}
    </GameLayoutContext.Provider>
  );
}
export default GameLayoutProvider;
