import styled from 'styled-components';
import { FC } from 'react';

interface ModernButtonProps {
    text: string;
}

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
    margin: 0;
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

export const ModernButton: FC<ModernButtonProps> = ({ text }) => {
    return <StyledModernButton>{text}</StyledModernButton>;
};