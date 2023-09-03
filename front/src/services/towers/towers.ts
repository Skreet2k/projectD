import {
  createApi,
  fetchBaseQuery,
} from '@reduxjs/toolkit/query/react';
import { baseUrl } from '../constants';
import { DeveloperLevel, TowerType } from '../../Components/Pages/GameLayout/PlayingField/TowersLayer/TowerLayer.types';
import { TPosition } from '../../api/useSocketData/useSocketData.types';

export interface Tower {
  cost: number;
  damage: number;
  healthPoints: number;
  id: string;
  level: DeveloperLevel;
  name: string;
  range: number;
  type: TowerType;
}
interface TowerResponse {
  content: Tower[];
  count: number;
  errorMessage: string | null;
  isSuccess: boolean;
  returnCode: number;
}

interface SetTowerPayload {
  id: string;
  coordinate: TPosition;
}
export const towersApi = createApi({
  reducerPath: 'towers',
  baseQuery: fetchBaseQuery({ baseUrl }),
  tagTypes: ['Towers'],
  endpoints: (builder) => ({
    getTowers: builder.query<TowerResponse, void>({
      query: () => {
        const token = localStorage.getItem('token');
        return ({
          url: '/workers',
          method: 'GET',
          headers: { Authorization: `Bearer ${token}` },
        });
      },
      providesTags: ['Towers'],
    }),
    addTower: builder.mutation<void, SetTowerPayload>({
      query: (payload) => {
        const token = localStorage.getItem('token');
        return ({
          url: '/workers',
          method: 'POST',
          headers: { Authorization: `Bearer ${token}` },
          body: {
            Id: payload.id,
            coordinate: payload.coordinate,
          },
        });
      },
    }),
  }),
});
export const { useGetTowersQuery, useAddTowerMutation } = towersApi;
