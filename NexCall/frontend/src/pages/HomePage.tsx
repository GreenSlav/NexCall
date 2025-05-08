import { FC } from "react";
import styled from "styled-components";
import AuthPage from "./AuthPage";
import {useErrorBanner} from "../hooks/useErrorBanner";
import {ErrorBanner} from "../components/ErrorBanner";

const Container = styled.div`
    width: 100vw;
    display: flex;
    flex-direction: column;
    min-height: 100vh;
    background-color: #1E1E1E;
    color: #FFFFFF;
`;

const WelcomePage: FC = () => {
    const API_BASE_URL = import.meta.env.VITE_REACT_APP_BACKEND_URL;
    const { isError, messageError, showError } = useErrorBanner();

    return (
        <AuthPage>
            <Container>
                <ErrorBanner isVisible={isError} message={messageError} />
            </Container>
        </AuthPage>
    );
};

export default WelcomePage;
