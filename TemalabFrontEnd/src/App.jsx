import './App.css'
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from './sections/Login';
import RegisterForm from './sections/Register';
import OwnerNavbar from './components/OwnerNavbar';
import CreateRestaurant from './sections/CreateRestaurant';
import CustomerProfile from './sections/CustomerProfile';
import Footer from './components/Footer';
import Navbar from './components/Navbar';
import Template from './sections/Template';
import CustomerReservations from './sections/CustomerReservations';
import AdminDeleteUser from './sections/AdminDeleteUser';
import CustomerFavorites from './sections/CustomerFavorites';
import CustomerMain from './sections/CustomerMain';
import OwnerMain from './sections/OwnerMain';
import OwnerTables from './sections/OwnerTables';
import RestaurantPage from './sections/RestaurantPage';
import OwnerRestaurantPage from './sections/OwnerRestaurantPage';
import MenuCreator from './sections/MenuCreator';
import Menu from './sections/Menu';
import OwnerProfile from './sections/OwnerProfile';
import { useEffect, useState } from 'react';
import CryptoJS from 'crypto-js';

function App() {

  const [loggedCheck, setLoggedCheck] = useState(localStorage.getItem('loggedIn'))

  useEffect(() => {
    setLoggedCheck(CryptoJS.AES.decrypt(localStorage.getItem('loggedIn'),'kulcs').toString(CryptoJS.enc.Utf8))
    console.log(loggedCheck)
  },[loggedCheck])
  

  return (
    <>
      <Router>
            <Routes>
              <Route path="/" element={<Login/>} />
              <Route path="/register" element={<RegisterForm/>} />
              <Route path="/template" element={<Template/>} />
              <Route path='/navbartest' element={<Navbar/>} />
              <Route path="/deleteUser" element={<AdminDeleteUser/>} />
              {loggedCheck === "customer" && (
                <>
                  <Route path="/Menu" element={<Menu/>} />
                  <Route path="/customerProfile" element={<CustomerProfile/>} />
                  <Route path="/customerReservations" element={<CustomerReservations/>} />
                  <Route path="/favorites" element={<CustomerFavorites/>} />
                  <Route path="/mainPageCustomer" element={<CustomerMain/>} />
                  <Route path="/restaurant" element={<RestaurantPage/>}/>
                  <Route path='/restaurant/:id' element={<RestaurantPage/>}/>
                </>
              )}
              {loggedCheck === "owner" && (
                <>
                  <Route path="/createRestaurant" element={<CreateRestaurant/>} />
                  <Route path="/navowner" element={<OwnerNavbar/>} />
                  <Route path="/mainPageOwner" element={<OwnerMain/>} />
                  <Route path="/tablesOwner" element={<OwnerTables/>} />
                  <Route path="/restaurantowner" element={<OwnerRestaurantPage/>}/>
                  <Route path="/ownerProfile" element={<OwnerProfile/>}/>
                  <Route path="/createmenu" element={<MenuCreator/>}/>
                </>
              )}
            </Routes>
      </Router>
      <Footer /> {/*Minden oldalra render-elve lesz*/}
    </>
  )
}

export default App
