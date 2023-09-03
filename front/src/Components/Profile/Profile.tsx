import React from 'react';
import Box from '@mui/material/Box';
import Drawer from '@mui/material/Drawer';
import Button from '@mui/material/Button';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import { Avatar, Typography } from '@mui/material';
import { useSelector } from 'react-redux';
import UserStats from '../userStats/UserStats';
import { RootState } from '../../store/store';

export default function Profile() {
  const [openDrawer, setOpenDrawer] = React.useState(false);
  const authData: any = useSelector((state: RootState) => state.auth.data);

  const toggleDrawer = (open: boolean) => {
    setOpenDrawer(open);
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
          sx={{ background: '#ffab40', height: '100%' }}
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
      </Drawer>
    </React.Fragment>
  );
}
