import {FC, useState} from "react";
import styled from "styled-components";
import {useNavigate} from "react-router-dom";
import {motion} from "framer-motion";
import {PasswordInput} from "../components/PasswordInput";
import {useErrorBanner} from "../hooks/useErrorBanner";
import {ErrorBanner} from "../components/ErrorBanner";

const Container = styled.div`
    width: 100vw;
    min-height: 100vh;
    background-color: #1E1E1E;
    color: #FFFFFF;
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 2rem;
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

const Header = styled.div`
    width: 100%;
    display: flex;
    justify-content: space-between;
    align-items: center;
`

const H2InHeader = styled.h2`
    font-size: 2rem;
    
    @media (max-width: 425px) {
        font-size: 1.3rem;
    }
`

const Form = styled.form`
    display: flex;
    flex-direction: column;
    gap: 1.3rem;
    background-color: #2d2d2d;
    padding: 1.5rem;
    font-size: 1.5rem;
    border-radius: 12px;
    width: 100%;
    max-width: 600px;
    box-shadow: 3px 3px 30px rgba(0, 0, 0, 0.55);
`;

const Input = styled.input`
    font-size: 1.1rem;
    padding: 0.75rem;
    border: none;
    background-color: transparent;
    color: #ffffff;
    border-bottom: 2px solid transparent;

    &:focus {
        border-bottom: 2px solid white;
    }
`;

const BackButton = styled.button`
    background: transparent;
    color: white;
    border: none;
    position: relative;
    padding: 8px 12px;
    font-size: 1rem;
    border-radius: 5px;
    cursor: pointer;
    transition: color 0.3s ease;

    &::after {
        content: "";
        position: absolute;
        left: 0;
        bottom: 0;
        width: 0%;
        height: 2px;
        background: #919191;
        transition: width 0.3s ease-in-out;
    }

    &:hover {
        color: #919191;
    }

    &:hover::after {
        width: 100%;
    }
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
    width: 100%;
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

export const RegisterPage: FC = () => {
    const API_BASE_URL = import.meta.env.VITE_REACT_APP_BACKEND_URL;
    const navigate = useNavigate();
    const [email, setEmail] = useState("");
    const [username, setUsername] = useState("");
    const [name, setName] = useState("");
    const [password, setPassword] = useState("");
    const { isError, messageError, showError } = useErrorBanner();

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await fetch(`${API_BASE_URL}/auth/register`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    email,
                    username,
                    name,
                    password,
                }),
            });

            if (!response.ok) {
                const error = await response.json();
                alert(error.message || "Ошибка при регистрации");
                return;
            }

            navigate("/login");
        } catch (error) {
            console.error("Ошибка регистрации:", error);
            showError("Ошибка такая-то")
        }
    };

    return (
        <Container>
            <ErrorBanner isVisible={isError} message={messageError} />
            <Hero
                as={motion.section}
                initial={{ opacity: 0}}
                animate={{ opacity: 1}}
                transition={{ duration: 1, ease: "easeOut" }}>
                <Form onSubmit={handleSubmit}>
                    <Header>
                        <H2InHeader>Регистрация</H2InHeader>
                        <BackButton onClick={() => navigate('/welcome')}>Назад</BackButton>
                    </Header>
                    <Input
                        type="email"
                        placeholder="Email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                    <Input
                        type="text"
                        placeholder="Логин"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        required
                    />
                    <Input
                        type="text"
                        placeholder="Имя"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        required
                    />
                    <PasswordInput value={password} onChange={(e) => setPassword(e.target.value)} placeholder="Пароль"/>
                    <StyledModernButton type="submit">Зарегистрироваться</StyledModernButton>
                </Form>
            </Hero>
        </Container>
    );
};
