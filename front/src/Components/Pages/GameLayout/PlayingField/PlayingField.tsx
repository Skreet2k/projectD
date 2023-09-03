import React, { useContext, useEffect } from 'react';
import styled from 'styled-components';
import Cell from './Cell/Cell';
import { GameLayoutContext } from '../../../Providers/GameLayoutProvider/GameLayoutProvider';
import Features from './Features/Features';

const FieldWrapper = styled.div`
  position: relative;
  border-style: solid;
  border-width: 2px;
`;

const Field = styled.div`
  display: flex;
  flex-direction: column;
`;

const Row = styled.div`
  display: flex;
  flex-direction: row;
`;

function PlayingField() {
  const { fieldParams, socket } = useContext(GameLayoutContext);
  useEffect(() => {
    if (!socket || !socket.connection) {
      return;
    }
    socket.createSession().then(() => socket.startSession());
  }, [socket?.connection]);

  // const { data } = useGetTowersQuery();
  // const content = data?.content;

  return (
    <FieldWrapper>
      <Field>
        {fieldParams?.initialObject && fieldParams?.initialObject.rows.map((row) => (
          <Row key={`Row-${row.id}`}>
            {row.cells.map((cell) => (
              <Cell
                key={`Cell-${cell.position.x}${cell.position.y}`}
                cell={cell}
                cellSize={fieldParams?.sizes.sizeOfFieldCell}
              />
            ))}
          </Row>
        ))}
        <Features />
      </Field>
      {/* <TowersLayer towers={towers} /> */}
    </FieldWrapper>
  );
}

export default PlayingField;
