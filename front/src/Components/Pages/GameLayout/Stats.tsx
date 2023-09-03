import React, { useContext } from 'react';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemAvatar from '@mui/material/ListItemAvatar';
import Avatar from '@mui/material/Avatar';
import SportsScoreIcon from '@mui/icons-material/SportsScore';
import AttachMoneyIcon from '@mui/icons-material/AttachMoney';
import WavesIcon from '@mui/icons-material/Waves';
import FavoriteBorderIcon from '@mui/icons-material/FavoriteBorder';
import { deepOrange } from '@mui/material/colors';

import { GameLayoutContext } from '../../Providers/GameLayoutProvider/GameLayoutProvider';

export default function Stats() {
  const { socket }: any = useContext(GameLayoutContext);

  return (
    <div>
      <List>
        <ListItem>
          <ListItemAvatar>
            <Avatar sx={{ bgcolor: deepOrange[500] }}>
              <SportsScoreIcon />
            </Avatar>
          </ListItemAvatar>
          Очки:&nbsp;
          {socket?.socketData?.Score}
        </ListItem>
        <ListItem>
          <ListItemAvatar>
            <Avatar sx={{ bgcolor: deepOrange[500] }}>
              <AttachMoneyIcon />
            </Avatar>
          </ListItemAvatar>
          Деньги:&nbsp;
          {socket?.socketData?.TotalMoney}
        </ListItem>
        <ListItem>
          <ListItemAvatar>
            <Avatar sx={{ bgcolor: deepOrange[500] }}>
              <WavesIcon />
            </Avatar>
          </ListItemAvatar>
          Волна:&nbsp;
          {socket?.socketData?.CurrentWave}
        </ListItem>
        <ListItem>
          <ListItemAvatar>
            <Avatar sx={{ bgcolor: deepOrange[500] }}>
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
