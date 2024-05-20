import "../App.css";

export default function CardReview({ rating, description }) {
    const stars = Array(rating).fill("★");
  return (
    <>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm-6 text-center d-flex justify-content-lg-start">
                <label className="card-Altext">Értékelés: {stars.map((star, index) => (
            <span key={index}>{star}</span>
          ))}</label>
              </div>
            </div>
            <div className="row">
              <div className="col-sm-12 text-center d-flex justify-content-lg-start">
              <label className="card-Altext">Vélemény:</label>
                <label className="card-Altext">{description}</label>
              </div>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}