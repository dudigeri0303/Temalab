//import Button from 'react-bootstrap/Button';
import { useEffect, useState } from 'react';
import Form from 'react-bootstrap/Form';
import { useNavigate } from "react-router-dom";
import CryptoJS from 'crypto-js';

const LoginForm = () =>{
    useEffect(() => {
        document.title = " Bejelentkezés | DineTab";
      }, []);
    //const history = useHistory();
    const navigate = useNavigate(); 
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');

    const handleLogin = async () => {
        const myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        const raw = JSON.stringify({
            "userName": userName,
            "password": password
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
            const parsedResult = JSON.parse(result);

            if(response.ok){
                if(parsedResult.userRole === 'customer'){
                    localStorage.setItem('loggedIn', CryptoJS.AES.encrypt('customer','kulcs').toString())
                }

                if(parsedResult.userRole === 'owner'){
                    localStorage.setItem('loggedIn', CryptoJS.AES.encrypt('owner','kulcs').toString())
                }

                //navigációs utvonal beállítása a user role alaőján
                let path = ""
                if(parsedResult.userRole === 'customer'){
                    path = `/mainPageCustomer`;
                } 
                if(parsedResult.userRole == "owner"){
                    path = `/mainPageOwner`
                }
                if(parsedResult.userRole === "admin"){
                    path = `/deleteUser`
                }
                navigate(path)
            }
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
                            <Form.Control type="text" placeholder="Enter username" onChange = {(e) => setUserName(e.target.value)}/>
                        </Form.Group>

                        <Form.Group className="mb-4" controlId="formBasicPassword">
                            <Form.Label>Jelszó</Form.Label>
                            <Form.Control type="password" placeholder="Password" onChange = {(e) => setPassword(e.target.value)}/>
                        </Form.Group>
                    </Form>
                    <div className='d-flex flex-wrap justify-content-between'>
                        <button className='btnstyle px-1 py-2 text-center loginbtn m-auto mt-3' type="button" onClick={handleLogin}>Bejelentkezés</button>
                        <a className='btnstyle px-1 py-2 text-center loginbtn m-auto mt-3' href='#' type='button' onClick={redirectToRegisttrationPage}>Regisztráció</a> 
                    </div>
                </div>
            </div>
        </>
    )
}

export default LoginForm;

    
