import { FC, useState } from "react";
import styled from "styled-components";
import { Eye, EyeOff } from "lucide-react"; // иконки, можно заменить

const InputWrapper = styled.div`
    position: relative;
    width: 100%;
`;

const StyledInput = styled.input`
    color: #ffffff;
    width: 100%;
    font-size: 1.1rem;
    padding: 0.75rem;
    background-color: transparent;
    border-bottom: 2px solid transparent;

    &:focus {
        border-bottom: 2px solid white;
    }
`;

const ToggleButton = styled.button`
    position: absolute;
    padding: 0.2rem;
    right: 10px;
    top: 50%;
    transform: translateY(-50%);
    border: none;
    cursor: pointer;
    color: #ffffff;
    border-radius: 5px;
    display: flex;
    align-items: center;
    background-color: rgba(0, 0, 0, 0.18);
`;

type Props = {
    value: string;
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
    placeholder?: string;
};

export const PasswordInput: FC<Props> = ({ value, onChange, placeholder }) => {
    const [visible, setVisible] = useState(false);

    return (
        <InputWrapper>
            <StyledInput
                type={visible ? "text" : "password"}
                value={value}
                onChange={onChange}
                placeholder={placeholder || "Пароль"}
                required
            />
            <ToggleButton type="button" onClick={() => setVisible(!visible)}>
                {visible ? <EyeOff size={20} /> : <Eye size={20} />}
            </ToggleButton>
        </InputWrapper>
    );
};