import React from 'react';
import { Outlet } from 'react-router-dom';
import { Box } from '@mui/material';
import Header from './Header/Header';
import SettingsModal from './SettingsModal';

function Main() {
  return (
    <Box sx={{ display: 'flex', flexDirection: 'column', height: '100vh' }}>
      <Header />
      <Box sx={{ display: 'flex', flex: '1 1 auto' }}>
        <Outlet />
      </Box>
      <SettingsModal />
    </Box>
  );
}

export default Main;
