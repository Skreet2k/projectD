import {
  combineReducers,
  configureStore,
} from '@reduxjs/toolkit';
import { setupListeners } from '@reduxjs/toolkit/query';
import { mapApi } from '../services/map';
import counterReducer from './slices/counterSlice';
import authReducer from './slices/authSlice';

const rootReducer = combineReducers({
  [mapApi.reducerPath]: mapApi.reducer,
  counter: counterReducer,
  auth: authReducer,
});
export const store = configureStore({
  reducer: rootReducer,
  middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(mapApi.middleware),
});

setupListeners(store.dispatch);
export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
