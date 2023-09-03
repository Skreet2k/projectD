import { Box, Button } from '@mui/material';
import React from 'react';
import { Link } from 'react-router-dom';
import { playingFieldTheme } from '../../../theme';

export default function Home() {
  return (
    <Box
      sx={{
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        width: '100%',
        background: playingFieldTheme.playingAreaBackground,
      }}
    >
      <Link to="/game">
        <Button sx={{ width: '200px' }} variant="contained">
          Play
        </Button>
      </Link>
    </Box>
  );
}
