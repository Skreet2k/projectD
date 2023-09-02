import React, { useContext } from 'react';
import styled from 'styled-components';
import { GameLayoutContext } from '../../../Providers/GameLayoutProvider/GameLayoutProvider';

export const LeftBar = styled.div<{ width: number }>`
  display: flex;
  flex-direction: column;
  width: ${(props) => `${props.width}px`};
`;

function TasksBar() {
  const { fieldParams } = useContext(GameLayoutContext);

  return (
    fieldParams ? <LeftBar width={fieldParams?.sizes?.sizeOfFieldCell * 2}>Left Bar</LeftBar> : <div />
  );
}
export default TasksBar;
