import { Container, Navbar, Nav } from 'react-bootstrap';
import { useNavigate } from "react-router-dom";

export default function OwnerNavbar(){
    const navigate = useNavigate(); 

    const logOut = async () => {
        localStorage.setItem('loggedIn',false)
        const requestOptions = {
            method: "POST",
            redirect: "follow",
            credentials: 'include',
            xhrFields: { withCredentials: true},
        };
        try {
            const response = await fetch("https://localhost:7114/api/User/logOut", requestOptions);
            const result = await response.text();
            console.log(result)
            let path = `/`; 
            navigate(path);
        } catch (error) {
            console.error(error);
        }
    }

    return (
        <Navbar expand="lg" className="navbarcss p-0" data-bs-theme="dark">
            <Container>
                <Navbar.Brand href="#home">
                    <img src='/dinetab-logo.png' className='navbarlogo p-0 m-0'/>
                </Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ms-auto">
                        <Nav.Link href="/mainPageOwner" className='navitemcss fs-4 px-4 py-2'>Éttermek</Nav.Link>
                        <Nav.Link href="/ownerProfile" className='navitemcss fs-4 px-4 py-2'>Profilom</Nav.Link>
                        <Nav.Link href='#' className='logoutbtn fs-4 px-4 py-2' onClick={logOut}>Kijelentkezés</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}