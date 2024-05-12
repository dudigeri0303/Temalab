import React, { useState } from "react";
import { Modal } from "react-bootstrap";
import CardReview from "../components/CardReview";

export default function Reviews({ showModal, setShowModal, children }) {
  const handleClose = () => {
    setShowModal(false);
    getReviews();
  };

  const [reviews, setReviews] = useState([]);

  const getReviews = async () => {
    const myHeaders = new Headers();
    const requestOptions = {
      method: "GET",
      headers: myHeaders,
      credentials: "include",
      xhrFields: { withCredentials: true },
      redirect: "follow",
    };

    try {
      const response = await fetch(
        "https://localhost:7114/api/Review/getReviewsForRestaurantById?restaurantId=5f237da9-11f8-4cb8-bdfb-0c80c73900df",
        requestOptions
      );
      const data = await response.json();
      setReviews(data);
      console.log(data);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <>
    
      <Modal show={showModal} onHide={handleClose}>
      <div className="section-bg">
        <Modal.Header closeButton>
          <Modal.Title>Vélemények</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div>
          {reviews.map((review) => (
            <CardReview key={review.id} id={review.id} rating={review.rating} description={review.description} />
          ))}
          </div>
        </Modal.Body>
        <Modal.Footer className="d-flex justify-content-center">{children}</Modal.Footer>
        </div>
      </Modal>
      
    </>
  );
}
