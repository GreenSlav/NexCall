import { useState, useCallback } from 'react';

export const useErrorBanner = (visibleTime = 3000, cleanupDelay = 1000) => {
    const [isError, setIsError] = useState(false);
    const [messageError, setMessageError] = useState('');

    const showError = useCallback((msg: string) => {
        setIsError(true);
        setMessageError(msg);

        setTimeout(() => {
            setIsError(false);

            setTimeout(() => {
            }, cleanupDelay);
        }, visibleTime);
    }, [visibleTime, cleanupDelay]);

    return {
        isError,
        messageError,
        showError,
    };
};