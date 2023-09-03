import React from 'react';
import PlayingField from './PlayingField/PlayingField';
import { PlayingArea, StyledGameLayout } from './GameLayout.styles';
import GameLayoutProvider from '../../Providers/GameLayoutProvider/GameLayoutProvider';
import TasksBar from './TasksBar/TasksBar';
import Shop from './Shop/Shop';

function GameLayout() {
  return (
    <GameLayoutProvider>
      <StyledGameLayout>
        <TasksBar />
        <PlayingArea>
          <div>место для показателей</div>
          <PlayingField />
        </PlayingArea>
        <Shop />
      </StyledGameLayout>
    </GameLayoutProvider>
  );
}
export default GameLayout;
