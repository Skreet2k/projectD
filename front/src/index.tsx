import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import {
  RouterProvider,
} from 'react-router-dom';
import { Provider } from 'react-redux';
import {
  ThemeProvider,
} from '@mui/material/styles';
import { store } from './store/store';
import { theme } from './theme';
import { router } from './routes/routes';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement,
);
root.render(
  <React.StrictMode>
    <Provider store={store}>
      <ThemeProvider theme={theme}>
        <RouterProvider router={router} />
      </ThemeProvider>
    </Provider>
  </React.StrictMode>,
);
