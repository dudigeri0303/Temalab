import { useState } from 'react'
import './App.css'
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from './sections/Login';
import CreateRestaurant from './sections/CreateRestaurant';
import Footer from './components/Footer';

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <Router>
            <Routes>
              <Route path="/" element={<Login/>} />
              <Route path="/createRestaurant" element={<CreateRestaurant/>} /> {/*Elérhető: http://localhost:valami_szám/createRestaurant*/}
            </Routes>
      </Router>
      <Footer /> {/* Elvileg így minden oldalra render-elve lesz*/}
    </>
  )
}

export default App
