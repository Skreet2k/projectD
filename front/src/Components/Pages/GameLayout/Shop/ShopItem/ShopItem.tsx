import React, { useContext } from 'react';
import styled from 'styled-components';
import {
  Box, Card, CardActionArea, CardContent, CardMedia, keyframes, Paper, Typography,
} from '@mui/material';
import { DeveloperLevel, towers, TowerType } from '../../../../../assets/towers';
import { GameLayoutContext } from '../../../../Providers/GameLayoutProvider/GameLayoutProvider';

const spriteAnimation = (x: number) => keyframes`
  from{background-position-x:0;}
  to{background-position-x: -${x}px;}
`;

const ShopItemContainer = styled.div<{ $size: number, $background: string }>`
  width: ${(props) => `${props.$size}px`};
  height: ${(props) => `${props.$size}px`};
  background-image: ${(props) => `url(${props.$background})`};
  background-size: cover;
  animation : ${(props) => spriteAnimation(props.$size * 3)} 1s steps(3) infinite;
`;

type ShopItemProps = {
  type: TowerType,
  level: DeveloperLevel,
};
function ShopItem({ type, level }: ShopItemProps) {
  const { sizes } = useContext(GameLayoutContext);
  const size = sizes?.sizeOfFieldCell;

  const background = towers[type][level];

  return (
    <Card sx={{ maxWidth: size ? size + 15 : 100 }}>
      <CardActionArea>
        <CardMedia>
          {size && <ShopItemContainer $size={size} $background={background} />}
        </CardMedia>
        <CardContent>
          <Typography gutterBottom variant="h5" component="div">
            Lizard
          </Typography>
          <Typography variant="body2" color="text.secondary">
            Lizards are a widespread group of squamate reptiles, with over 6,000
            species, ranging across all continents except Antarctica
          </Typography>
        </CardContent>
      </CardActionArea>
    </Card>
  );
}

export default ShopItem;
