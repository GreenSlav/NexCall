import {BrowserRouter, Route, Routes} from 'react-router-dom';
import WelcomePage from './pages/WelcomePage';
import {LoginPage} from "./pages/LoginPage.tsx";
import {RegisterPage} from "./pages/RegistrationPage.tsx";

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/welcome" element={<WelcomePage/>}/>
                <Route path="/login" element={<LoginPage/>}/>
                <Route path="/register" element={<RegisterPage/>}/>
            </Routes>
        </BrowserRouter>
    );
}

export default App;