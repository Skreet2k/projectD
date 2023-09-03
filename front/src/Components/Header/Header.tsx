import React from 'react';
import {
  AppBar, Box, Toolbar, Typography,
} from '@mui/material';
import Profile from '../Profile/Profile';

function Header() {
  return (
    <Box>
      <AppBar position="relative">
        <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Simbirwars
          </Typography>
          <Profile />
        </Toolbar>
      </AppBar>
    </Box>
  );
}
export default Header;
