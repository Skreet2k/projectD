import React from 'react';
import styled from 'styled-components';
import { useFieldParams } from './useFieldParams';
import { BEFieldMock } from './mock';
import Cell from './Cell/Cell';
import { useGetPokemonByNameQuery } from '../../../../services/map';

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
  const { data, error, isLoading } = useGetPokemonByNameQuery('bulbasaur');
  const BEWidth = BEFieldMock.content.width;
  const BEHeight = BEFieldMock.content.height;
  const { path } = BEFieldMock.content;

  const { initialObject, sizes } = useFieldParams(
    {
      widthAmount: BEWidth,
      heightAmount: BEHeight,
      path,
    },
  );

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
      </Field>
    </FieldWrapper>
  );
}

export default PlayingField;
