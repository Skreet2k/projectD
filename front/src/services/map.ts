import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { baseUrl } from './constants';
import { Position } from '../Components/Pages/GameLayout/PlayingField/PayingField.types';

// export const pokemonApi = createApi({
//   baseQuery: fetchBaseQuery({ baseUrl: 'https://pokeapi.co/api/v2/' }),
//   tagTypes: [],
//   endpoints: (builder) => ({
//     getPokemonByName: builder.query({
//       query: (name: string) => `pokemon/${name}`,
//     }),
//   }),
// });

export interface MapResponse {
  errorMessage: 'string',
  returnCode: number,
  isSuccess: true,
  content: {
    width: number,
    height: number,
    path: Position[],
  }
}

interface MapPayload {
  width: number;
  height: number;
  startX: number;
  startY: number;
  finishX: number;
  finishY: number;
}

export const mapApi = createApi({
  baseQuery: fetchBaseQuery({ baseUrl }),
  endpoints: (builder) => ({
    getMap: builder.query<MapResponse, MapPayload>({
      query: ((arg) => {
        const {
          width, height, startX, startY, finishX, finishY,
        } = arg;
        return {
          url: '/map',
          params: {
            width,
            height,
            startX,
            startY,
            finishX,
            finishY,
          },
        };
      }),
      // transformResponse: (response: { data: MapPayload }, meta, arg) => response.data,
    }),
  }),
});
export const { useGetMapQuery } = mapApi;
