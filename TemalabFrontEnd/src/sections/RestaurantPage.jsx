import Navbar from "../components/Navbar";
import GoogleMap from "../components/GoogleMap";
import React, { useEffect, useState } from "react";
import Reviews from "../components/Reviews";
import AddReview from "../components/AddReview";
import { useNavigate, useParams } from 'react-router-dom';
import CheckAuth from "../common/CheckAuth";

export default function RestaurantPage() {

  const navigate = useNavigate();
  const [restRate, setRestRate] = useState(0);
  const [missRate, setMissRate] = useState(5);
  const [likes, setLikes] = useState([]);
  const [currentImage, setCurrentImage] = useState("/heart-empty.svg");
  const id = useParams();

  useEffect(() => {
    document.title = "Étterem | DineTab";
    getRestaurant();
    getRateOfRest();
    CheckAuth("customer",navigate)
  }, []);

  useEffect(() => {
    listOfLiked()
    likes.forEach(element => {
      if(element.restaurantId === id.id){
        setCurrentImage("/heart-full.svg")
      }
    });
  },[likes])

  const listOfLiked = async () => {
    const myHeaders = new Headers();

    const requestOptions = {
      method: "GET",
      headers: myHeaders,
      credentials: 'include',
      xhrFields: { withCredentials: true},
      redirect: "follow"
    };

    try {
      const response = await fetch("https://localhost:7114/api/LikedRestaurant/getLikedRestaurantForLoggedInUser", requestOptions);
      const result = await response.json();
      setLikes(result)
    } catch (error) {
      console.error(error);
    }
  }

  const toggleImage = () => {
    setCurrentImage(
      currentImage === "/heart-empty.svg"
        ? "/heart-full.svg"
        : "/heart-empty.svg"
    );
  };

  const [showModal, setShowModal] = useState(false);
  const [showModal2, setShowModal2] = useState(false);
  const [restaurant, setRestaurant] = useState([]);

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

  const getRateOfRest = async () => {
    const myHeaders = new Headers();

    const requestOptions = {
      method: "GET",
      headers: myHeaders,
      redirect: "follow",
      credentials: 'include',
      xhrFields: { withCredentials: true},
    };

    try {
      const response = await fetch("https://localhost:7114/api/Review/getAvargeRatingByRestaurantId?restaurantId=" + id.id, requestOptions);
      const data = await response.json();
      setRestRate(parseInt(data));
      setMissRate(missRate - parseInt(data));
    } catch (error) {
      console.error(error);
    }
  }

  const likeRestaurant = async () =>{
    const myHeaders = new Headers();

    if(currentImage === "/heart-empty.svg"){
      const requestOptions = {
        method: "POST",
        headers: myHeaders,
        credentials: 'include',
        xhrFields: { withCredentials: true},
        redirect: "follow"
      };
  
      try {
        const response = await fetch("https://localhost:7114/api/LikedRestaurant/likeRestaurantForLoggedInUser?restaurantId=" + id.id, requestOptions);
        const result = await response.text();
      } catch (error) {
        console.error(error);
      }
    }
    else{

      let deletable = ""

      likes.forEach(element => {
        if(element.restaurantId === id.id){
          deletable = element.id
        }
      });

      const requestOptions = {
        method: "DELETE",
        headers: myHeaders,
        credentials: 'include',
        xhrFields: { withCredentials: true},
        redirect: "follow"
      };
  
      try {
        await fetch("https://localhost:7114/api/LikedRestaurant/deleteLikedRestaurantForLoggedUser?likedRestaurantId=" + deletable, requestOptions);
      } catch (error) {
        console.error(error);
      }
    }

    toggleImage()
  };

  return (
    <>
      <Navbar />
      <div className="container">
        <div className="row">
          <div className="col-12">
            <a className="btnstyle restaurantpagebtn my-3 py-3"  href={"/menu/" + id.id} >Étlap</a>
          </div>
        </div>
        <div className="row">
          <div className="col-12">
            <a href={"/customerMakeReservation/" + id.id} className="btnstyle restaurantpagebtn my-3 py-3">
              Asztal Foglalás
            </a>
          </div>
        </div>
        <div className="row">
          <div className="col-12 col-lg-8">
            <div>
              <button
                className="btnstyle w-100 restaurantpagebtn my-3 py-3"
                onClick={() => setShowModal(true)}
              >
                Értékelések
              </button>
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
                      Mégse
                    </button>
                  </div>
                </AddReview>
              </Reviews>
            </div>
          </div>
          <div className="col-12 col-lg-4 d-flex justify-content-center my-2 py-3">
            {Array.from({length: restRate},(_, index) => (
              <img key={index} src="/star-full.svg" className="starstyle"></img>
            ))}
            {Array.from({length: missRate},(_,index) => (
              <img key={index} src="/star-empty.svg" className="starstyle"></img>
            ))}
            <a className="ms-5" href="#" onClick={() => likeRestaurant()}>
              <img src={currentImage} className="heartstyle"></img>
            </a>
          </div>
        </div>
        <div className="row">
          <div className="col-12 col-lg-6 contactus d-flex align-items-center my-2 py-2">
            <div className="mx-auto">
              <h6 className="contactustext">{restaurant.name} elérhetőségei:</h6>
              <h6 className="contactustext">{restaurant.location}</h6>
              <h6 className="contactustext">{restaurant.phoneNumber}</h6>
              <div className="row">
                  {restaurant?.openingHours?.map((open,index) => (
                      <div key={index} className="col-6">
                          <p className="contactustext">{open.dayName}: {open.openingHour}</p>
                      </div>
                  ))}
              </div>
            </div>
          </div>
          <div className="col-12 col-lg-6">
            <GoogleMap location={restaurant.location}/>
          </div>
        </div>
      </div>
    </>
  );
}
