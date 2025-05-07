import { FC } from "react";
import styled from "styled-components";
import AuthPage from "./AuthPage";

const Container = styled.div`
    width: 100vw;
    display: flex;
    flex-direction: column;
    min-height: 100vh;
    background-color: #1E1E1E;
    color: #FFFFFF;
`;

const WelcomePage: FC = () => {
    return (
        <AuthPage>
            <Container>
            </Container>
        </AuthPage>
    );
};

export default WelcomePage;
