import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import {
  createBrowserRouter,
  RouterProvider,
} from 'react-router-dom';
import { Provider } from 'react-redux';
import {
  createTheme,
  ThemeProvider,
} from '@mui/material/styles';
import reportWebVitals from './reportWebVitals';
import Root from './routes/root';
import About from './Components/Pages/About';
import GameLayout from './Components/Pages/GameLayout';
import Login from './Components/Pages/Login';
import Registration from './Components/Pages/Registration';
import { store } from './store/store';
import PrivateRoute from './Components/PrivateRoute';

const router = createBrowserRouter([
  {
    path: '/',
    element: <PrivateRoute />,
    // errorElement: <ErrorPage/>,
    children: [
      {
        path: '/',
        element: <Root />,
        children: [
          {
            path: 'game',
            element: <GameLayout />,
          },
          {
            path: 'about',
            element: <About />,
          },
        ],
      },
    ],
  },
  {
    path: 'login',
    element: <Login />,
  },
  {
    path: 'registration',
    element: <Registration />,
  },
]);

const theme = createTheme({
  palette: {
    primary: { main: '#FF5733' },
    action: { hover: '#FFC79A' },
  },
});

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

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
