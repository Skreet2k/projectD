import React from 'react';
import styled from 'styled-components';
import PlayingField from './PlayingField/PlayingField';
import { useFieldParams } from './PlayingField/useFieldParams';
import { useGetMapQuery } from '../../../services/map';

const PlayingArea = styled.div`
  display: flex;
  flex-direction: column;
`;

const LeftBar = styled.div<{ width: number }>`
  display: flex;
  flex-direction: column;
  width: ${(props) => `${props.width}px`};
`;

const StyledGameLayout = styled.div`
  display: flex;
  flex-direction: row;
`;

function GameLayout() {
  const { data, error, isLoading } = useGetMapQuery({
    width: 8,
    height: 6,
    startX: 0,
    startY: 1,
    finishX: 7,
    finishY: 3,
  });

  const fieldParams = useFieldParams(data);

  return (
    <StyledGameLayout>
      <LeftBar width={fieldParams.sizes.sizeOfFieldCell * 2}>Left Bar</LeftBar>
      <PlayingArea>
        <div>место для показателей</div>
        <PlayingField {...fieldParams} />
      </PlayingArea>
      <div>правый бар</div>
    </StyledGameLayout>
  );
}
export default GameLayout;
