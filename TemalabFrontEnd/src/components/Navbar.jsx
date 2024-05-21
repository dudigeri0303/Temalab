import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useNavigate } from "react-router-dom";
import CryptoJS from 'crypto-js';

export default function NavbarAll(){
    const navigate = useNavigate(); 

    const logOut = async () => {
        localStorage.setItem('loggedIn',CryptoJS.AES.encrypt('false','kulcs').toString())
        const requestOptions = {
            method: "POST",
            redirect: "follow",
            credentials: 'include',
            xhrFields: { withCredentials: true},
        };
        try {
            const response = await fetch("https://localhost:7114/api/User/logOut", requestOptions);
            const result = await response.text();
            let path = `/`; 
            navigate(path);
        } catch (error) {
            console.error(error);
        }
    }

    return(
        <>
            <Navbar expand="lg" className="navbarcss p-0" data-bs-theme="dark">
                <Container>
                        <Navbar.Brand href="/mainPageCustomer">
                            <img src='/dinetab-logo.png' className='navbarlogo p-0 m-0'/>
                        </Navbar.Brand>
                        <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                        <Navbar.Collapse id="basic-navbar-nav">
                        <Nav className="ms-auto">
                            <Nav.Link href='/mainPageCustomer' className='navitemcss fs-4 px-4 py-2'>Éttermek</Nav.Link>
                            <Nav.Link href='/customerReservations' className='navitemcss fs-4 px-4 py-2'>Foglalásaim</Nav.Link>
                            <Nav.Link href='/favorites' className='navitemcss fs-4 px-4 py-2'>Kedvencek</Nav.Link>
                            <Nav.Link href='/customerProfile' className='navitemcss fs-4 px-4 py-2'>Profilom</Nav.Link>
                            <Nav.Link href='#' className='logoutbtn fs-4 px-4 py-2' type="button" onClick={logOut}>Kijelentkezés</Nav.Link>
                        </Nav>
                        </Navbar.Collapse>
                </Container>
            </Navbar>
        </>
    )
}