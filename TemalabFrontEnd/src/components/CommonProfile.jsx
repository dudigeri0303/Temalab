import { json } from "react-router-dom";
import "../App.css";
import React, { useEffect, useState } from "react";

export default function Profile() {
  useEffect(() => {
    document.title = "Profile | DineTab";
  }, []);

  const getUserData = async () => {
    const myHeaders = new Headers();
    myHeaders.append("Cookie", ".AspNetCore.Identity.Application=CfDJ8J3qJxRhS7BCp-kLUWa5SWF_w9x0si2UIGcLyQWOOYmAkKWoVNwqB5wvTDYm5fBpU7CqAaoOfVmoaPbID_EKY9lgLlZ5hcExj9TP9hj8FpbqPceWF4KoSD4Y8p4QLDWSo5HCWnsto8YfSTMr-TiCUVGG_UEipP9GKQUq8sJ8Fq8JU_5kyOQ8WtjsMUut1G05vR96u7C1ghO4uE_mkup206Xqvp60x0rPn4e7zayMKzVCMSEC_jQkaZYQvHY5kEEF8LVgFCdd68CiXrNpQDdqfPkIE8Zi5tKWZ3VZ0WdJPm3k9EoXyaNxwRgGoyXWbwDNo3iW2DIg-4D1vMJYl4FxkNwrCEmioQANB6zKTe9HLIZVpXmqFqLBaPuB7c1W5aTj3rIk_Lwv51NfIPG-2okCc6zH4F0hWOVfY7A4NeSqFS_hytspNjTjLeI9o096S_V4BmdEr-gJxP5wEcjRNasKx9UuI_jZky73AYpe8oAly9UiqBfFW2Tjnt02g7xIp6nXrOemcvCyHKx-vyxLvynq7XfWRokPxVzYZYygW5HcFtDt-CRCunwrQtJQiq_POBhBISJr0g707mK9nPMYVz7bFFeGxySD1cDq5Y4PrptAuhdtbRkx-NAutxgYn6IdfuxE0l5X3GcwrTbjfM4KuvQmpKXnusQE8TicRdXxeTma5DGlDF4THrP_L1HnN_Lcyrxlnq8dvrhWX9rbKMTaX3ExfWo");

    const requestOptions = {
      method: "GET",
      headers: myHeaders,
      redirect: "follow"
    };

    try {
      const response = await fetch("https://localhost:7114/api/User/getLoggedInUserData", requestOptions);
      const result = await response.text();
      console.log(result)
      console.log(JSON.stringify(result));
    } catch (error) {
      console.error(error);
    }
  }
  //Nem írja ki konzolra, mert a belépés ellenére a hitelesítés nem jó.
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
                  placeholder="Név"
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
                  placeholder="Telefonszám"
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
                  placeholder="Email"
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
                  placeholder="Jelszó"
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