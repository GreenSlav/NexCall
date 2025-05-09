import { FC, useEffect, useState } from "react";
import { useNavigate, useParams, useLocation } from "react-router-dom";
import styled from "styled-components";
import {useErrorBanner} from "../hooks/useErrorBanner";
import {ErrorBanner} from "../components/ErrorBanner";
import {motion} from "framer-motion";

const Container = styled.div`
    width: 100vw;
    height: 100vh;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 2rem;
    color: white;
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

const Title = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 1.5rem;
    margin-bottom: 2rem;
    text-align: center;
`

const CodeInput = styled.input`
    font-size: 2rem;
    text-align: center;
    padding: 0.5rem;
    width: 15rem;
    letter-spacing: 0.5rem;
    background-color: #1e1e1e;
    border: 2px solid white;
    border-radius: 8px;
    color: white;
`;

const Timer = styled.p`
    margin-top: 1rem;
    font-size: 1.2rem;
    color: #ccc;
`;

const StyledModernButton = styled.button`
    appearance: none;
    background-color: transparent;
    border: 2px solid #ffffff;
    border-radius: 15px;
    box-sizing: border-box;
    color: #ffffff;
    cursor: pointer;
    display: inline-block;
    font-family: Roobert, -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, Arial, sans-serif;
    font-size: 16px;
    font-weight: 600;
    line-height: normal;
    margin: 1rem 0 0 0;
    min-height: 60px;
    min-width: 0;
    outline: none;
    padding: 16px 24px;
    text-align: center;
    text-decoration: none;
    transition: all 300ms cubic-bezier(.23, 1, 0.32, 1);
    user-select: none;
    touch-action: manipulation;
    width: 210px;
    will-change: transform;

    &:disabled {
        pointer-events: none;
    }

    &:hover {
        color: #000000;
        background-color: #ffffff;
        box-shadow: rgba(0, 0, 0, 0.25) 0 8px 15px;
    }

    &:active {
        box-shadow: none;
    }
`;


export const ConfirmRegistrationPage: FC = () => {
    const API_BASE_URL = import.meta.env.VITE_REACT_APP_BACKEND_URL;
    const { id } = useParams();
    const navigate = useNavigate();
    const location = useLocation();
    const { isError, messageError, showError } = useErrorBanner();

    const [isReady, setIsReady] = useState(false);
    const [code, setCode] = useState("");
    const [timeLeft, setTimeLeft] = useState<number>(0);

    useEffect(() => {
        if (!location.state?.expiresAt) {
            showError("Недопустимый доступ. Пожалуйста, зарегистрируйтесь заново.");
            setTimeout(() => navigate("/register"), 2000);
            return;
        }

        const expiresAt = new Date(location.state.expiresAt);
        const diffInSeconds = Math.floor((expiresAt.getTime() - Date.now()) / 1000);
        setTimeLeft(diffInSeconds > 0 ? diffInSeconds : 0);

        setIsReady(true); // только если прошла проверка

        const timer = setInterval(() => {
            setTimeLeft((prev) => {
                if (prev <= 1) {
                    clearInterval(timer);
                    return 0;
                }
                return prev - 1;
            });
        }, 1000);

        return () => clearInterval(timer);
    }, []);

    const handleSubmit = async () => {
        try {
            const response = await fetch(`${API_BASE_URL}/auth/confirm`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    id,
                    code,
                }),
            });

            if (!response.ok) {
                const error = await response.json();
                alert(error.message || "Ошибка подтверждения");
                return;
            }

            navigate("/login");
        } catch (error) {
            console.error("Ошибка подтверждения:", error);
            alert("Ошибка при подтверждении кода");
        }
    };

    const formatTime = (seconds: number) => {
        const min = Math.floor(seconds / 60);
        const sec = seconds % 60;
        return `${min}:${sec < 10 ? "0" : ""}${sec}`;
    };

    return (
        <Container>
            <ErrorBanner isVisible={isError} message={messageError} />
            { isReady && (
                <Hero
                    as={motion.section}
                    initial={{ opacity: 0}}
                    animate={{ opacity: 1}}
                    transition={{ duration: 1, ease: "easeOut" }}>
                    <Title>
                        <h2>Подтвердите вашу почту</h2>
                        <p>Мы отправили код на вашу почту. Введите его ниже:</p>
                    </Title>
                    <CodeInput
                        type="text"
                        maxLength={6}
                        value={code}
                        onChange={(e) => setCode(e.target.value)}
                    />
                    <Timer>Истекает через: {formatTime(timeLeft)}</Timer>
                    <StyledModernButton onClick={handleSubmit} disabled={timeLeft <= 0 || code.length !== 6}>
                        Подтвердить
                    </StyledModernButton>
                </Hero>
            )}
        </Container>
    );
};