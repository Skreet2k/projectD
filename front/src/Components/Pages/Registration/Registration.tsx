import React, { useState } from 'react';
import {
  Alert, Box, Button, TextField, Typography,
} from '@mui/material';
import axios from 'axios';
import { Link } from 'react-router-dom';
import { passwordStrength } from 'check-password-strength';

export function Registration() {
  const [username, setUsername] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const [error, setError] = useState<string | null>('');

  const finish = async () => {
    const passStrength = passwordStrength(password).value;

    if (passStrength === 'Medium' || passStrength === 'Strong') {
      const json = JSON.stringify({
        username,
        password,
        email: 'test@test.ru',
      });

      const data = await axios.post(
        'https://projectd.onebranch.dev/api/v1/register',
        json,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        },
      );

      // console.log(data);

      if (data.status === 200) {
        window.location.href = '/login';
      }

      if (data.status === 400) {
        setError(JSON.stringify(data.data.errors));
        setTimeout(() => {
          setError(null);
        }, 3000);
      }
    } else {
      setError('Пароль слишком слабый');
      setTimeout(() => {
        setError(null);
      }, 3000);
    }
  };

  return (
    <Box
      sx={{
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        backgroundImage:
          'url(https://media.tenor.com/MYZgsN2TDJAAAAAC/this-is.gif)',
        backgroundRepeat: 'no-repeat',
        backgroundSize: 'cover',
        height: '100dvh',
      }}
    >
      <Box
        sx={{
          background: 'white',
          padding: '20px',
          boxShadow:
            'rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px',
          display: 'flex',
          flexDirection: 'column',
          gap: '16px',
        }}
      >
        <Typography component="h1">Защитите релиз от злобных задач</Typography>
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
          id="outlined-basic"
          type="password"
          label="Пароль"
          variant="standard"
          error={!!error}
        />
        {error && (
          <Alert
            sx={{
              position: 'fixed',
              bottom: '10px',
              right: '10px',
            }}
            variant="outlined"
            severity="error"
          >
            {error}
          </Alert>
        )}

        <Button onClick={finish} variant="contained">
          Стать защитником
        </Button>
        <Link to="/login">Войти в аккаунт</Link>
      </Box>
    </Box>
  );
}
