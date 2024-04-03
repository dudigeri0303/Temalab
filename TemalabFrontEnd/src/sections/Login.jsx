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
        //myHeaders.append("Cookie", ".AspNetCore.Identity.Application=CfDJ8J3qJxRhS7BCp-kLUWa5SWGYUplCoULlXqnzmjIOucQfSPU5qJa_t6JduGWZ4QVzmPMZvQW9fY5_yrlqGNpMxZtxg2SPbwjpYIWDdUVXI3WfcxYRi7kbc4azv10bZCtqIDFV-MK9uxZqK8wHaqEqvkR_gFNR4m3fBjCgcGE-kdI28f-2oqYjRzlF01UjDp-hh6H_4guws2WC55C-s5PLP9k8mUT9ZY0_12OlKhq031RXhr9LL_fT8gta4kaOiRiThssGF67ZE57datDiv6C-zxlZT3gb_0QTFP9tdIh_IbEzpEeT6io9r1CiOCEkDOzbjvKxUrUdaajVQeGWoBVr1IECXuNXQHnG24QzsajowqDog2McpptmCtBkiJAUScZCJrjUsGPyTcO5Es5PZfmzgvldB9_elrEo-GgmjiehsDzdNJELT3_GdSzTt_WRoDF185o6EeS1qc4F5PJ0ioaoHsA3fK928DcOWa5Tch_0UF7IZ-PlHY2CleTrbR-dCayH_vx5VyVCAfhc6S5GKocIluPEbT3spAee_wm23ee-E3JZ6bsbRvvFFcGuXk-aMdvmnV3JtNZ4tz8pNUGNShzpAfzrQVcUUaoQL_L7jD45Rm8WwjTI3SrwjTYjIydE8a3nvn6daOpJovj1ChilvsSLZK_zW2LUnfI4QKxgdO-PxqxQJE1mYx_HJX1mluCUkCKXH7dGF_yM3_JxWvAG6UnbUuk");

        const raw = JSON.stringify({
        "userName": "Anna",
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
                            <a className='btnstyle px-1 py-2 text-center loginbtn' href='#'>Regisztráció</a> 
                        </div>
                    </Form>
                </div>
            </div>
        </>
    )
}

export default LoginForm;

    
