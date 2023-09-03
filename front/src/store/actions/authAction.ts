import { createAsyncThunk } from '@reduxjs/toolkit';

import { api } from '../../lib/axios';

export const loginWithPassword = createAsyncThunk(
  'auth/loginWithPassword',
  async (_: { username: string; password: string }, { rejectWithValue }) => {
    try {
      const { data } = await api.post('/login', {
        username: _.username,
        password: _.password,
      });

      localStorage.setItem('token', data.access_token);
      localStorage.setItem('refreshToken', data.refresh_token);

      return data;
    } catch (e: any) {
      if (e.response.status === 401) {
        return rejectWithValue('Неверный логин или пароль');
      }

      return rejectWithValue('Что-то пошло не так, повторите позже');
    }
  },
);

export const loginWithToken = createAsyncThunk(
  'auth/loginWithToken',
  async (token: string, { rejectWithValue }) => {
    try {
      const { data } = await api.get('/account/info', {
        headers: { Authorization: `Bearer ${token}` },
      });

      return data;
    } catch (e) {
      return rejectWithValue('');
    }
  },
);
