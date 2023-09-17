import { createBrowserRouter } from 'react-router-dom';
import React from 'react';
import PrivateRoute from '../Components/PrivateRoute';
import Root from './root';
import GameLayout from '../Components/Pages/GameLayout';
import Login from '../Components/Pages/Login';
import Registration from '../Components/Pages/Registration';
// import Home from '../Components/Pages/Home';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <PrivateRoute />,
    children: [
      {
        path: '/',
        element: <Root />,
        children: [
          {
            path: '/',
            element: <GameLayout />,
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
