import CheckAuth from "../common/CheckAuth";
import GoogleMap from "../components/GoogleMap";
import OwnerNavbar from "../components/OwnerNavbar";
import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from 'react-router-dom';
import Reviews from "../components/Reviews";

export default function OwnerRestaurantPage(){

    const navigate = useNavigate(); 

    useEffect(() => {
        document.title = "Étterem | DineTab";
        getRestaurant();
        CheckAuth("owner",navigate)
    }, []);

    const [restaurant, setRestaurant] = useState([]);
    const [showModal, setShowModal] = useState(false);

    const id = useParams();
    console.log(id)

    const getRestaurant = async () =>{
        const myHeaders = new Headers();

        const requestOptions = {
        method: "GET",
        headers: myHeaders,
        redirect: "follow",
        credentials: 'include',
        xhrFields: { withCredentials: true},
        };

        try {
        const response = await fetch("https://localhost:7114/api/Restaurant/GetRestaurantById?id=" + id.id, requestOptions);
        const data = await response.json();
        setRestaurant(data);
        console.log(data);
        } catch (error) {
        console.error(error);
        }
    }

    return(
        <>
            <OwnerNavbar/>
            <div className="container">
                <div className="row">
                    <div className="col-12">
                        <a href={"/createmenu/" + restaurant.id} className="btnstyle restaurantpagebtn my-3 py-3">Étlap</a>
                    </div>
                </div>

                <div className="row">
                    <div className="col-12">
                    <a className="btnstyle restaurantpagebtn my-3 py-3">
                    Asztalok kezelése
                            </a>
                    </div>
                </div>
                <div className="row">
                    <div className="col-12">
                        <a className="btnstyle restaurantpagebtn my-3 py-3">Foglalások megtekintése</a>
                    </div>
                </div>
                <div className="row">
                    <div className="col-12">
                <a
                className="btnstyle restaurantpagebtn my-3 py-3"
                onClick={() => setShowModal(true)}
              >
                Értékelések
              </a>
              </div>
              </div>
                <Reviews showModal={showModal} setShowModal={setShowModal}></Reviews>
                <div className="row">
                    <div className="col-12 col-md-6 contactus d-flex align-items-center">
                        <div className="mx-auto">
                            <h3 className="contactustext">{restaurant.name} Elérhetőségei:</h3>
                            <p className="contactustext">{restaurant.location}</p>
                            <p className="contactustext">tesztetterem@gmail.com</p>
                            <p className="contactustext">+36 30 123 1452</p>
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <GoogleMap location={restaurant.location}/>
                    </div>
                </div>
            </div>
        </>
    )
}