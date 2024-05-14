import React, { useState } from "react";
import { Modal } from "react-bootstrap";
import CardAddReview from "../components/CardAddReview";
import { useParams } from "react-router-dom";

export default function AddReview({ showModal2, setShowModal2, children }) {
  const handleClose = () => {
    setShowModal2(false);
    //location.reload();
  };

  const id = useParams();
  console.log(id);

  const [reviews, setReviews] = useState([]);
  const [idReview, setIdReview] = useState("");
  const [rate, setRate] = useState();
  const [review, setReview] = useState("");

  const postReview = async () => {
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        id: idReview,
        rating: rate,
        description: review,
      }),
      credentials: "include",
      xhrFields: { withCredentials: true },
      redirect: "follow",
    };

    try {
      const response = await fetch(
        "https://localhost:7114/api/Review/createNewReviewForRestaurant?restaurantId=" +
          id.id,
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
      <div>
        <Modal show={showModal2} onHide={handleClose}>
          <div className="section-bg">
            <Modal.Header closeButton>
              <Modal.Title>Új vélemény írása</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              <CardAddReview
                idReview={idReview}
                setIdReview={setIdReview}
                rate={rate}
                setRate={setRate}
                review={review}
                setReview={setReview}
                postSubmit={postReview}
                handleClose={handleClose}
              />
            </Modal.Body>
            <Modal.Footer className="d-flex justify-content-center">
              {children}
            </Modal.Footer>
          </div>
        </Modal>
      </div>
    </>
  );
}
