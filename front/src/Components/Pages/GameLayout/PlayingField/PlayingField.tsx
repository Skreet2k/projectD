import React, { useContext } from 'react';
import styled from 'styled-components';
import Cell from './Cell/Cell';
import { GameLayoutContext } from '../../../Providers/GameLayoutProvider/GameLayoutProvider';
import Features from './Features/Features';

const FieldWrapper = styled.div`
  position: relative;
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
  const { fieldParams } = useContext(GameLayoutContext);

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
