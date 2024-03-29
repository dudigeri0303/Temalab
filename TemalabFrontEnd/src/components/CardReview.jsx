import "../App.css";

export default function CardReview() {
  return (
    <>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm-6 text-center">
                <label className="card-Altext">Felhasználónév</label>
              </div>
              <div className="col-sm-6 text-center">
                <label className="card-Altext">★★★★★</label>
              </div>
            </div>
            <div className="row">
              <div className="col-sm-12 text-center">
                <label className="card-Altext">Vélemény</label>
              </div>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}