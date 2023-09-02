import SettingsContextProvider from "../Components/Providers/SettingsContextProvider";
import Main from "../Components/Main";


export default function Root() {
    return (
       <SettingsContextProvider>
            <Main/>
       </SettingsContextProvider>
    );
}