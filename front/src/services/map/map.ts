import {
  createApi,
  fetchBaseQuery,
} from '@reduxjs/toolkit/query/react';
import { baseUrl } from '../constants';
import { MapPayload, MapResponse } from './map.types';

export const mapApi = createApi({
  reducerPath: 'map',
  baseQuery: fetchBaseQuery({ baseUrl }),
  tagTypes: ['FieldMap'],
  endpoints: (builder) => ({
    getMap: builder.query<MapResponse, MapPayload>({
      query: (arg) => {
        const {
          width,
          height,
          startX,
          startY,
          finishX,
          finishY,
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
      },
      providesTags: ['FieldMap'],
      // transformResponse: (response: { data: MapPayload }, meta, arg) => response.data,
    }),
  }),
});
export const { useGetMapQuery } = mapApi;
