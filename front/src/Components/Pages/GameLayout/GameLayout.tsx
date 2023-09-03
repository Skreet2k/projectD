import React, { useContext, useEffect } from 'react';
import PlayingField from './PlayingField/PlayingField';
import { PlayingArea, StyledGameLayout } from './GameLayout.styles';
import GameLayoutProvider, { GameLayoutContext } from '../../Providers/GameLayoutProvider/GameLayoutProvider';
import Shop from './Shop/Shop';
import Stats from './Stats';
import SettingsModal from '../../SettingsModal';
import { SettingsContext } from '../../Providers/SettingsContextProvider/SettingsContextProvider';

function GameLayout() {
  const { socket } = useContext(GameLayoutContext);
  const { toggleOpen } = useContext(SettingsContext);

  useEffect(() => {
    if (socket?.isGameEnded) {
      toggleOpen();
    }
  }, [socket]);

  return (
    <GameLayoutProvider>
      <StyledGameLayout>
        <Stats />
        <PlayingArea>
          <PlayingField />
        </PlayingArea>
        <Shop />
      </StyledGameLayout>
      <SettingsModal />
    </GameLayoutProvider>
  );
}
export default GameLayout;
