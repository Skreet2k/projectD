import styled from 'styled-components';
import { playingField } from '../../../theme';

export const PlayingArea = styled.div`
  display: flex;
  flex-direction: column;
`;

export const StyledGameLayout = styled.div`
  display: flex;
  flex-direction: row;
  flex: 1 1 auto;
  background-color: ${playingField.playingAreaBackground};
  justify-content: space-between;
`;
