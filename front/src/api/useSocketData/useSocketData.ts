import { useEffect, useRef, useState } from 'react';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { TSocket, TSocketData } from './useSocketData.types';

export default function useSocketData(): TSocket {
  const [socketData, setSocketData] = useState<TSocketData | null>(null);
  const token = localStorage.getItem('token') || '';
  const uniqSocketRef = useRef(0);
  const prevToken = useRef(token);
  const [connection, setConnection] = useState<HubConnection | null>(null);
  const isSessionCreated = useRef(false);
  const isSessionStarted = useRef(false);

  const createSession = async () => {
    if (!connection || isSessionCreated.current) {
      // eslint-disable-next-line prefer-promise-reject-errors
      return Promise.reject({ connection, isSessionCreated });
    }
    return connection.invoke('CreateSession')
      .then(() => {
        isSessionCreated.current = true;
      });
  };

  const startSession = async () => {
    if (!connection || !isSessionCreated.current || isSessionStarted.current) {
      // eslint-disable-next-line prefer-promise-reject-errors
      return Promise.reject({ connection, isSessionCreated, isSessionStarted });
    }
    // the returning promise is ever pending
    connection.invoke('StartSession');

    return new Promise((resolve) => {
      setTimeout(() => {
        console.info('session started');
        isSessionStarted.current = true;
        resolve(true);
      }, 200);
    });
  };

  const callMethod = async (methodName: string) => {
    if (!connection) {
      // eslint-disable-next-line prefer-promise-reject-errors
      return Promise.reject({ connection, isSessionCreated });
    }
    return connection.invoke(methodName);
  };
  const addWorker = async () => callMethod('AddWorker');
  const removeWorker = async () => callMethod('RemoveWorker');

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

    const hubConnection = new HubConnectionBuilder()
      .withUrl('https://projectd.onebranch.dev/hubs/game', { accessTokenFactory: () => token })
      .build();

    hubConnection.on('UpdateClient', (data: TSocketData) => {
      setSocketData(data);
    });

    hubConnection.start()
      .then(() => {
        setConnection(hubConnection);
      });
  }, [token]);
  return {
    socketData,
    createSession,
    startSession,
    addWorker,
    removeWorker,
    connection,
    isSessionCreated: isSessionCreated.current,
    isSessionStarted: isSessionStarted.current,
  };
}
