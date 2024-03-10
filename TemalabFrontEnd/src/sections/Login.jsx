import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

export default function Login(){
    return(
        <>
            <div className='loginkulso d-flex align-items-center mx-auto'>
                <div className='logindiv'>
                    <h1 className='text-center mb-5'>DineTab - Bejelentkezés</h1>
                    <Form>
                        <Form.Group className="mb-3" controlId="formBasicEmail">
                            <Form.Label>Email</Form.Label>
                            <Form.Control type="email" placeholder="Enter email"/>
                        </Form.Group>

                        <Form.Group className="mb-4" controlId="formBasicPassword">
                            <Form.Label>Jelszó</Form.Label>
                            <Form.Control type="password" placeholder="Password" />
                        </Form.Group>
                        <div className='d-flex justify-content-between'>
                            <a className='btnstyle px-1 py-2 text-center loginbtn' href='#'>Bejelentkezés</a>
                            <a className='btnstyle px-1 py-2 text-center loginbtn' href='#'>Regisztráció</a> 
                        </div>
                    </Form>
                </div>
            </div>
        </>
    )
}