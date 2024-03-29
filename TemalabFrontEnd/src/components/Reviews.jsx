import React from "react";
import { Modal } from "react-bootstrap";
import CardReview from "../components/CardReview";

export default function Reviews({ showModal, setShowModal, children }) {
  const handleClose = () => {
    setShowModal(false);
  };

  return (
    <Modal show={showModal} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Vélemények</Modal.Title>
      </Modal.Header>
      <Modal.Body>
      <div>
        <CardReview></CardReview>
      </div>  
      </Modal.Body>
      <Modal.Footer>
      {children}
      </Modal.Footer>
    </Modal>
  );
}