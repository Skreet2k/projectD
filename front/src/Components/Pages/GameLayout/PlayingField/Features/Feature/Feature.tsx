import React from 'react';
import styled from 'styled-components';
import { TFeatureProps } from './Feature.types';

const FeatureWrapper = styled.div`
  width: 70px;
  height: 70px;
  border-radius: 50%;
  background-color: gray;   
  line-height: 70px;
  overflow: hidden;
`;
export default function Feature({ name }: TFeatureProps) {
  return (
    <FeatureWrapper>
      {name}
    </FeatureWrapper>
  );
}
