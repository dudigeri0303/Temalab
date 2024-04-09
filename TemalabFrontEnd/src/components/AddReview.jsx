import React from "react";
import { Modal } from "react-bootstrap";
import CardAddReview from "../components/CardAddReview";

export default function AddReview({ showModal2, setShowModal2, children }) {
  const handleClose = () => {
    setShowModal2(false);
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
          <div>
            <CardAddReview></CardAddReview>
          </div>
        </Modal.Body>
        <Modal.Footer className="d-flex justify-content-center">{children}</Modal.Footer>
        </div>
      </Modal>
      </div>
      
    </>
  );
}
