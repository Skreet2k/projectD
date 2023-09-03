import React from 'react';
import PlayingField from './PlayingField/PlayingField';
import { PlayingArea, StyledGameLayout } from './GameLayout.styles';
import GameLayoutProvider from '../../Providers/GameLayoutProvider/GameLayoutProvider';
import Shop from './Shop/Shop';
import Stats from './Stats';
import SettingsModal from '../../SettingsModal';

function GameLayout() {
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
