import { useState, useEffect } from 'react';
import "../App.css";
import { useNavigate } from "react-router-dom";

const RegisterForm = () => {
  useEffect(() => {
    document.title = " Regisztráció | DineTab";
  }, []);
  const [userName, setUserName] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [password, setPassword] = useState('');
  const [passwordAgain, setPasswordAgain] = useState('');
  const [customer, setCustomer] = useState(true);
  const [owner, setOwner] = useState(false);

  // Legyenek kötelező mezők
  const [fieldsRequired, setFieldsRequired] = useState(true);

  const navigate = useNavigate(); 

  // Regisztrációs gomb eseménykezelő fv
  const handleRegister = async (e) => {
    e.preventDefault();
    
    const myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    //User role beállítása a checkbox-ok alapján.
    let role = "";
    if(owner){ role = "owner";}
    else if(customer) {role = "customer"}
    
    const raw = JSON.stringify({
      "userName": userName,
      "email": email,
      "phoneNumber": phoneNumber,
      "password": password,
      "passwordAgain": passwordAgain,
      "userRole": role
    });
    
    const requestOptions = {
      method: "POST",
      headers: myHeaders,
      credentials: 'include',
      xhrFields: { withCredentials: true},
      body: raw,
      redirect: "follow"
    };
    
    try {
      const response = await fetch("https://localhost:7114/api/User/register/", requestOptions);
      const result = await response.text();
      console.log(result)
      
      //sikeres regisztráció esetén navigáció a login oldalra
      let path = `/`; 
      navigate(path);
    } catch (error) {
      console.error(error);
    }
  };

  // Mégse gomb eseménykezelő fv
  const handleCancel = () => {
    setFieldsRequired(false);  // Kötelező mezőket "kikapcsolja" => nem kell kitölteni ha a mégse gombra kattintunk
    window.open("/", "_self");
  };

  return (
    <div className='w-100 regdiv d-flex align-items-center'>
      <form className='regform mx-auto'>

        <div className="mb-3">
          <input
            className="form-control"
            type="text"
            placeholder="UserName"
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
            required={fieldsRequired}
          />
        </div>

        <div className="mb-3">
          <input
            className="form-control"
            type="text"
            placeholder="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required={fieldsRequired}
          />
        </div>

        <div className="mb-3">
          <input
            className="form-control"
            type="text"
            placeholder="Phonenumber"
            value={phoneNumber}
            onChange={(e) => setPhoneNumber(e.target.value)}
          />
        </div>

        <div className="mb-3">
          <input
            className="form-control"
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required={fieldsRequired}
          />
        </div>

        <div className="mb-3">
          <input
            className="form-control"
            type="password"
            placeholder="Password again"
            value={passwordAgain}
            onChange={(e) => setPasswordAgain(e.target.value)}
            required={fieldsRequired}
          />
        </div>

        <div className="mb-3">
          <label>
            <input
              type="checkbox"
              checked={customer}
              onChange={(e) => {
                if (e.target.checked != false) {
                  setCustomer(e.target.checked);
                  setOwner(false); // Ha a "Customer" checkbox ki van választva, a "Owner" checkbox legyen kikapcsolva
                }
              }}
            />
            Customer
          </label>
        </div>

        <div className="mb-3">
          <label>
            <input
              type="checkbox"
              checked={owner}
              onChange={(e) => {
                if (e.target.checked != false) {
                  setOwner(e.target.checked);
                  setCustomer(false);// Ha az "Owner" checkbox ki van választva, a "Customer" checkbox legyen kikapcsolva
                }
              }}
            />
            Owner
          </label>
        </div>

        <div>
          <button className='btnstyle m-3 py-2' type="button" onClick={handleRegister} >Register</button>
          <button className='btnstyle m-3 py-2' type="button" onClick={handleCancel} >Mégse</button>
        </div>

      </form>
    </div>
  );
};

export default RegisterForm;