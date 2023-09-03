import React, { useContext, useEffect, useState } from 'react';
import {
  Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Slide,
} from '@mui/material';
import { TransitionProps } from '@mui/material/transitions';
import { SettingsContext } from '../Providers/SettingsContextProvider/SettingsContextProvider';
import { GameLayoutContext } from '../Providers/GameLayoutProvider/GameLayoutProvider';

const Transition = React.forwardRef((
  props: TransitionProps & {
    children: React.ReactElement<any, any>;
  },
  ref: React.Ref<unknown>,
) => <Slide direction="up" ref={ref} {...props} />);

function SettingsModal() {
  const { open, toggleOpen } = useContext(SettingsContext);
  const { socket, endData } = useContext(GameLayoutContext);
  // const [endData, setEndData] = useState<any>(null);
  const handleClose = () => {
    toggleOpen();
  };
  useEffect(() => {
    if (socket?.isGameEnded) {
      // setEndData({ ...socket?.endedGameData || {} });
      const { Score, TotalMoney, WavesCleared } = socket?.endedGameData || {};
      localStorage.setItem('thisIsFine', JSON.stringify({ Score, TotalMoney, WavesCleared }));
      endData.Score = Score;
      endData.TotalMoney = TotalMoney;
      endData.WavesCleared = WavesCleared;
    }
  }, [socket?.isGameEnded]);

  return (
    <Dialog
      open={open}
      TransitionComponent={Transition}
      keepMounted
      onClose={handleClose}
      aria-describedby="alert-dialog-slide-description"
    >
      <DialogTitle>Конец игры</DialogTitle>
      <DialogContent>
        <DialogContentText id="alert-dialog-slide-description">
          {`Очки: ${(JSON.parse(localStorage.getItem('thisIsFine') || '{}') as any).Score}`}
          <br />
          {`Заработано денег: ${(JSON.parse(localStorage.getItem('thisIsFine') || '{}') as any).TotalMoney}`}
          <br />
          {`Пройдено волн: ${(JSON.parse(localStorage.getItem('thisIsFine') || '{}') as any).WavesCleared}`}
        </DialogContentText>
      </DialogContent>
      <DialogActions>
        {/* <Button onClick={handleClose}>Disagree</Button> */}
        <Button onClick={handleClose}>Сохранить настройки</Button>
      </DialogActions>
    </Dialog>
  // <div></div>
  );
}
export default SettingsModal;
