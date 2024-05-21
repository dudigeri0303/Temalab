import CheckAuth from "../common/CheckAuth";
import GoogleMap from "../components/GoogleMap";
import OwnerNavbar from "../components/OwnerNavbar";
import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from 'react-router-dom';
import Reviews from "../components/Reviews";


export default function OwnerRestaurantPage(){

    const navigate = useNavigate(); 
    //const navigate2 = useNavigate(); 


    useEffect(() => {
        document.title = "Étterem | DineTab";
        getRestaurant();
        CheckAuth("owner",navigate)
    }, []);

    const [restaurant, setRestaurant] = useState([]);
    const [showModal, setShowModal] = useState(false);

    const id = useParams();

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
        const response = await fetch("https://localhost:7114/api/Restaurant/GetRestaurantById?restaurantId=" + id.id, requestOptions);
        const data = await response.json();
        setRestaurant(data);
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
                    <a href={`/ownerManageTables/${id.id}`} className="btnstyle restaurantpagebtn my-3 py-3">
                    Asztalok kezelése
                            </a>
                    </div>
                </div>
                <div className="row">
                    <div className="col-12">
                        <a href={"/restaurantreservations/" + id.id} className="btnstyle restaurantpagebtn my-3 py-3">Foglalások megtekintése</a>
                    </div>
                </div>
                {console.log(restaurant)}
                <div className="row">
                    <div className="col-12">
                <button
                className="w-100 btnstyle restaurantpagebtn my-3 py-3"
                onClick={() => setShowModal(true)}
              >
                Értékelések
              </button>
              </div>
              </div>
                <Reviews showModal={showModal} setShowModal={setShowModal}></Reviews>
                <div className="row">
                    <div className="col-12 col-md-6 contactus d-flex align-items-center">
                        <div className="mx-auto">
                            <h3 className="contactustext">{restaurant.name} Elérhetőségei:</h3>
                            <p className="contactustext">{restaurant.location}</p>
                            <p className="contactustext">{restaurant.phoneNumber}</p>
                            <h3 className="contactustext">Nyitvatartás:</h3>
                            <div className="row">
                                {restaurant?.openingHours?.map((open,index) => (
                                    <div key={index} className="col-6">
                                        <p className="contactustext">{open.dayName}: {open.openingHour}</p>
                                    </div>
                                ))}
                            </div>
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