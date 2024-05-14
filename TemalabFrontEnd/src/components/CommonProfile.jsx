import "../App.css";
import React, { useEffect, useState } from "react";

export default function CommonProfile() {
  useEffect(() => {
    document.title = "Profile | DineTab";
  }, []);


  const [userName, setUserName] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [password, setPassword] = useState('');

  const getUserData = async () => {
    const myHeaders = new Headers();


    const requestOptions = {
      method: "GET",
      credentials: 'include',
      xhrFields: { withCredentials: true},
      headers: myHeaders,
      redirect: "follow"
    };

    try {
      const response = await fetch("https://localhost:7114/api/User/getLoggedInUserData", requestOptions);
      let result = await response.text();
      result = JSON.parse(result);
      setUserName(result.name);
      setEmail(result.email);
      setPhoneNumber(result.phoneNumber);
      setPassword(result.password);
    } catch (error) {
      console.error(error);
    }
  }
  getUserData();

  const deleteProfile = () => {
    const IsProfileDeleted = window.confirm("Biztos törlöd a profilod?");
    if (IsProfileDeleted) {
      {
        /*Profil törlése method hívás*/
        alert("Profil törölve")
      }
      window.open("/", "_self");
      {
        /*Visszairányít a login oldalra _self, hogy ne új lapon nyissa meg*/
      }
    }
  };

  {/*reactban:state hook kell, hogy azonnal renderelje a változást*/}
  const [modifiable, setModifiable] = useState(false);

  const modify = () => {
    setModifiable(true);
  };

  const cancelModify = () => {
    setModifiable(false);
    location.reload(); // elég csak frissíteni az oldalt
  };


  const saveChanges = () => {
    setModifiable(false);
    //-----------------------------------------------

    const newData = {
      userName: userName,
      phoneNumber: phoneNumber,
      email: email
    };

    const putRequestOptions = {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(newData)
  };

  

  fetch(`https://localhost:7114/api/User/editUserDate/${userName}`  , putRequestOptions)
    .then(response => {
      if (response.ok) {
        // Sikeres mentés esetén itt lehet kezelni a választ
        alert("Változtatások mentve1");
        console.log("1")
      } else {
        console.log("2")
        throw new Error('Hiba történt a mentés során2');
      }
    })
    .catch(error => {
      // Hiba esetén itt lehet kezelni a hibát
      console.log("3")
      console.error('Hiba történt3:', error);
      alert("Hiba történt a mentés során4");
      console.log("4")
    });
        
    
    //-----------------------------------------


    {/*elmenti adatbázisba az adatokat, ha változtak, a mezők validáljanak + esetleg egy üzenet sikeres mentés esetén*/}
  }

  return (
    <>
      <section id="main" className="container py-3">
        <form method="post">
          <div className="row">
            <div className="col-md-8">
              <div className="col-md-3 offset-md-4 mb-2">
                <button onClick={modify} type="button" className="avgbtn float-md-right">
                  Profil szerkesztése
                </button>
              </div>
            </div>

            <h4 className="h4-profile">Profil Adatok:</h4>

            <div className="col-md-5">
              <div className="mb-3 d-flex justify-content-center">
                <label htmlFor="nameForProfile" className="form-label">
                  Név:
                </label>
              </div>
            </div>
            <div className="col-md-6">
              <div className="mb-3">
                <input
                  type="text"
                  className="form-control"
                  id="nameForProfile"
                  name="nameForProfile"
                  onChange={(e) => setUserName(e.target.value)}
                  placeholder= {userName}
                  disabled={!modifiable}
                  required
                />
              </div>
            </div>

            <div className="col-md-5">
              <div className="mb-6 d-flex justify-content-center">
                <label htmlFor="telForProfile" className="form-label">
                  Tel:
                </label>
              </div>
            </div>
            <div className="col-md-6">
              <div className="mb-3">
                <input
                  type="text"
                  className="form-control"
                  id="telForProfile"
                  name="telForProfile"
                  placeholder= {phoneNumber}
                  onChange={(e) => setPhoneNumber(e.target.value)}
                  disabled={!modifiable}
                  required
                />
              </div>
            </div>

            <div className="col-md-5">
              <div className="mb-3 d-flex justify-content-center">
                <label htmlFor="emailForProfile" className="form-label">
                  Email:
                </label>
              </div>
            </div>
            <div className="col-md-6">
              <div className="mb-3">
                <input
                  type="email"
                  className="form-control"
                  id="emailForProfile"
                  name="emailForProfile"
                  onChange={(e) => setEmail(e.target.value)}
                  placeholder={email}
                  disabled={!modifiable}
                  required
                />
              </div>
            </div>

            <div className="col-md-5">
              <div className="mb-3 d-flex justify-content-center">
                <label htmlFor="passwordForProfile" className="form-label">
                  Jelszó:
                </label>
              </div>
            </div>
            <div className="col-md-6">
              <div className="mb-3">
                <input
                  type="password"
                  className="form-control"
                  id="passwordForProfile"
                  name="passwordForProfile"
                  onChange={(e) => setPassword(e.target.value)}
                  placeholder={password}
                  disabled={!modifiable}
                  required
                />
              </div>
            </div>
          </div>

          <div className="row">
            <div className="col-md-3 offset-md-5 mb-2">
              <button onClick={saveChanges} type="button" className="avgbtn">
                Változtatások mentése
              </button>
            </div>
            <div className="col-md-2 offset-md-1 mb-2">
              <button onClick={cancelModify} type="button" className="avgbtn">
                Mégse
              </button>
            </div>
          </div>
        </form>

        <div className="row">
          <div className="col-md-3 offset-md-5 mb-2">
            <button onClick={deleteProfile} type="button" className="redbtn">
              Profil törlése
            </button>
          </div>
        </div>
      </section>
    </>
  );
}