import {BrowserRouter, Route, Routes} from 'react-router-dom';
import WelcomePage from './pages/WelcomePage';
import {LoginPage} from "./pages/LoginPage.tsx";
import {RegistrationPage} from "./pages/RegistrationPage.tsx";
import HomePage from "./pages/HomePage";
import {ConfirmRegistrationPage} from "./pages/ConfirmRegistrationPage";

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/welcome" element={<WelcomePage/>}/>
                <Route path="/login" element={<LoginPage/>}/>
                <Route path="/register" element={<RegistrationPage/>}/>
                <Route path="/home" element={<HomePage/>}/>
                <Route path="/confirm-registration/:id" element={<ConfirmRegistrationPage/>}/>
                <Route path="/" element={<HomePage/>}/>
            </Routes>
        </BrowserRouter>
    );
}

export default App;