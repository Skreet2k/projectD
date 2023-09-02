import axios, { AxiosError, AxiosResponse } from 'axios';

export const api: any = axios.create({
  baseURL: 'https://projectd.onebranch.dev/api/v1',
  headers: {
    'Content-Type': 'application/json',
  },
});

api.interceptors.response.use(
  async (response: AxiosResponse) => response,
  async (error: AxiosError) => {
    const {
      responseType,
      method,
      data: body,
    }: any = error?.response?.config;
    const url = error?.response?.request.responseURL;

    if (error?.response?.status === 401) {
      try {
        const refreshToken = localStorage.getItem('refreshToken');

        const { data } = await axios.post(
          'https://projectd.onebranch.dev/api/v1/refresh',
          {
            refreshToken,
          },
        );

        localStorage.setItem('token', data.access_token);
        localStorage.setItem(
          'refreshToken',
          data.refresh_token,
        );

        const res = await axios({
          method,
          url,
          data: body,
          headers: {
            Authorization: `Bearer ${data.token}`,
            responseType,
          },
        });

        return res;
      } catch (e) {
        window.location.replace('/login');
      }
    }
    return Promise.reject(error.message);
  },
);
