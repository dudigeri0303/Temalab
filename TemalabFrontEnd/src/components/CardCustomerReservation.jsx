import "../App.css";

export default function CardCustomerReservation() {
  return (
    <>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">Étterem neve</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">AsztalID</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">2024-03-12</label>
              </div>
              <div className="col-sm">
                <button type="button" className="cardbtn float-end">
                  Lemond
                </button>
              </div>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}