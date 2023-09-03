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
  const { socket } = useContext(GameLayoutContext);
  const [endData, setEndData] = useState<any>({});
  const handleClose = () => {
    toggleOpen();
  };
  useEffect(() => {
    if (socket?.isGameEnded) {
      setEndData(socket?.endedGameData || {});
    }
  }, [socket?.isGameEnded]);

  console.log(endData, socket);
  const { Score, TotalMoney, WavesCleared } = endData;
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
          `Очки: $
          {Score || '?'}
          `
          <br />
          `Заработано денег: $
          {TotalMoney || '?'}
          `
          <br />
          `Пройдено волн: $
          {WavesCleared || '?'}
          `
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
