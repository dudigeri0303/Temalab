import "../App.css";
import React, { useEffect } from "react";

export default function Profile() {
  useEffect(() => {
    document.title = "Profile | DineTab";
  }, []);

  const deleteProfile = () => {
    const IsProfileDeleted = window.confirm('Biztos törlöd a profilod?');
    if (IsProfileDeleted) {
      {/*Profil törlése method hívás*/}
      window.open("/createRestaurant", "_self");
      {/*Visszairányít a login oldalra _self, hogy ne új lapon nyissa meg*/}
    }
  };

  return (
    <>
      <section id="main" className="container py-3">
        <h1 className="display-3">Profile</h1>
        <br/>
        
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
              <button type="button" className="btnstyle float-md-right">
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
            <div className="col-md-3 offset-md-3 mb-2">
              <button type="submit" className="btnstyle float-md-right">
                Változtatások mentése
              </button>
            </div>
            <div className="col-md-2 offset-md-0.5 mb-2">
              <button type="button" className="btnstyle">
                Mégse
              </button>
            </div>
          </div>

        </form>
 
        <div>
              <button onClick={deleteProfile} type="button" className="redbtn">
                Profil törlése
              </button>
            </div>

      </section>
    </>
  );
}