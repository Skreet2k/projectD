import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { loginWithPassword, loginWithToken } from '../actions/authAction';

const initialState = {
  isLogin: false,
  error: null,
  loading: false,
  data: {},
};

export const authSlice = createSlice({
  name: 'counter',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(loginWithPassword.fulfilled, (state) => {
        state.isLogin = true;
        state.loading = false;
      })
      .addCase(loginWithPassword.pending, (state) => {
        state.loading = true;
      })
      .addCase(
        loginWithPassword.rejected,
        (state, action: PayloadAction<any>) => {
          state.loading = false;
          state.error = action.payload;
        },
      );
    builder
      .addCase(
        loginWithToken.fulfilled,
        (state, action: PayloadAction<any>) => {
          state.isLogin = true;
          state.loading = false;
          state.data = action.payload;
        },
      )
      .addCase(loginWithToken.pending, (state) => {
        state.loading = true;
      })
      .addCase(loginWithToken.rejected, (state, action: PayloadAction<any>) => {
        state.loading = false;
        state.error = action.payload;
      });
  },
});

export default authSlice.reducer;
