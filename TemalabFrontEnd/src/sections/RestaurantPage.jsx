import Navbar from "../components/Navbar";
import GoogleMap from "../components/GoogleMap";
import React, { useState } from "react";
import Reviews from "../components/Reviews";
import AddReview from "../components/AddReview";

export default function RestaurantPage() {
  const [currentImage, setCurrentImage] = useState("/heart-empty.svg");

  const toggleImage = () => {
    setCurrentImage(
      currentImage === "/heart-empty.svg"
        ? "/heart-full.svg"
        : "/heart-empty.svg"
    );
  };

  const [showModal, setShowModal] = useState(false);
  const [showModal2, setShowModal2] = useState(false);

  return (
    <>
      <Navbar />
      <div className="container">
        <div className="row">
          <div className="col-12">
            <a className="btnstyle restaurantpagebtn my-3 py-3">Étlap</a>
          </div>
        </div>
        <div className="row">
          <div className="col-12">
            <a className="btnstyle restaurantpagebtn my-3 py-3">
              Asztal Foglalás
            </a>
          </div>
        </div>
        <div className="row">
          <div className="col-12 col-lg-8">
            <div>
              <a
                className="btnstyle restaurantpagebtn my-3 py-3"
                onClick={() => setShowModal(true)}
              >
                Értékelések
              </a>
              <Reviews showModal={showModal} setShowModal={setShowModal}>
                <button className="avgbtn" onClick={() => setShowModal2(true)}>
                  + Új vélemény
                </button>

                <AddReview
                  showModal2={showModal2}
                  setShowModal2={setShowModal2}
                >
                  <div className="text-center">
                    <button
                      className="avgbtn"
                      onClick={() => setShowModal2(false)}
                    >
                      Közzétesz
                    </button>
                  </div>
                  <div className="text-center">
                    <button
                      className="avgbtn"
                      onClick={() => setShowModal2(false)}
                    >
                      Mégse
                    </button>
                  </div>
                </AddReview>
              </Reviews>
            </div>
          </div>
          <div className="col-12 col-lg-4 d-flex justify-content-center my-2 py-3">
            <img src="/star-full.svg" className="starstyle"></img>
            <img src="/star-full.svg" className="starstyle"></img>
            <img src="/star-full.svg" className="starstyle"></img>
            <img src="/star-empty.svg" className="starstyle"></img>
            <img src="/star-empty.svg" className="starstyle"></img>
            <a className="ms-5" href="#" onClick={toggleImage}>
              <img src={currentImage} className="heartstyle"></img>
            </a>
          </div>
        </div>
        <div className="row">
          <div className="col-12 col-lg-6 contactus d-flex align-items-center my-2 py-2">
            <div className="mx-auto">
              <h6 className="contactustext">Elérhetőségeink:</h6>
              <h6 className="contactustext">Teszt Étterem név</h6>
              <h6 className="contactustext">tesztetterem@gmail.com</h6>
              <h6 className="contactustext">+36 30 123 1452</h6>
            </div>
          </div>
          <div className="col-12 col-lg-6">
            <GoogleMap />
          </div>
        </div>
      </div>
    </>
  );
}
