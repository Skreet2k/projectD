import { useEffect, useRef, useState } from 'react';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { NullableSocketData, TSocketData } from './useSocketData.types';

export default function useSocketData(): NullableSocketData {
  const [socketData, setSocketData] = useState<NullableSocketData>(null);
  const token = localStorage.getItem('token') || '';
  const uniqSocketRef = useRef(0);
  const prevToken = useRef(token);

  useEffect(() => {
    const closureId = Math.random();
    if (prevToken.current !== token) {
      uniqSocketRef.current = 0;
      prevToken.current = token;
    }
    uniqSocketRef.current ||= closureId;
    const amIClone = closureId !== uniqSocketRef.current;
    if (amIClone) {
      return;
    }

    const connection = new HubConnectionBuilder()
      .withUrl('https://projectd.onebranch.dev/hubs/game', { accessTokenFactory: () => token })
      .build();

    connection.on('UpdateClient', (data: TSocketData) => {
      setSocketData(data);
    });

    connection.start()
      .then(() => connection.invoke('CreateSession'))
      .then(() => connection.invoke('StartSession'));

    // return () => {
    //   connection.stop();
    // };
  }, [token]);
  return socketData;
}
