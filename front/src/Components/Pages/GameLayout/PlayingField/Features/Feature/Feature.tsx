import React, { useContext } from 'react';
import styled from 'styled-components';
import { TFeatureProps } from './Feature.types';
import { GameLayoutContext } from '../../../../../Providers/GameLayoutProvider/GameLayoutProvider';

const FeatureWrapper = styled.div<{ $width: number }>`
  width: ${(props) => `${props.$width}px`};
  max-height: ${(props) => `${props.$width}px`};
  overflow: hidden;
  display: flex;
  flex-direction: column;
`;

const FeatureBody = styled.div`
  border-radius: 5px;
  background-color: #fff;
  border-style: solid;
  border-width: 1px;
  padding: 5px;
  font-size: 11px;
  word-wrap: break-word;
`;
export default function Feature({ name /* , progress */ }: TFeatureProps) {
  const { sizes } = useContext(GameLayoutContext);
  const size = sizes?.sizeOfFieldCell || 70;

  return (
    <FeatureWrapper $width={size - 5}>
      <FeatureBody>{name}</FeatureBody>
    </FeatureWrapper>
  );
}
