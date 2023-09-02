import {Outlet} from "react-router-dom";
import Header from "../Components/Header/Header";
import {Box} from "@mui/material";
import SettingsModal from "./SettingsModal";

const Main = () => {

    return (
        <Box>
            <Header />
            <Box>
                <Outlet/>
            </Box>
            <SettingsModal/>
            {/* TODO move to separate drawer with context {settingsModalOpen &&*/}
            {/*    <Drawer*/}
            {/*        variant="persistent"*/}
            {/*        anchor="bottom"*/}
            {/*        open={settingsModalOpen}*/}
            {/*>*/}
            {/*    <div>*/}
            {/*        <IconButton onClick={toggleOpen}>*/}
            {/*            <ChevronLeftIcon />*/}
            {/*        </IconButton>*/}
            {/*    </div>*/}
            {/*    <Divider />*/}
            {/*        <div>1</div>*/}
            {/*        <div>2</div>*/}
            {/*</Drawer>}*/}
        </Box>
    );
}

export default Main;