import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { Outlet, useNavigate } from 'react-router-dom';
import { AppDispatch } from '../store/store';
import { loginWithToken } from '../store/actions/authAction';

export default function PrivateRoute() {
  const navigate = useNavigate();
  const dispatch = useDispatch<AppDispatch>();

  const token = localStorage.getItem('token');

  useEffect(() => {
    const fetch = async () => {
      if (token) {
        const status = await dispatch(
          loginWithToken(token),
        );

        if (!(status.meta.requestStatus === 'fulfilled')) {
          navigate('/login');
        }
      } else {
        navigate('/login');
      }
    };
    fetch();
  }, []);

  return <Outlet />;
}
