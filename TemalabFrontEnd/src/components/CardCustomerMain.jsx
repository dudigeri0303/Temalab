import "../App.css";
import PropTypes from 'prop-types';
import React, { useEffect, useState } from "react";

export default function CardCustomerMain({data}) {

  const [currentImage, setCurrentImage] = useState("/heart-empty.svg");
  const [likes, setLikes] = useState([]);

  useEffect(() => {
    listOfLiked()
    likes.forEach(element => {
      if(element.restaurantId === data.id){
        setCurrentImage("/heart-full.svg")
      }
    });
  },[likes])

  const toggleImage = () => {
    setCurrentImage(
      currentImage === "/heart-empty.svg"
        ? "/heart-full.svg"
        : "/heart-empty.svg"
    );
  };

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

  const likeRestaurant = async (restaurantId) =>{
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
        const response = await fetch("https://localhost:7114/api/LikedRestaurant/likeRestaurantForLoggedInUser?restaurantId=" + restaurantId, requestOptions);
        const result = await response.text();
        console.log(result)
      } catch (error) {
        console.error(error);
      }
    }
    else{

      let deletable = ""

      likes.forEach(element => {
        if(element.restaurantId === data.id){
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
      <section id="main" className="container py-2">
          <div className="position-relative">
            <a href={"/restaurant/" + data.id}>
              <div className="d-flex justify-content-between div-card">
                  <div>
                    <div>
                      <label className="card-text">{data.name}</label>
                    </div>
                    <div>
                      <label className="card-text">{data.desctiption}</label>
                    </div>
                    <div>
                      <label className="card-Altext">{data.label}</label>
                    </div>
                    <div>
                      <label className="card-Altext">{data.location}</label>
                    </div>
                  </div>
              </div>
            </a>
            <div className="d-flex align-items-center position-absolute likepos">
              <button className="likebtn" type = "button" onClick={() => likeRestaurant(data.id)}>
                <img
                  src={currentImage}
                  style={{ height: "40px", width: "40px" }}
                />
              </button>
            </div>
          </div>
      </section>
    </>
  );
}

CardCustomerMain.propTypes = {
  data: PropTypes.shape({
  id: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  description: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  location: PropTypes.string.isRequired
  }).isRequired,
};
