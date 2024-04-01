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
        myHeaders.append("Cookie", ".AspNetCore.Identity.Application=CfDJ8J3qJxRhS7BCp-kLUWa5SWHMm9HLNT2Qd3N9cVrUfHnBkY__jwcuf8HKHTz8UCCT2V-4mT5hubLBUyR_GWR0pJxupksRoXr_0ZDpZWmCWzV_7ApjMTXWXLXyom0pqf2Zx-lCvOzceG09q3d6AFsySAX9OadSvZzaw_OrFdUuLBU6sA1Nz3lRUviG4HqbJ29-X7EbUUcYAaf6i67Vu8J1EhekdPURxjgJjPWyTMdTLJExAiuOZQtuf4nJ4SkbBp7Cg3FGsTiWk4l92PwBqz00wpCujCex0bnGhjJgNteUVSLJipjWKzFDGxEUsG8Ofkq46XaKJXwcC--HHIqfVSL55G4TG7w5dhPZfliKaRE5cGiUiHDflzWVwoHElhgKBSPft08zMDMiTETKkYIy69-3vPojySa4Jgb0JC65Fyx_F15bLMb8HL2fXXR0UariQ7LXXf8LFYO0wJYBlY6ud5fvKXsRRDCIZUR2KVLs5zNGfWYYlsj5zPpXdsCzCMPu3f7EAMImKAL1-587iIZ3MQO_sRAikdBanWczlFW9Hucruotmw2HkJm3HRC8rO0yOs69UlGtGn_utdaNzSk73-0MpdDhvBT-hq91itsi6CvJ70hI9OJmcsNrz2-yZUI6073_W03csPymFaA0OdrJabSD7cn_mrXg6ukgskkex4AZGllkBOzBqyCN_1HO4Ziorao4XFmNaiFjM30YNWqb31M0RBOs");
        
        const raw = JSON.stringify({
            "email": "Jozsi",
            "password": "A2dq3s00?34",
            "twoFactorCode": "string",
            "twoFactorRecoveryCode": "string"
        });
        
        const requestOptions = {
            method: "POST",
            headers: myHeaders,
            body: raw,
            credentials: 'include',
            redirect: "follow"
        };
        
        try {
            const response = await fetch("https://localhost:7114/login?useCookies=true&useSessionCookies=true", requestOptions);
            const result = await response.text();
            console.log(result)
            console.log(JSON.stringify(result));
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

    
