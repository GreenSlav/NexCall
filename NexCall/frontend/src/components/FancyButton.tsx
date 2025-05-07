import {FC} from "react";
import styled from "styled-components";

interface FancyButtonProps {
    primaryText: string;
    altText: string;
    textColor?: string;
    bgColor?: string;
}

const StyledButton = styled.button<Pick<FancyButtonProps, 'textColor' | 'bgColor'>>`
    position: relative;
    overflow: hidden;
    border: 1px solid ${({textColor}) => textColor || '#18181a'};
    color: ${({textColor}) => textColor || '#18181a'};
    background: ${({bgColor}) => bgColor || '#ffffff'};
    display: inline-block;
    font-size: 15px;
    line-height: 15px;
    padding: 18px 18px 17px;
    text-decoration: none;
    cursor: pointer;
    user-select: none;
    touch-action: manipulation;

    span:first-child {
        position: relative;
        transition: color 600ms cubic-bezier(0.48, 0, 0.12, 1);
        z-index: 10;
    }

    span:last-child {
        color: white;
        display: block;
        position: absolute;
        bottom: 0;
        transition: all 500ms cubic-bezier(0.48, 0, 0.12, 1);
        z-index: 100;
        opacity: 0;
        top: 65%;
        left: 50%;
        transform: translateY(225%) translateX(-50%);
        height: 14px;
        line-height: 13px;
    }

    &::after {
        content: "";
        position: absolute;
        border-radius: 5px; /* тот же радиус, что и у кнопки */
        bottom: -50%;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: ${({textColor}) => textColor || '#18181a'};
        transform-origin: bottom center;
        transition: transform 600ms cubic-bezier(0.48, 0, 0.12, 1);
        transform: skewY(9.3deg) scaleY(0);
        z-index: 50;
    }

    &:hover::after {
        transform: skewY(9.3deg) scaleY(2);
    }

    &:hover span:last-child {
        transform: translateX(-50%) translateY(-100%);
        opacity: 1;
        transition: all 900ms cubic-bezier(0.48, 0, 0.12, 1);
    }
`;

export const FancyButton: FC<FancyButtonProps> = ({
                                                      primaryText,
                                                      altText,
                                                      textColor = "#18181a",
                                                      bgColor = "#ffffff"
                                                  }) => {
    return (
        <StyledButton textColor={textColor} bgColor={bgColor}>
            <span>{primaryText}</span>
            <span>{altText}</span>
        </StyledButton>
    );
};