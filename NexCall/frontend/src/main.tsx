import { createRoot } from 'react-dom/client'
import { ThemeProvider } from 'styled-components';
import { theme } from './styles/theme';
import './index.css'
import App from './App.tsx'

createRoot(document.getElementById('root')!).render(
    <ThemeProvider theme={theme}>
        <App />
    </ThemeProvider>
)
