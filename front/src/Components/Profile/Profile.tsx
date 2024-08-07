import React from 'react';
import {
  Avatar,
  Typography,
  ListItem,
  List,
  Drawer,
  Box,
  Button,
} from '@mui/material';
import { useSelector } from 'react-redux';
import UserStats from '../userStats/UserStats';
import { RootState } from '../../store/store';
import { playingFieldTheme } from '../../theme';

export default function Profile() {
  const [openDrawer, setOpenDrawer] = React.useState(false);
  const authData: any = useSelector((state: RootState) => state.auth.data);

  const toggleDrawer = (open: boolean) => {
    setOpenDrawer(open);
  };

  const exit = () => {
    localStorage.removeItem('token');
    localStorage.removeItem('refreshToken');
    window.location.href = '/login';
  };

  return (
    <React.Fragment key="right">
      <Button onClick={() => toggleDrawer(true)}>
        <Avatar>{authData?.username?.slice(0, 1)}</Avatar>
      </Button>
      <Drawer
        anchor="right"
        open={openDrawer}
        onClose={() => toggleDrawer(false)}
      >
        <Box
          sx={{
            background: playingFieldTheme.playingAreaBackground,
            height: '100%',
          }}
          onClick={() => toggleDrawer(false)}
        >
          <List>
            <ListItem>
              <Avatar sx={{ textTransform: 'uppercase' }}>
                {authData?.username?.slice(0, 1)}
              </Avatar>
              <Typography sx={{ paddingLeft: '8px' }}>
                {authData?.username}
              </Typography>
            </ListItem>
            <ListItem>
              <UserStats />
            </ListItem>
          </List>
        </Box>
        <Button onClick={exit}>Выйти</Button>
      </Drawer>
    </React.Fragment>
  );
}
