import {FC} from "react";
import {motion, AnimatePresence} from "framer-motion";
import styled from "styled-components";

interface ErrorBannerProps {
    isVisible: boolean;
    message: string;
}

const Banner = styled(motion.div)`
    position: fixed;
    top: 20px;
    right: 20px;
    background-color: rgba(255, 0, 0, 0.28); // ярко-красный
    color: white;
    padding: 1rem 1.5rem;
    border-radius: 8px;
    box-shadow: 0 5px 20px rgba(0, 0, 0, 0.3);
    border: 1px solid red;
    z-index: 9999;
    font-size: 1rem;
    max-width: 90vw;
    word-break: break-word;
`;

export const ErrorBanner: FC<ErrorBannerProps> = ({isVisible, message}) => {
    return (
        <AnimatePresence>
            {isVisible && (
                <Banner
                    initial={{x: "100%", opacity: 0}}
                    animate={{x: 0, opacity: 1}}
                    exit={{x: "100%", opacity: 0}}
                    transition={{type: "spring", stiffness: 250, damping: 30}}
                >
                    {message}
                </Banner>
            )}
        </AnimatePresence>
    );
};