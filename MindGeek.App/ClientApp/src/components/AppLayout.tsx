import { Container } from "@mui/material";
import { Outlet } from "react-router-dom";
import LoadingIndicator from "./LoadingIndicator";

export default function AppLayout() {
    return (
        <Container maxWidth={false}>
            <LoadingIndicator />
            <Outlet />
        </Container>
    )
}