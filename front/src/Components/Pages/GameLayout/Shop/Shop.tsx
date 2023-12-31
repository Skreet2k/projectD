import React, { useContext } from 'react';
import styled from 'styled-components';
import { GameLayoutContext } from '../../../Providers/GameLayoutProvider/GameLayoutProvider';
import ShopItem from './ShopItem/ShopItem';
import { useGetTowersQuery } from '../../../../services/towers/towers';
import { playingFieldTheme } from '../../../../theme';

export const ShopContentWrapper = styled.div`
  width: 100%;
  position: relative;
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  gap: 15px;
  margin: 15px;
  justify-content: center;
  height: fit-content;
  overflow-y: scroll;
  height: calc(100vh - 100px);
  &::-webkit-scrollbar-thumb {
    background-color: rgba(0, 0, 0, 0.5);
    border-radius: 35px;
  }
  &::-webkit-scrollbar-track {
    box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.3);
    border-radius: 35px;
  }
  &::-webkit-scrollbar {
    width: 1em;
  }
  padding-top: 15px;
`;

const ShopContentBackground = styled.div<{ $width: number }>`
  min-width: ${(props) => `${props.$width}px`};
  max-width: 30%;
  position: relative;
  display: flex;
  height: 100%;
  background-color: ${playingFieldTheme.shopBackground}; // TODO move to colors
`;
function Shop() {
  // ширина в 3 ячейки
  const { fieldParams } = useContext(GameLayoutContext);
  const shopWidth = fieldParams?.sizes?.sizeOfFieldCell
    ? +fieldParams?.sizes.sizeOfFieldCell
    : 200;

  const { data } = useGetTowersQuery();
  const content = data?.content;

  return (
    <ShopContentBackground $width={shopWidth}>
      <ShopContentWrapper>
        {content?.length
          && content.map((item) => <ShopItem key={item.id} tower={item} />)}
      </ShopContentWrapper>
    </ShopContentBackground>
  );
}
export default Shop;
