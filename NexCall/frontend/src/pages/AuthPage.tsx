import React, { useState, useEffect } from 'react';
import styled, { keyframes } from 'styled-components';
import { useNavigate } from 'react-router-dom';

const Container = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    min-height: 100vh;
    background-color: #ffffff;
    color: #000000;
`;

const spin = keyframes`
    to { transform: rotate(360deg); }
`;

const Spinner = styled.div`
    margin-top: 1rem;
    width: 40px;
    height: 40px;
    border: 4px solid rgba(0, 0, 0, 0.1);
    border-left-color: #000000;
    border-radius: 50%;
    animation: ${spin} 1s linear infinite;
`;

interface AuthLoadingComponentProps {
    message: string;
    show: boolean;
}

const AuthLoadingComponent: React.FC<AuthLoadingComponentProps> = ({ message, show }) => {
    if (!show) return null;
    return (
        <Container>
            <div>{message}</div>
            <Spinner />
        </Container>
    );
};

interface AuthPageProps {
    children: React.ReactNode;
}

const AuthPage: React.FC<AuthPageProps> = ({ children }) => {
    const API_BASE_URL = import.meta.env.VITE_REACT_APP_BACKEND_URL;
    const [loading, setLoading] = useState(true);
    const [authorized, setAuthorized] = useState(false);
    const [message, setMessage] = useState('Проверка авторизации');
    const navigate = useNavigate();

    useEffect(() => {
        const checkAuth = async () => {
            try {
                // Запрос к эндпоинту для проверки авторизации с отправкой куков
                const response = await fetch(`${API_BASE_URL}/api/auth/verify`, {
                    method: 'GET',
                    credentials: 'include'
                });

                if (response.ok) {
                    setAuthorized(true);
                } else {
                    throw new Error('Unauthorized');
                }
            } catch (error) {
                setAuthorized(false);
                setMessage('Вы не авторизованы');
                setTimeout(() => {
                    navigate('/welcome');
                }, 1500);
            } finally {
                setLoading(false);
            }
        };

        checkAuth();
    }, [navigate]);

    // Пока идёт запрос или если авторизация не пройдена — показываем AuthLoadingComponent
    if (loading || !authorized) {
        return <AuthLoadingComponent message={message} show={true} />;
    }

    // Если авторизация успешна, рендерим защищённый контент
    return <>{children}</>;
};

export default AuthPage;