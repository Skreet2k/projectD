import React, { useContext } from 'react';
import {
  AppBar, Box, IconButton, Toolbar, Typography,
} from '@mui/material';
import { Menu as MenuIcon } from '@mui/icons-material';
import { SettingsContext } from '../Providers/SettingsContextProvider/SettingsContextProvider';

function Header() {
  const { toggleOpen } = useContext(SettingsContext);
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Simbirwars
          </Typography>
          {/* <Button color="inherit">Login</Button> */}
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2 }}
            onClick={toggleOpen}
          >
            <MenuIcon />
          </IconButton>
        </Toolbar>
      </AppBar>
    </Box>
  );
}
export default Header;
