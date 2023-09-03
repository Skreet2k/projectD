import React from 'react';
import {
  AppBar, Box, Toolbar, Typography,
} from '@mui/material';
import Profile from '../Profile/Profile';
import Rating from '../Rating/Rating';

function Header() {
  return (
    <Box>
      <AppBar position="relative">
        <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            This is fine!
          </Typography>
          <Rating />
          <Profile />
        </Toolbar>
      </AppBar>
    </Box>
  );
}
export default Header;
