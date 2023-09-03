import React, { useContext } from 'react';
import styled from 'styled-components';
import Cell from './Cell/Cell';
import Tower from '../Tower/Tower';
import { DeveloperLevel, TowerType } from '../../../../assets/towers';
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
      <Tower type={TowerType.backend} level={DeveloperLevel.junior} />
    </FieldWrapper>
  );
}

export default PlayingField;
