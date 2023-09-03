import React, { useContext, useEffect, useState } from 'react';
import styled from 'styled-components';
import { Button } from '@mui/material';
import Cell from './Cell/Cell';
import { GameLayoutContext } from '../../../Providers/GameLayoutProvider/GameLayoutProvider';
import Features from './Features/Features';
import TowersLayer from './TowersLayer/TowersLayer';
import { SettingsContext } from '../../../Providers/SettingsContextProvider/SettingsContextProvider';

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
  const [isStartClicked, setIsStartClicked] = useState(false);
  useEffect(() => {
    if (!socket || !socket.connection) {
      return;
    }
    socket.createSession();
  }, [socket?.connection]);

  const { toggleOpen } = useContext(SettingsContext);

  useEffect(() => {
    if (socket?.isGameEnded) {
      toggleOpen();
    }
  }, [socket]);

  return (
    <>
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
        <TowersLayer workers={socket?.socketData?.Workers || []} />
      </FieldWrapper>

      {!isStartClicked
        && (
        <Button
          onClick={() => {
            socket?.startSession();
            setIsStartClicked(true);
          }}
          disabled={!socket?.isSessionCreated || socket.isSessionStarted || isStartClicked}
          // doesn't hide!
          // hidden={isStartClicked}
          variant="contained"
        >
          НАЧАТЬ!
        </Button>
        )}
    </>
  );
}

export default PlayingField;
