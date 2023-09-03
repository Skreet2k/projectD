import React, { useContext } from 'react';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemAvatar from '@mui/material/ListItemAvatar';
import Avatar from '@mui/material/Avatar';
import SportsScoreIcon from '@mui/icons-material/SportsScore';
import AttachMoneyIcon from '@mui/icons-material/AttachMoney';
import WavesIcon from '@mui/icons-material/Waves';
import FavoriteBorderIcon from '@mui/icons-material/FavoriteBorder';

import { GameLayoutContext } from '../../Providers/GameLayoutProvider/GameLayoutProvider';
import { playingFieldTheme } from '../../../theme';

export default function Stats() {
  const { socket }: any = useContext(GameLayoutContext);
  return (
    <div>
      <List>
        <ListItem>
          <ListItemAvatar>
            <Avatar sx={{ backgroundColor: playingFieldTheme.statsColor }}>
              <SportsScoreIcon />
            </Avatar>
          </ListItemAvatar>
          Очки:&nbsp;
          {socket?.socketData?.Score}
        </ListItem>
        <ListItem>
          <ListItemAvatar>
            <Avatar sx={{ bgcolor: playingFieldTheme.statsColor }}>
              <AttachMoneyIcon />
            </Avatar>
          </ListItemAvatar>
          Деньги:&nbsp;
          {socket?.socketData?.Money}
        </ListItem>
        <ListItem>
          <ListItemAvatar>
            <Avatar sx={{ bgcolor: playingFieldTheme.statsColor }}>
              <WavesIcon />
            </Avatar>
          </ListItemAvatar>
          Волна:&nbsp;
          {socket?.socketData?.CurrentWave}
        </ListItem>
        <ListItem>
          <ListItemAvatar>
            <Avatar sx={{ bgcolor: playingFieldTheme.statsColor }}>
              <FavoriteBorderIcon />
            </Avatar>
          </ListItemAvatar>
          Здоровье:&nbsp;
          {socket?.socketData?.CurrentHealthPoints}
        </ListItem>
      </List>
    </div>
  );
}
