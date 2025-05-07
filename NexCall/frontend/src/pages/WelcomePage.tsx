import { FC } from "react";
import styled from "styled-components";
import { motion } from "framer-motion";
import { Link } from "react-router-dom";
import { ModernButton } from "../components/ModernButton"; // предполагаемое местоположение кнопки

const Container = styled.div`
    width: 100vw;
    display: flex;
    flex-direction: column;
    min-height: 100vh;
    background-color: #1E1E1E;
    color: #FFFFFF;
`;

const Hero = styled.section`
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    flex: 1;
    padding: 4rem 2rem;
    background-color: transparent;
`;

const Title = styled.h1`
    font-size: 3rem;
    margin-bottom: 1rem;
    color: #FFFFFF;
`;

const Subtitle = styled.p`
    font-size: 1.25rem;
    max-width: 600px;
    text-align: center;
    color: #e0e0e0;
`;

const ButtonGroup = styled.div`
    margin-top: 2rem;
    display: flex;
    gap: 1rem;
    width: 100%;
    max-width: 400px;
`;

const WelcomePage: FC = () => {
    return (
        <Container>
            <Hero
                as={motion.section}
                initial={{ opacity: 0, y: -30 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ duration: 0.4, ease: "easeOut" }}>
                <Title>NexCall</Title>
                <Subtitle>
                    Современное приложение для безопасных видео- и аудиозвонков. Планируй встречи. Общайся. Защищай свою приватность.
                </Subtitle>
                <ButtonGroup>
                    <Link to="/login" style={{ width: '100%' }}><ModernButton text="Войти" /></Link>
                    <Link to="/register" style={{ width: '100%' }}><ModernButton text="Регистрация" /></Link>
                </ButtonGroup>
            </Hero>
        </Container>
    );
};

export default WelcomePage;
