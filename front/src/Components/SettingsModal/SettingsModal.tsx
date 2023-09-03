import React, { useContext } from 'react';
import {
  Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Slide,
} from '@mui/material';
import { TransitionProps } from '@mui/material/transitions';
import { SettingsContext } from '../Providers/SettingsContextProvider/SettingsContextProvider';

const Transition = React.forwardRef((
  props: TransitionProps & {
    children: React.ReactElement<any, any>;
  },
  ref: React.Ref<unknown>,
) => <Slide direction="up" ref={ref} {...props} />);

function SettingsModal() {
  const { open, toggleOpen } = useContext(SettingsContext);
  const handleClose = () => {
    toggleOpen();
  };
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
          Модальное окно для показа пользователю его армии и возможности прокачки его героев
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
