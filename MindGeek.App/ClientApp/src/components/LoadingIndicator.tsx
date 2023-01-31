import { Backdrop, CircularProgress } from "@mui/material";
import { usePromiseTracker } from "react-promise-tracker";

export default function LoadingIndicator() {
    const { promiseInProgress } = usePromiseTracker({delay: 50});
    if (promiseInProgress) {
        return (
            <Backdrop sx={{color: '#fff', zIndex: (theme: any) => theme.zIndex.drawer + 1}} open={true}>
                <CircularProgress color="inherit" />
            </Backdrop>
        )
    }
    return <></>
}