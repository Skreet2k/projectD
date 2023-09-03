import styled from 'styled-components';
import { playingFieldTheme } from '../../../theme';

export const PlayingArea = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
`;

export const StyledGameLayout = styled.div`
  display: flex;
  flex-direction: row;
  flex: 1 1 auto;
  background-color: ${playingFieldTheme.playingAreaBackground};
  justify-content: space-between;
`;
