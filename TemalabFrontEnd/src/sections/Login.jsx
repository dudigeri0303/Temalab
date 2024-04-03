//import Button from 'react-bootstrap/Button';
//import { useState } from 'react';
import Form from 'react-bootstrap/Form';
//import { useHistory } from 'react-router-dom';
import { useNavigate } from "react-router-dom";

const LoginForm = () =>{
    //const history = useHistory();
    const navigate = useNavigate(); 
    //const [userName, setUserName] = useState('');
    //const [password, setPassword] = useState('');

    const handleLogin = async () => {
        const myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        const raw = JSON.stringify({
            "userName": "Jozsi",
            "password": "A2dq3s00?34"
        });
        const requestOptions = {
            method: "POST",
            credentials: 'include',
            xhrFields: { withCredentials: true},
            headers: myHeaders,
            mode: 'cors',
            body: raw,
            redirect: "follow"
        };

        try {
            const response = await fetch("https://localhost:7114/api/User/Login", requestOptions);
            const result = await response.text();
            console.log(result)
            let path = `/customerProfile`; 
            navigate(path);
        } catch (error) {
            console.error(error);
        }
    };

    const redirectToRegisttrationPage = () =>{
        let path = `/register`; 
        navigate(path);   
    };

    return(
        <>
            <div className='loginkulso d-flex align-items-center mx-auto'>
                <div className='logindiv'>
                    <h1 className='text-center mb-5'>DineTab - Bejelentkezés</h1>
                    <Form>
                        <Form.Group className="mb-3" controlId="formBasicEmail">
                            <Form.Label>Email</Form.Label>
                            <Form.Control type="text" placeholder="Enter username"/>
                        </Form.Group>

                        <Form.Group className="mb-4" controlId="formBasicPassword">
                            <Form.Label>Jelszó</Form.Label>
                            <Form.Control type="password" placeholder="Password" />
                        </Form.Group>
                        <div className='d-flex justify-content-between'>
                            <button className='btnstyle px-1 py-2 text-center loginbtn' href='#' type="button" onClick={handleLogin}>Bejelentkezés</button>
                            <a className='btnstyle px-1 py-2 text-center loginbtn' href='#' type='button' onClick={redirectToRegisttrationPage}>Regisztráció</a> 
                        </div>
                    </Form>
                </div>
            </div>
        </>
    )
}

export default LoginForm;

    
