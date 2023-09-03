import React, { useContext, useEffect } from 'react';
import styled from 'styled-components';
import {
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
  keyframes,
  Typography,
} from '@mui/material';
import { useDispatch, useSelector } from 'react-redux';
import {
  towers,
} from '../../../../../assets/towers';
import { GameLayoutContext } from '../../../../Providers/GameLayoutProvider/GameLayoutProvider';
import { RootState } from '../../../../../store/store';
import { setSelectedShopTower } from '../../../../../store/slices/gameLayoutSlice';
import { DeveloperLevel, TowerType } from '../../PlayingField/TowersLayer/TowerLayer.types';
import { Tower } from '../../../../../services/towers/towers';

const spriteAnimation = (x: number) => keyframes`
  from{background-position-x:0;}
  to{background-position-x: -${x}px;}
`;

const ShopItemContainer = styled.div<{
  $size: number;
  $background: string;
}>`
  width: ${(props) => `${props.$size}px`};
  height: ${(props) => `${props.$size}px`};
  background-image: ${(props) => `url(${props.$background})`};
  background-size: cover;
  animation: ${(props) => spriteAnimation(props.$size * 3)}
    1s steps(3) infinite;
`;

type ShopItemProps = {
  tower: Tower;
};
function ShopItem({ tower }: ShopItemProps) {
  const dispatch = useDispatch();
  const { sizes } = useContext(GameLayoutContext);

  const {
    level, type, name, id,
  } = tower;

  const size = sizes?.sizeOfFieldCell;

  const shopTowerSelected = useSelector(
    (state: RootState) => state.gameLayout.shopTowerSelected,
  );

  const background = towers[type][level];

  return (
    <Card
      sx={{ maxWidth: size ? size + 15 : 100, height: 'fit-content' }}
    >
      <CardActionArea
        onClick={() => {
          dispatch(setSelectedShopTower({ id }));
        }}
      >
        <CardMedia sx={{
          display: 'flex',
          justifyContent: 'center',
          padding: '10px',
        }}
        >
          {size && (
            <ShopItemContainer
              $size={size}
              $background={background}
            />
          )}
        </CardMedia>
        <CardContent>
          <Typography
            gutterBottom
            variant="subtitle2"
            component="div"
          >
            {name}
          </Typography>
        </CardContent>
      </CardActionArea>
    </Card>
  );
}

export default ShopItem;
