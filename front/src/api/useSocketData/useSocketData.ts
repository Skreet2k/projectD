import { useEffect, useRef, useState } from 'react';
// eslint-disable-next-line import/no-extraneous-dependencies
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
  const [isGameEnded, setIsGameEnded] = useState(false);
  const endedGameData = useRef<any>({});

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

  const callMethod = async (methodName: string, args: any) => {
    if (!connection) {
      const errorInfo = {
        args, connection, isSessionCreated, isSessionStarted,
      };
      // eslint-disable-next-line no-console
      console.error(`can't call ${methodName}`, errorInfo);
      return Promise.resolve();
    }
    return connection.invoke(methodName, args);
  };

  const addWorker = async (args: any) => callMethod('AddWorker', args);
  const removeWorker = async (args: any) => callMethod('RemoveWorker', args);

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

    hubConnection.on('EndGame', (gameData: any) => {
      console.log(gameData);
      setIsGameEnded(true);
      endedGameData.current = gameData;
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
    isGameEnded,
    endedGameData: endedGameData.current,
  };
}
