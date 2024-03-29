import "../App.css";
import React, { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import Reviews from "../components/Reviews";
import { Button } from "react-bootstrap";

export default function Template() {
  useEffect(() => {
    document.title = "Template | DineTab";
  }, []);

  const [currentImage, setCurrentImage] = useState("/heart-empty.svg");

  const toggleImage = () => {
    setCurrentImage(
      currentImage === "/heart-empty.svg"
        ? "/heart-full.svg"
        : "/heart-empty.svg"
    );
  };

  const [showModal, setShowModal] = useState(false);

  //Nem responzív, de ez csak egy minta.

  return (
    <>
      <Navbar></Navbar>
      <div>
        <button className="cardbtn" onClick={() => setShowModal(true)}>
          Értékelések
        </button>
        <Reviews showModal={showModal} setShowModal={setShowModal}>
          <button className="avgbtn">+ Új vélemény</button>
        </Reviews>
      </div>

      <label>Vélemények</label>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm-6 text-center">
                <label className="card-Altext">Felhasználónév</label>
              </div>
              <div className="col-sm-6 text-center">
                <label className="card-Altext">★★★★★</label>
              </div>
            </div>
            <div className="row">
              <div className="col-sm-12 text-center">
                <label className="card-Altext">Vélemény</label>
              </div>
            </div>
          </div>
        </div>
      </section>

      <label>Foglalások Customer</label>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">Étterem neve</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">AsztalID</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">2024-03-12</label>
              </div>
              <div className="col-sm">
                <button type="button" className="cardbtn float-end">
                  Lemond
                </button>
              </div>
            </div>
          </div>
        </div>
      </section>

      <label>DeleteUser dmin</label>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">UserName</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">Email</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">Role</label>
              </div>
              <div className="col-sm">
                <button type="button" className="cardbtn float-end">
                  Töröl
                </button>
              </div>
            </div>
          </div>
        </div>
      </section>

      <label>Kedvencek Customer</label>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-md-3">
                <label className="card-text">Étterem név</label>
              </div>
              <div className="col-md-4">
                <label className="card-text">★★★★★</label>
              </div>
            </div>
            <div className="row">
              <div className="col d-flex align-items-end">
                <label className="card-Altext">Étterem stílusa</label>
              </div>
              <div className="col">
                <button
                  type="button"
                  className="cardbtn float-end"
                  style={{ margin: "0" }}
                >
                  Eltávolítás
                </button>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <label className="card-Altext">Étterem helye</label>
              </div>
            </div>
          </div>
        </div>
      </section>

      <label>MainPage Owner</label>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">Étterem neve</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">★★★★★</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-Altext">Étterem címe</label>
              </div>
              <div className="col-sm">
                <button type="button" className="cardbtn float-end">
                  Szerkesztés
                </button>
              </div>
            </div>
          </div>
        </div>
      </section>

      <label>MainPage Customer</label>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-md-6">
                <label className="card-text">Étterem név</label>
              </div>
              <div className="col-md-6 d-flex justify-content-end">
                <label className="card-text">★★★★★</label>
              </div>
            </div>
            <div className="row">
              <div className="col d-flex align-items-end">
                <label className="card-Altext">Étterem stílusa</label>
              </div>
              <div className="col d-flex justify-content-end">
                <a className="ms-5" href="#" onClick={toggleImage}>
                  <img src={currentImage} className="heartstyle"></img>
                </a>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <label className="card-Altext">Étterem helye</label>
              </div>
            </div>
          </div>
        </div>
      </section>

      <label>Asztalok Owner</label>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label className="card-Altext">AsztalID</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-Altext">Férőhely</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-Altext">IsFoglalt</label>
              </div>
              <div className="col-sm">
                <button type="button" className="cardbtn float-end">
                  Töröl
                </button>
              </div>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}
