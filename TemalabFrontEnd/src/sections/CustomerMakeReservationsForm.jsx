import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/Navbar";

export default function CustomerMakeReservationsForm() {
  useEffect(() => {
    document.title = "Foglalás megerősítése | DineTab";
  }, []);

  const makeReservation = () => {
    alert("Foglalás sikeres!");
    window.open("/customerReservations", "_self");
  };

  const cancelReservation = () => {
    window.open("/customerMakeReservation", "_self");
  };

  return (
    <>
      <Navbar />
      <section id="main" className="container py-3">
        <form method="post">
          <div className="row">
            <div className="div-card d-flex justify-content-center">
              <h1>Találtunk szabad asztalt, kérjük, töltse ki az alábbi adatokat.</h1>
              </div>
            <h2 className="d-flex justify-content-center">Asztalfoglalás 2024. 04. 22.-án 12:00 2 személyre</h2>
            <h4 className="h4-profile">Foglalás Adatok:</h4>

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
                  required
                />
              </div>
            </div>

            <div className="col-md-5">
              <div className="mb-3 d-flex justify-content-center">
                <label htmlFor="passwordForProfile" className="form-label">
                  Megj:
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
                  required
                />
              </div>
            </div>
            <div className="col-md-6 mb-3 d-flex justify-content-end">
              <input
                className="form-check-input"
                type="checkbox"
                value=""
                id="flexCheckChecked"
              />
              <label className="form-check-label" htmlFor="flexCheckChecked">
                Elfogadom az Általános Üzleti Feltételeket.
              </label>
            </div>
          </div>

          <div className="row">
            <div className="col-md-3 offset-md-5 mb-2">
              <button
                type="button"
                className="avgbtn"
                onClick={makeReservation}
              >
                Asztal foglalás
              </button>
            </div>
            <div className="col-md-2 offset-md-1 mb-2">
              <button
                type="button"
                className="avgbtn"
                onClick={cancelReservation}
              >
                Mégse
              </button>
            </div>
          </div>
        </form>
      </section>
    </>
  );
}
