import React, { useContext } from 'react';
import styled from 'styled-components';
import { GameLayoutContext } from '../../../Providers/GameLayoutProvider/GameLayoutProvider';
import { DeveloperLevel, TowerType } from '../../../../assets/towers';
import ShopItem from './ShopItem/ShopItem';

export const ShopContentWrapper = styled.div<{ $width: number }>`
    width: ${(props) => `${props.$width}px`};
    position: relative;
`;
function Shop() {
  // ширина в 3 ячейки
  const { fieldParams } = useContext(GameLayoutContext);
  const shopWidth = fieldParams?.sizes?.sizeOfFieldCell ? +fieldParams?.sizes.sizeOfFieldCell * 3 : 400;

  const ShopItems = [{
    type: TowerType.frontend,
    level: DeveloperLevel.junior,
  }, {
    type: TowerType.frontend,
    level: DeveloperLevel.middle,
  },
  {
    type: TowerType.frontend,
    level: DeveloperLevel.senior,
  },
  ];

  return (
    <ShopContentWrapper $width={shopWidth}>
      <ShopItem type={TowerType.frontend} level={DeveloperLevel.junior} />
      <ShopItem type={TowerType.frontend} level={DeveloperLevel.middle} />
      <ShopItem type={TowerType.frontend} level={DeveloperLevel.senior} />
    </ShopContentWrapper>
  );
}
export default Shop;
