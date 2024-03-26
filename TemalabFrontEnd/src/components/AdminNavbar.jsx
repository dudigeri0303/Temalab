import { Container, Navbar, Nav } from 'react-bootstrap';

export default function AdminNavbar(){
    return (
        <Navbar expand="lg" className="navbarcss p-0" data-bs-theme="dark">
            <Container>
                <Navbar.Brand href="#home">
                    <img src='/dinetab-logo.png' className='navbarlogo p-0 m-0'/>
                </Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ms-auto">
                        <Nav.Link href='#' className='logoutbtn fs-4 px-4 py-2'>Kijelentkezés</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}