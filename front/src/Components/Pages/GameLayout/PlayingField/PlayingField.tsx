import React, { useContext } from 'react';
import styled from 'styled-components';
import Cell from './Cell/Cell';
import Positioner from './Positioner/Positioner';
import { usePlayFeatureCoordinates } from '../../../../utils/gameLayout/usePlayFeatureCoordinates';
import { GameLayoutContext } from '../../../Providers/GameLayoutProvider/GameLayoutProvider';
import TowersLayer from './TowersLayer/TowersLayer';
import { DeveloperLevel, ITower, TowerType } from './TowersLayer/TowerLayer.types';

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
  const towers: ITower[] = [{ type: TowerType.frontend, level: DeveloperLevel.junior }];

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
      <TowersLayer towers={towers} />
    </FieldWrapper>
  );
}

export default PlayingField;
