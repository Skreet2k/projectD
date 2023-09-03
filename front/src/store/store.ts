import {
  combineReducers,
  configureStore,
} from '@reduxjs/toolkit';
import { setupListeners } from '@reduxjs/toolkit/query';
import { mapApi } from '../services/map/map';
import authReducer from './slices/authSlice';
import gameLayoutReducer from './slices/gameLayoutSlice';
import { towersApi } from '../services/towers/towers';

const rootReducer = combineReducers({
  [mapApi.reducerPath]: mapApi.reducer,
  [towersApi.reducerPath]: towersApi.reducer,
  gameLayout: gameLayoutReducer,
  auth: authReducer,
});

export const store = configureStore({
  reducer: rootReducer,
  // @ts-ignore
  middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat([mapApi.middleware, towersApi.middleware]),
});

setupListeners(store.dispatch);

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
