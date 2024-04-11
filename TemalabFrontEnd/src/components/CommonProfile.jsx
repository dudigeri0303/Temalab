import { json } from "react-router-dom";
import "../App.css";
import React, { useEffect, useState } from "react";

export default function Profile() {
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
      console.log(result)
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
    {/*fv. hívás: Visszatölti a régi az utolsó mentett adatokat ugyanaz, mint az oldal betöltésekor*/}
  };

  const saveChanges = () => {
    setModifiable(false);
    {/*elmenti adatbázisba az adatokat, ha változtak, a mezők validáljanak + esetleg egy üzenet sikeres mentés esetén*/}
    alert("Változtatások mentve");
  }

  return (
    <>
      <section id="main" className="container py-3">
        <form method="post">
          <div className="row">
            <div className="col-md-4">
              <div className="mb-2">
                <label className="form-label">Név/felhasználónév:</label>
              </div>
            </div>

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