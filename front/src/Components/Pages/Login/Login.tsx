import React, { FormEvent, useEffect, useState } from 'react';
import {
  Box, Button, TextField, Typography,
} from '@mui/material';
import { Link, useNavigate } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { loginWithPassword } from '../../../store/actions/authAction';
import { AppDispatch, RootState } from '../../../store/store';

export function Login() {
  const [username, setUsername] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();
  const isLogin = useSelector((state: RootState) => state.auth.isLogin);

  useEffect(() => {
    if (isLogin) {
      navigate('/');
    }
  }, [isLogin]);

  const finish = async (e: FormEvent) => {
    dispatch(loginWithPassword({ username, password }));
    e.preventDefault();
  };

  return (
    <Box
      sx={{
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        height: '100dvh',
        backgroundImage:
          'url(https://media.tenor.com/MYZgsN2TDJAAAAAC/this-is.gif)',
        backgroundRepeat: 'no-repeat',
        backgroundSize: 'cover',
      }}
    >
      <form onSubmit={finish}>
        <Box
          sx={{
            width: '307px',
            background: 'white',
            padding: '20px',
            boxShadow:
              'rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px',
            display: 'flex',
            flexDirection: 'column',
            gap: '16px',
            opacity: '0.95',
          }}
        >
          <Typography component="h1">Войти</Typography>
          <TextField
            value={username}
            onChange={(e) => setUsername(e.target?.value)}
            id="outlined-basic"
            label="Логин"
            variant="standard"
          />
          <TextField
            value={password}
            onChange={(e) => setPassword(e.target?.value)}
            type="password"
            id="outlined-basic"
            label="Пароль"
            variant="standard"
          />
          <Button type="submit" variant="contained">
            Войти в IT
          </Button>
          <Link to="/registration">Стать защитником</Link>
        </Box>
      </form>
    </Box>
  );
}
