import React from 'react';
import PlayingField from './PlayingField/PlayingField';
import { PlayingArea, StyledGameLayout } from './GameLayout.styles';
import GameLayoutProvider from '../../Providers/GameLayoutProvider/GameLayoutProvider';
import TasksBar from './TasksBar/TasksBar';

function GameLayout() {
  return (
    <GameLayoutProvider>
      <StyledGameLayout>
        <TasksBar />
        <PlayingArea>
          <div>место для показателей</div>
          <PlayingField />
        </PlayingArea>
        <div>правый бар</div>
      </StyledGameLayout>
    </GameLayoutProvider>
  );
}
export default GameLayout;
