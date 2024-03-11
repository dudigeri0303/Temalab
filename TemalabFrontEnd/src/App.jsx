import { useState } from 'react'
import './App.css'
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from './sections/Login';
import RegisterForm from './sections/Register';
import OwnerNavbar from './components/OwnerNavbar';

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <Router>
            <Routes>
              <Route path="/" element={<OwnerNavbar/>} />
              <Route path="/" element={<RegisterForm/>} />
              <Route path="/" element={<Login/>} />
            </Routes>
      </Router>
    </>
  )
}

export default App
