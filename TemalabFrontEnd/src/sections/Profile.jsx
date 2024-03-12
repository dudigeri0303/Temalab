import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/Navbar";

export default function Profile() {
  useEffect(() => {
    document.title = "Profile | DineTab";
  }, []);

  const deleteProfile = () => {
    const IsProfileDeleted = window.confirm('Biztos törlöd a profilod?');
    if (IsProfileDeleted) {
      {/*Profil törlése method hívás*/}
      window.open("/", "_self");
      {/*Visszairányít a login oldalra _self, hogy ne új lapon nyissa meg*/}
    }
  };

  return (
    <>
    <Navbar></Navbar>
      <section id="main" className="container py-3">
        
        <form method="post">

          <div className="row" >

          <div className="col-md-4">
              <div className="mb-2">
            <label htmlFor="inputName" className="form-label">
                  Név/felhasználónév:
                </label>
                </div>
            </div>

            <div className="col-md-8">
            <div className="col-md-3 offset-md-4 mb-2">
              <button type="button" className="avgbtn float-md-right">
              Profil szerkesztése
              </button>
            </div>
            </div>

            <h4 className="h4-profile">Profil Adatok:</h4>

          <div className="col-md-5">
              <div className="mb-3">
            <label htmlFor="inputName" className="form-label">
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
                  placeholder="Név"
                  required
                />
              </div>
            </div>
 
            <div className="col-md-5">
              <div className="mb-6">
                <label htmlFor="inputPhone" className="form-label">
                  Telefonszám:
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
                  placeholder="Telefonszám"
                  required
                />
              </div>
            </div>

            <div className="col-md-5">
              <div className="mb-3">
                <label htmlFor="intputEmail" className="form-label">
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
                  placeholder="Email"
                  required
                />
              </div>
            </div>

            <div className="col-md-5">
              <div className="mb-3">
                <label htmlFor="inputHouseNumber" className="form-label">
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
                  placeholder="Jelszó"
                  required
                />
              </div>
            </div>

          </div>

          <div className="row">
            <div className="col-md-3 offset-md-5 mb-2">
              <button type="submit" className="avgbtn">
                Változtatások mentése
              </button>
            </div>
            <div className="col-md-2 offset-md-1 mb-2">
              <button type="button" className="avgbtn">
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