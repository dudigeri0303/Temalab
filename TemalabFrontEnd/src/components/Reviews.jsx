import React from "react";
import { Modal } from "react-bootstrap";
import CardReview from "../components/CardReview";

export default function Reviews({ showModal, setShowModal, children }) {
  const handleClose = () => {
    setShowModal(false);
  };

  return (
    <>
      <Modal show={showModal} onHide={handleClose}>
        <Modal.Header className="section-bg" closeButton>
          <Modal.Title>Vélemények</Modal.Title>
        </Modal.Header>
        <Modal.Body className="section-bg">
          <div>
            <CardReview></CardReview>
          </div>
        </Modal.Body>
        <Modal.Footer className="section-bg d-flex justify-content-center">{children}</Modal.Footer>
      </Modal>
    </>
  );
}
