import { useEffect, useRef, useState } from 'react';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { TPosition, TSocket, TSocketData } from './useSocketData.types';
import { Position } from '../../Components/Pages/GameLayout/PlayingField/PayingField.types';

export default function useSocketData(): TSocket {
  const [socketData, setSocketData] = useState<TSocketData | null>(null);
  const token = localStorage.getItem('token') || '';
  const uniqSocketRef = useRef(0);
  const prevToken = useRef(token);
  const [connection, setConnection] = useState<HubConnection | null>(null);
  const [path, setPath] = useState<Position[]>([]);
  const isSessionCreated = useRef(false);
  const isSessionStarted = useRef(false);

  const createSession = async () => {
    if (!connection || isSessionCreated.current) {
      // eslint-disable-next-line prefer-promise-reject-errors
      const errorInfo = { connection, isSessionCreated };
      // eslint-disable-next-line no-console
      console.error('can\'t create session', errorInfo);
      return Promise.resolve();
    }
    return connection.invoke('CreateSession')
      .then(({ Path }:{ Path:TPosition[] }) => {
        setPath(Path.map(({ X, Y }) => ({ x: X, y: Y })));
        isSessionCreated.current = true;
      });
  };

  const startSession = async () => {
    if (!connection || !isSessionCreated.current || isSessionStarted.current) {
      // eslint-disable-next-line prefer-promise-reject-errors
      const errorInfo = { connection, isSessionCreated, isSessionStarted };
      // eslint-disable-next-line no-console
      console.error('can\'t start session', errorInfo);
      return Promise.resolve();
    }
    // the returning promise is ever pending
    connection.invoke('StartSession');

    return new Promise((resolve) => {
      setTimeout(() => {
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
    path,
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
