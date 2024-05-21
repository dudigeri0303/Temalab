import React, { useEffect, useState } from "react";
import { Modal } from "react-bootstrap";
import CardReview from "../components/CardReview";
import { useParams } from 'react-router-dom';

export default function Reviews({ showModal, setShowModal, children }) {
  const [reviews, setReviews] = useState([]);
  
  useEffect(() => {
    getReviews();
  },[reviews])

  
  const handleClose = async () => {
    setShowModal(false);
  };

  const id = useParams();

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
        "https://localhost:7114/api/Review/getReviewsForRestaurantById?restaurantId="+ id.id, requestOptions
      );
      const data = await response.json();
      setReviews(data);
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
            <CardReview key={review.id} userName={review.userName} rating={review.rating} description={review.description} />
          ))}
          </div>
        </Modal.Body>
        <Modal.Footer className="d-flex justify-content-center">{children}</Modal.Footer>
        </div>
      </Modal>
      
    </>
  );
}
