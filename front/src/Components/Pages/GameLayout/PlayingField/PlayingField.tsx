import React from 'react';
import styled from 'styled-components';
import Cell from './Cell/Cell';
import { FieldObject, InitialField, Sizes } from './PayingField.types';
import Positioner from './Positioner/Positioner';
import { usePlayFeatureCoordinates } from '../../../../utils/gameLayout/usePlayFeatureCoordinates';

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

type PlayingFieldProps = InitialField;

function PlayingField({ initialObject, sizes, path }: PlayingFieldProps) {
  const mockedStyle = {
    width: '70px', height: '70px', borderRadius: '50%', backgroundColor: 'gray', lineHeight: '70px',
  };
  const mockedFeature = (<div style={mockedStyle}>Make me!</div>);
  const coordinate = usePlayFeatureCoordinates(initialObject, path);
  return (
    <FieldWrapper>
      <Field>
        {initialObject && initialObject.rows.map((row) => (
          <Row key={`Row-${row.id}`}>
            {row.cells.map((cell) => (
              <Cell
                key={`Cell-${cell.position.x}${cell.position.y}`}
                cell={cell}
                cellSize={sizes.sizeOfFieldCell}
              />
            ))}
          </Row>
        ))}
        <Positioner {...coordinate}>
          {mockedFeature}
        </Positioner>
      </Field>
    </FieldWrapper>
  );
}

export default PlayingField;
