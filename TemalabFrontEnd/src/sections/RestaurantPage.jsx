import Navbar from "../components/Navbar";
import GoogleMap from '../components/GoogleMap';
import React, { useState } from 'react';

export default function RestaurantPage(){

    const [currentImage, setCurrentImage] = useState('/heart-empty.svg');

    const toggleImage = () => {
        setCurrentImage(currentImage === '/heart-empty.svg' ? '/heart-full.svg' : '/heart-empty.svg');
    };

    return(
        <>
            <Navbar/>
            <div className="container">
                <div className="row">
                    <div className="col-12">
                        <a className="btnstyle restaurantpagebtn my-3 py-3">Étlap</a>
                    </div>
                </div>
                <div className="row">
                    <div className="col-12">
                        <a className="btnstyle restaurantpagebtn my-3 py-3">Asztal Foglalás</a>
                    </div>
                </div>
                <div className="row">
                    <div className="col-12 col-md-8">
                        <a className="btnstyle restaurantpagebtn my-3 py-3">Értékelések</a>
                    </div>
                    <div className="col-12 col-md-4 d-flex justify-content-center my-2 py-3">
                        <img src="/star-full.svg" className="starstyle"></img>
                        <img src="/star-full.svg" className="starstyle"></img>
                        <img src="/star-full.svg" className="starstyle"></img>
                        <img src="/star-empty.svg" className="starstyle"></img>
                        <img src="/star-empty.svg" className="starstyle"></img>
                        <a className="ms-5" href="#" onClick={toggleImage}><img src={currentImage} className="heartstyle"></img></a>
                    </div>
                </div>
                <div className="row">
                    <div className="col-12 col-md-6 contactus d-flex align-items-center">
                        <div className="mx-auto">
                            <h3 className="contactustext">Elérhetőségeink:</h3>
                            <p className="contactustext">Teszt Étterem név</p>
                            <p className="contactustext">tesztetterem@gmail.com</p>
                            <p className="contactustext">+36 30 123 1452</p>
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <GoogleMap/>
                    </div>
                </div>
            </div>
        </>
    )
}