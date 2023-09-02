import React, { useContext } from 'react';
import styled from 'styled-components';
import Cell from './Cell/Cell';
import Positioner from './Positioner/Positioner';
import { usePlayFeatureCoordinates } from '../../../../utils/gameLayout/usePlayFeatureCoordinates';
import Tower from '../Tower/Tower';
import { DeveloperLevel, TowerType } from '../../../../assets/towers';
import { GameLayoutContext } from '../../../Providers/GameLayoutProvider/GameLayoutProvider';

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
  const mockedStyle = {
    width: '70px', height: '70px', borderRadius: '50%', backgroundColor: 'gray', lineHeight: '70px',
  };
  const mockedFeature = (<div style={mockedStyle}>Make me!</div>);
  const coordinate = usePlayFeatureCoordinates(fieldParams?.initialObject, fieldParams?.path);

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
        <Positioner {...coordinate}>
          {mockedFeature}
        </Positioner>
      </Field>
      <Tower type={TowerType.backend} level={DeveloperLevel.junior} />
    </FieldWrapper>
  );
}

export default PlayingField;
