import { createContext, Dispatch, SetStateAction, useState } from "react";

type SettingsContextProps = {
    open: boolean,
    toggleOpen: () => void,
    setOpen: Dispatch<SetStateAction<boolean>>
}
export const SettingsContext = createContext<SettingsContextProps>({
    open: false,
    toggleOpen: () => {},
    setOpen: () => {},
});

type SettingContextProviderProps = {
    children: React.ReactNode;
}

const SettingContextProvider = ({children}: SettingContextProviderProps ) => {
    const [modalOpen, setModalOpen] = useState(false);
    const toggleOpen = () => setModalOpen((val) => !val);
    return (
        <SettingsContext.Provider
            value={{
                open: modalOpen,
                toggleOpen,
                setOpen: setModalOpen,
            }}
        >
            {children}
        </SettingsContext.Provider>
    );
}
export default SettingContextProvider;