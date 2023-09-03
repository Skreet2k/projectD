import React, {
  createContext, Dispatch, SetStateAction, useMemo, useState,
} from 'react';

type SettingsContextProps = {
  open: boolean,
  toggleOpen: () => void,
  setOpen: Dispatch<SetStateAction<boolean>>
};
export const SettingsContext = createContext<SettingsContextProps>({
  open: false,
  toggleOpen: () => {},
  setOpen: () => {},
});

type SettingContextProviderProps = {
  children: React.ReactNode;
};

function SettingContextProvider({ children }: SettingContextProviderProps) {
  const [modalOpen, setModalOpen] = useState(false);
  const toggleOpen = () => {
    setModalOpen((val) => !val);
  };
  const settingsContext = useMemo(() => ({
    open: modalOpen,
    toggleOpen,
    setOpen: setModalOpen,
  }), [modalOpen]);
  return (
    <SettingsContext.Provider
      value={settingsContext}
    >
      {children}
    </SettingsContext.Provider>
  );
}
export default SettingContextProvider;
