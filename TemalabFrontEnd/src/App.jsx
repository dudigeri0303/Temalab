import './App.css'
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from './sections/Login';
import RegisterForm from './sections/Register';
import OwnerNavbar from './components/OwnerNavbar';
import CreateRestaurant from './sections/CreateRestaurant';
import Profile from './sections/Profile';
import Footer from './components/Footer';
import Navbar from './components/Navbar';

function App() {
  return (
    <>
      <Router>
            <Routes>
              <Route path="/" element={<OwnerNavbar/>} />
              <Route path="/" element={<RegisterForm/>} />
              <Route path="/" element={<Login/>} />
              <Route path="/createRestaurant" element={<CreateRestaurant/>} /> {/*Elérhető: http://localhost:valami_szám/createRestaurant*/}
              <Route path="/profile" element={<Profile/>} /> {/*Elérhető: http://localhost:valami_szám/Profile*/}
              <Route path='/navbartest' element={<Navbar/>} />
            </Routes>
      </Router>
      <Footer /> {/* Elvileg így minden oldalra render-elve lesz*/}
    </>
  )
}

export default App
