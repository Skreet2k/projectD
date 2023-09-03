import {
  createApi,
  fetchBaseQuery,
} from '@reduxjs/toolkit/query/react';
import { baseUrl } from '../constants';
import { DeveloperLevel, TowerType } from '../../Components/Pages/GameLayout/PlayingField/TowersLayer/TowerLayer.types';

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
  }),
});
export const { useGetTowersQuery } = towersApi;
