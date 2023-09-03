import { Box, Button } from '@mui/material';
import React from 'react';
import { Link } from 'react-router-dom';

export default function Home() {
  return (
    <Box
      sx={{
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        width: '100%',
        background: '#ffab40',
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
