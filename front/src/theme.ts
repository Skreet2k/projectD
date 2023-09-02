import { createTheme } from '@mui/material/styles';

export const playingField = {
  cell: {
    light: '#ffd180',
    light2: '#fff9c4',
  },
  playingAreaBackground: '#ffab40',
};

export const theme = createTheme({
  palette: {
    primary: { main: '#f4511e', light: '#f6734b', dark: '#aa3815' },
    secondary: { main: '#ff9100', light: '#ffa733', dark: '#b26500' },
  },
});
