import './App.css'
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from './sections/Login';
import RegisterForm from './sections/Register';
import OwnerNavbar from './components/OwnerNavbar';
import CreateRestaurant from './sections/CreateRestaurant';
import Profile from './sections/Profile';
import Footer from './components/Footer';
import Navbar from './components/Navbar';
import Template from './sections/Template';
import CustomerReservations from './sections/CustomerReservations';
import AdminDeleteUser from './sections/AdminDeleteUser';
import CustomerFavorites from './sections/CustomerFavorites';
import CustomerMain from './sections/CustomerMain';
import OwnerMain from './sections/OwnerMain';
import OwnerTables from './sections/OwnerTables';

function App() {
  return (
    <>
      <Router>
            <Routes>
              <Route path="/" element={<Login/>} />
              <Route path="/navowner" element={<OwnerNavbar/>} />
              <Route path="/register" element={<RegisterForm/>} />
              <Route path="/createRestaurant" element={<CreateRestaurant/>} /> {/*Elérhető: http://localhost:valami_szám/createRestaurant*/}
              <Route path="/profile" element={<Profile/>} /> {/*Elérhető: http://localhost:valami_szám/Profile*/}
              <Route path='/navbartest' element={<Navbar/>} />
              <Route path="/template" element={<Template/>} />
              <Route path="/customerReservations" element={<CustomerReservations/>} />
              <Route path="/deleteUser" element={<AdminDeleteUser/>} />
              <Route path="/favorites" element={<CustomerFavorites/>} />
              <Route path="/mainPageCustomer" element={<CustomerMain/>} />
              <Route path="/mainPageOwner" element={<OwnerMain/>} />
              <Route path="/tablesOwner" element={<OwnerTables/>} />
            </Routes>
      </Router>
      <Footer /> {/* Elvileg így minden oldalra render-elve lesz*/}
    </>
  )
}

export default App
