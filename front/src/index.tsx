import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { Provider } from 'react-redux';
import reportWebVitals from './reportWebVitals';
import Root from './routes/root';
import About from './Components/Pages/About';
import GameLayout from './Components/Pages/GameLayout';
import Login from './Components/Pages/Login';
import Registration from './Components/Pages/Registration';
import { store } from './store';

const router = createBrowserRouter([
  {
    path: '/',
    element: <Root />,
    // errorElement: <ErrorPage/>,
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
  {
    path: 'login',
    element: <Login />,
  },
  {
    path: 'registration',
    element: <Registration />,
  },
]);

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement,
);
root.render(
  <React.StrictMode>
    <Provider store={store}>
      <RouterProvider router={router} />
    </Provider>
  </React.StrictMode>,
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
